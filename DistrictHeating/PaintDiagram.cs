using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DistrictHeating
{
    public class PaintDiagram
    {
        Panel diagram;
        Panel left;
        Panel right;
        Panel timeScale;
        Plant plant;
        ToolTip toolTip;

        Dictionary<string, List<PointF>> paths = new Dictionary<string, List<PointF>>();
        float horLineDiff; // distance of the horizontal lines
        float horizontalScale = 1.0f;
        float horizontalOffset = 0.0f;
        bool dayMode = true; // per day or per hour
        bool invalidated = false;
        bool initialized = false;
        int mouseDownPosX;
        public PaintDiagram(Panel diagram, Panel left, Panel right, Panel timeScale, ToolTip toolTip, Plant plant)
        {
            this.diagram = diagram;
            this.left = left;
            this.right = right;
            this.plant = plant;
            this.toolTip = toolTip;
            this.timeScale = timeScale;
            toolTip.AutoPopDelay = 2000;

            horLineDiff = diagram.Height / 13.0f; // hardcoded 12 horizontal lines
            showWarmPipeTemp = true;
            showBoreHoleEnergy = true;
            showHeatConsumption = true;
            showElectricityConsumption = true;
            invalidated = true;
            horizontalScale = diagram.Width / 365.0f;
        }


        bool showReturnPipeTemperature = false;
        public bool ShowReturnPipeTemperature { get { return showReturnPipeTemperature; } set { showReturnPipeTemperature = value; invalidated = true; } }
        bool showWarmPipeTemp = false;
        public bool ShowWarmPipeTemperature { get { return showWarmPipeTemp; } set { showWarmPipeTemp = value; invalidated = true; } }
        bool showHotPipeTemp = false;
        public bool ShowHotPipeTemperature { get { return showHotPipeTemp; } set { showHotPipeTemp = value; invalidated = true; } }
        bool showAmbientTemperature = false;
        public bool ShowAmbientTemperature { get { return showAmbientTemperature; } set { showAmbientTemperature = value; invalidated = true; } }
        bool showBoreHoleEnergy = false;
        public bool ShowBoreHoleEnergy { get { return showBoreHoleEnergy; } set { showBoreHoleEnergy = value; invalidated = true; } }
        bool showBoreHoleTempBorder = false;
        public bool ShowBoreHoleTempBorder { get { return showBoreHoleTempBorder; } set { showBoreHoleTempBorder = value; invalidated = true; } }
        bool showBoreHoleTempCenter = false;
        public bool ShowBoreHoleTempCenter { get { return showBoreHoleTempCenter; } set { showBoreHoleTempCenter = value; invalidated = true; } }
        bool showBoreHoleEnergyFlow = false;
        public bool ShowBoreHoleEnergyFlow { get { return showBoreHoleEnergyFlow; } set { showBoreHoleEnergyFlow = value; invalidated = true; } }
        bool showHeatConsumption = false;
        public bool ShowHeatConsumption { get { return showHeatConsumption; } set { showHeatConsumption = value; invalidated = true; } }
        bool showElectricityConsumption = false;
        public bool ShowElectricityConsumption { get { return showElectricityConsumption; } set { showElectricityConsumption = value; invalidated = true; } }
        bool showSolarHeat = false;
        public bool ShowSolarHeat { get { return showSolarHeat; } set { showSolarHeat = value; invalidated = true; } }
        bool showVolumeFlow = false;
        public bool ShowVolumeFlow { get { return showVolumeFlow; } set { showVolumeFlow = value; invalidated = true; } }
        bool showNetLoss = false;
        public bool ShowNetLoss { get { return showNetLoss; } set { showNetLoss = value; invalidated = true; } }


        private float HorLinePosition(int ind)
        {
            return (12 - ind) * horLineDiff;
        }

        private void ShowScale(bool leftSide, int lowestValue1, int step1, string? suffix1, int lowestValue2, int step2, string? suffix2)
        {
            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            Graphics toDrawOn;
            if (leftSide) toDrawOn = left.CreateGraphics();
            else toDrawOn = right.CreateGraphics();
            using (toDrawOn)
            {
                toDrawOn.Clear(Color.White);
                for (int i = 0; i < 12; i++)
                {
                    if (step2 == 0)
                    {
                        int val = lowestValue1 + i * step1;
                        toDrawOn.DrawString(val.ToString() + suffix1, SystemFonts.DefaultFont, Brushes.Black, new PointF(left.Width / 2.0f, HorLinePosition(i)), centerFormat);
                    }
                    else
                    {
                        int val1 = lowestValue1 + i * step1;
                        int val2 = lowestValue2 + i * step2;
                        toDrawOn.DrawString(val1.ToString() + suffix1 + "\n" + val2.ToString() + suffix2, SystemFonts.DefaultFont, Brushes.Black, new PointF(left.Width / 2.0f, HorLinePosition(i)), centerFormat);
                    }
                }
            }
        }

        private void calcDisplay()
        {
            initialized = true;
            // calculate the minima and maxima for all units
            Dictionary<string, double> unitMinValue = new Dictionary<string, double>();
            Dictionary<string, double> unitMaxValue = new Dictionary<string, double>();
            HashSet<string> names = new HashSet<string>();
            int minSeconds = int.MaxValue, maxSeconds = int.MinValue;
            foreach (KeyValuePair<string, List<Plant.DiagramEntry>> item in plant.Diagrams)
            {
                string[] parts = item.Key.Split('|');
                string name = parts[0];
                string unit = parts[1];
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (item.Value[i].val > 1400)
                    {

                    }
                    if (!unitMinValue.TryGetValue(unit, out double val)) unitMinValue[unit] = item.Value[i].val;
                    else unitMinValue[unit] = Math.Min(item.Value[i].val, unitMinValue[unit]);
                    if (!unitMaxValue.TryGetValue(unit, out val)) unitMaxValue[unit] = item.Value[i].val;
                    else unitMaxValue[unit] = Math.Max(item.Value[i].val, unitMaxValue[unit]);
                    minSeconds = Math.Min(item.Value[i].timeStamp, minSeconds);
                    maxSeconds = Math.Max(item.Value[i].timeStamp, maxSeconds);
                    names.Add(name);
                }
            }
            Dictionary<string, float> unitFactor = new Dictionary<string, float>();
            Dictionary<string, float> unitOffset = new Dictionary<string, float>();
            Dictionary<string, int> unitStart = new Dictionary<string, int>();
            Dictionary<string, int> unitStep = new Dictionary<string, int>();
            foreach (string unit in unitMinValue.Keys)
            {
                if (unitMinValue[unit] < unitMaxValue[unit])
                {
                    Scale(unitMinValue[unit], unitMaxValue[unit], out int start, out int step, out float factor, out float offset);
                    unitOffset[unit] = offset;
                    unitFactor[unit] = factor;
                    unitStart[unit] = start;
                    unitStep[unit] = step;
                }
            }
            string[] units = unitStart.Keys.ToArray();

            if (units.Length == 1)
            {
                ShowScale(true, unitStart[units[0]], unitStep[units[0]], units[0], 0, 0, "");
                using (Graphics gr = right.CreateGraphics()) { gr.Clear(Color.White); }
            }
            else if (units.Length == 2)
            {
                ShowScale(true, unitStart[units[0]], unitStep[units[0]], units[0], 0, 0, "");
                ShowScale(false, unitStart[units[1]], unitStep[units[1]], units[1], 0, 0, "");
            }
            else if (units.Length == 3)
            {
                ShowScale(true, unitStart[units[0]], unitStep[units[0]], units[0], unitStart[units[2]], unitStep[units[2]], units[2]);
                ShowScale(false, unitStart[units[1]], unitStep[units[1]], units[1], 0, 0, "");
            }
            else if (units.Length == 4)
            {
                ShowScale(true, unitStart[units[0]], unitStep[units[0]], units[0], unitStart[units[2]], unitStep[units[2]], units[2]);
                ShowScale(false, unitStart[units[1]], unitStep[units[1]], units[1], unitStart[units[3]], unitStep[units[3]], units[3]);
            }
            paths.Clear();
            if (dayMode)
            {
                foreach (KeyValuePair<string, List<Plant.DiagramEntry>> item in plant.Diagrams)
                {
                    string[] parts = item.Key.Split('|');
                    string name = parts[0];
                    string unit = parts[1];
                    float sum = 0.0f;
                    int num = 0;
                    int currentDay = 0;
                    paths[name] = new List<PointF>();
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        if (item.Value[i].timeStamp / (3600 * 24) != currentDay)
                        {
                            float val = sum / num;
                            paths[name].Add(new PointF(currentDay, (float)(val * unitFactor[unit] + unitOffset[unit])));
                            currentDay = item.Value[i].timeStamp / (3600 * 24);
                            sum = 0.0f;
                            num = 0;
                        }
                        sum += (float)item.Value[i].val;
                        num += 1;
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, List<Plant.DiagramEntry>> item in plant.Diagrams)
                {
                    string[] parts = item.Key.Split('|');
                    string name = parts[0];
                    string unit = parts[1];
                    paths[name] = new List<PointF>();
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        paths[name].Add(new PointF(item.Value[i].timeStamp / (float)(3600 * 24), (float)(item.Value[i].val * unitFactor[unit] + unitOffset[unit])));
                    }
                }
            }
        }
        void PaintTimeScale()
        {
            using (Graphics gr = timeScale.CreateGraphics())
            {
                gr.Clear(Color.White);
                int h = timeScale.Height;
                StringFormat centerFormat = new StringFormat();
                centerFormat.Alignment = StringAlignment.Center;
                centerFormat.LineAlignment = StringAlignment.Center;
                string[] monthName = new string[] { "Jan", "Feb", "Mär", "Apr", "Mai", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dez" };
                // day mode:
                int daynum = 0;
                for (int i = 0; i < Plant.daysPerMonth.Length; i++)
                {
                    gr.DrawLine(Pens.Black, daynum * horizontalScale + horizontalOffset, 0.0f, daynum * horizontalScale + horizontalOffset, h / 2);
                    gr.DrawString(monthName[i], SystemFonts.DefaultFont, Brushes.Black, new PointF(daynum * horizontalScale + horizontalOffset + horizontalScale * Plant.daysPerMonth[i] / 2, h / 2), centerFormat);
                    daynum += Plant.daysPerMonth[i];
                }
                if (!dayMode)
                {
                    daynum = 0;
                    for (int i = 0; i < Plant.daysPerMonth.Length; i++)
                    {
                        for (int j = 0; j < Plant.daysPerMonth[i]; j++)
                        {
                            gr.DrawLine(Pens.Black, (daynum+j) * horizontalScale + horizontalOffset, 0.0f, (daynum + j) * horizontalScale + horizontalOffset, h / 4);
                        }
                        daynum += Plant.daysPerMonth[i];
                    }
                }
            }
        }
        private PointF[] TransformedPoints(List<PointF> points)
        {
            PointF[] res = new PointF[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                res[i] = new PointF(points[i].X * horizontalScale + horizontalOffset, points[i].Y);
            }
            return res;
        }
        private void Repaint()
        {
            PaintTimeScale();
            using (Graphics grDiagram = diagram.CreateGraphics())
            {
                if (paths.Count == 0)
                {
                    StringFormat centerFormat = new StringFormat();
                    centerFormat.Alignment = StringAlignment.Center;
                    centerFormat.LineAlignment = StringAlignment.Center;
                    grDiagram.DrawString("noch keine Daten vorhanden", SystemFonts.DefaultFont, Brushes.Black, new PointF(diagram.Width / 2, diagram.Height / 2), centerFormat);
                }
                else
                {
                    //Matrix matrix = new Matrix();
                    //matrix.Translate(horizontalOffset, 0.0f);
                    //matrix.Scale(horizontalScale, 1.0f);
                    //grDiagram.Transform = matrix; // scales also the linewidth, which looks bad

                    grDiagram.Clear(Color.White);
                    for (int i = 0; i < 12; i++)
                    {
                        grDiagram.DrawLine(Pens.LightGray, 0, HorLinePosition(i), diagram.Width, HorLinePosition(i));
                    }
                    if (ShowWarmPipeTemperature) grDiagram.DrawCurve(Pens.DarkOrange, TransformedPoints(paths["warmPipe"]));
                    if (ShowAmbientTemperature) grDiagram.DrawCurve(Pens.Blue, TransformedPoints(paths["ambientTemperature"]));
                    if (ShowReturnPipeTemperature) grDiagram.DrawCurve(Pens.Black, TransformedPoints(paths["returnPipe"]));
                    if (ShowHotPipeTemperature) grDiagram.DrawCurve(Pens.Maroon, TransformedPoints(paths["hotPipe"]));
                    if (ShowBoreHoleTempCenter) grDiagram.DrawCurve(Pens.Red, TransformedPoints(paths["boreHoleCenter"]));
                    if (ShowBoreHoleTempBorder) grDiagram.DrawCurve(Pens.Purple, TransformedPoints(paths["boreHoleBorder"]));
                    if (ShowHeatConsumption) grDiagram.DrawCurve(Pens.Fuchsia, TransformedPoints(paths["heatConsumption"]));
                    if (ShowElectricityConsumption) grDiagram.DrawCurve(Pens.DeepPink, TransformedPoints(paths["electricityConsumption"]));
                    if (ShowSolarHeat) grDiagram.DrawCurve(Pens.Olive, TransformedPoints(paths["solarEnergy"]));
                    if (ShowBoreHoleEnergyFlow) grDiagram.DrawCurve(Pens.Navy, TransformedPoints(paths["boreHoleEnergyFlow"]));
                    if (ShowVolumeFlow) grDiagram.DrawCurve(Pens.Teal, TransformedPoints(paths["volumeFlow"]));
                    if (ShowNetLoss) grDiagram.DrawCurve(Pens.Indigo, TransformedPoints(paths["netLoss"]));
                    if (showBoreHoleEnergy) grDiagram.DrawCurve(Pens.Brown, TransformedPoints(paths["boreHoleEnergy"]));
                }
            }
        }

        private void MakePath(ref PointF[] points, double horScale, List<double> data, bool hourToDayAverage, double factor, double offset)
        {
            if (hourToDayAverage)
            {
                points = new PointF[365];
                for (int i = 0; i < points.Length; i++)
                {
                    double sum = 0.0;
                    for (int j = 0; j < 24; j++)
                    {
                        sum += data[i * 24 + j];
                    }
                    sum /= 24;
                    points[i] = new PointF((float)(i * horScale), (float)(sum * factor + offset));
                }
            }
            else
            {
                points = new PointF[data.Count];
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new PointF((float)(i * horScale), (float)(data[i] * factor + offset));
                }
            }
        }

        private void Scale(double min, double max, out int start, out int step, out float factor, out float offset)
        {
            double l = Math.Log10((max - min) / 13); // 13, because we have hardcoded 12 hor. lines, i.e. 13 intervalls
            int numDigits = (int)Math.Floor(l);
            if ((l - numDigits) < Math.Log10(2)) step = 2 * (int)Math.Round(Math.Pow(10, numDigits));
            else if ((l - numDigits) < Math.Log10(5)) step = 5 * (int)Math.Round(Math.Pow(10, numDigits));
            else step = (int)Math.Round(Math.Pow(10, numDigits + 1));
            int lowest = 0, highest = 0;
            if (min < 0)
            {
                while (lowest > min) lowest -= step;
            }
            else
            {
                while (lowest < min - step) lowest += step;
            }
            while (highest < max) highest += step;
            factor = -(float)horLineDiff / step;
            // o == dh -horl - l*f
            offset = diagram.Height - horLineDiff - lowest * factor;
            start = lowest;
        }

        private void MinMax(ref double min, ref double max, double v)
        {
            if (v < min) min = v;
            if (v > max) max = v;
        }

        public void Paint()
        {
            calcDisplay();
            Repaint();
        }
        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        internal void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mouseDownPosX > 0)
            {
                horizontalOffset -= (mouseDownPosX - e.X);
                mouseDownPosX = e.X;
                horizontalOffset = Math.Max(Math.Min(0, horizontalOffset), diagram.Width - 365.0f * horizontalScale);
                diagram.Invalidate();
            }
            else
            {
                IntPtr hdc = GetWindowDC(diagram.Handle);
                if (hdc != IntPtr.Zero)
                {
                    uint uclr = GetPixel(hdc, e.X, e.Y);
                    Color cc = Color.FromArgb((int)uclr);
                    Color clr = Color.FromArgb(cc.B, cc.G, cc.R);
                    Point ttloc = new Point(e.X, e.Y - 15);
                    if (clr.ToArgb() == Color.DarkOrange.ToArgb()) toolTip.Show("Vorlauf (warm) Netzleitung (°C)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Black.ToArgb()) toolTip.Show("Rücklauf Netzleitung (°C)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Maroon.ToArgb()) toolTip.Show("Vorlauf (heiß) Netzleitung (°C)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Red.ToArgb()) toolTip.Show("Erdsondenfeld Mitte (°C)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Purple.ToArgb()) toolTip.Show("Erdsondenfeld Rand (°C)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Fuchsia.ToArgb()) toolTip.Show("Wärmeverbrauch Heizung (kW)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.DeepPink.ToArgb()) toolTip.Show("Stromverbrauch Heizung (Wärmepumpe) (kW)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Olive.ToArgb()) toolTip.Show("Leistung Solarthermie (kW)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Navy.ToArgb()) toolTip.Show("Energiefluss Erdsondenfeld (kW)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Blue.ToArgb()) toolTip.Show("Außentemperatur (Wetterdaten) (°C)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Teal.ToArgb()) toolTip.Show("Volumenfluss im Leitungsnetz (l/s)", diagram, ttloc, 2000);
                    if (clr.ToArgb() == Color.Brown.ToArgb()) toolTip.Show("Energie im Erdsondenfeld (bezogen aud 10°C) (in MWh)", diagram, ttloc, 2000);
                }
            }
        }

        internal void ZoomPlus()
        {
            horizontalScale *= 2;
            horizontalOffset *= 2;
            if (dayMode && horizontalScale > 10)
            {
                dayMode = false;
                initialized = false;
            }
            diagram.Invalidate();
        }
        internal void ZoomMinus()
        {
            horizontalScale /= 2;
            if (horizontalScale < diagram.Width / 365.0f) horizontalScale = diagram.Width / 365.0f;
            horizontalOffset /= 2;
            horizontalOffset = Math.Max(Math.Min(0, horizontalOffset), diagram.Width - 365.0f * horizontalScale);
            if (!dayMode && horizontalScale < 10)
            {
                dayMode = true;
                initialized = false;
            }
            diagram.Invalidate();
        }

        internal void OnMouseDown(MouseEventArgs e)
        {
            mouseDownPosX = e.X;
        }
        internal void OnMouseUp(MouseEventArgs e)
        {

        }
    }
}
