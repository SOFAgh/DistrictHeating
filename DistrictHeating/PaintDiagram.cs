using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        Plant plant;

        float horLineDiff; // distance of the horizontal lines
        double celsiusOffset = 0.0, celsiusFactor = 0.0; // factor for calculatung pixel in Y-direction from degree C*celsiusFactor+celsiusOffset, if 0, no tempertaure in the diagram
        double kWhOffset = 0.0, kWhFactor = 0.0; // same with kWh
        double kWOffset = 0.0, kWFactor = 0.0; // same with kW
        double literPerSecondOffset = 0.0, literPerSecondFactor = 0.0; // same with l/s (volume flow)
        bool invalidated = false;
        public PaintDiagram(Panel diagram, Panel left, Panel right, Plant plant)
        {
            this.diagram = diagram;
            this.left = left;
            this.right = right;
            this.plant = plant;

            horLineDiff = diagram.Height / 13; // hardcoded 12 horizontal lines
            showWarmPipeTemp = true;
            showBoreHoleEnergy = true;
            showHeatConsumption = true;
            showElectricityConsumption = true;
            invalidated = true;
        }


        bool showReturnPipeTemperature = false;
        bool ShowReturnPipeTemperature { get { return showReturnPipeTemperature; } set { showReturnPipeTemperature = value; invalidated = true; } }
        bool showWarmPipeTemp = false;
        bool ShowWarmPipeTemperature { get { return showWarmPipeTemp; } set { showWarmPipeTemp = value; invalidated = true; } }
        bool showHotPipeTemp = false;
        bool ShowHotPipeTemperature { get { return showHotPipeTemp; } set { showHotPipeTemp = value; invalidated = true; } }
        bool showAmbientTemperature = false;
        bool ShowAmbientTemperature { get { return showAmbientTemperature; } set { showAmbientTemperature = value; invalidated = true; } }
        bool showBoreHoleEnergy = false;
        bool ShowBoreHoleEnergy { get { return showBoreHoleEnergy; } set { showBoreHoleEnergy = value; invalidated = true; } }
        bool showBoreHoleTempBorder = false;
        bool ShowBoreHoleTempBorder { get { return showBoreHoleTempBorder; } set { showBoreHoleTempBorder = value; invalidated = true; } }
        bool showBoreHoleTempCenter = false;
        bool ShowBoreHoleTempCenter { get { return showBoreHoleTempCenter; } set { showBoreHoleTempCenter = value; invalidated = true; } }
        bool showBoreHoleEnergyFlow = false;
        bool ShowBoreHoleEnergyFlow { get { return showBoreHoleEnergyFlow; } set { showBoreHoleEnergyFlow = value; invalidated = true; } }
        bool showHeatConsumption = false;
        bool ShowHeatConsumption { get { return showHeatConsumption; } set { showHeatConsumption = value; invalidated = true; } }
        bool showElectricityConsumption = false;
        bool ShowElectricityConsumption { get { return showElectricityConsumption; } set { showElectricityConsumption = value; invalidated = true; } }
        bool showSolarHeat = false;
        bool ShowSolarHeat { get { return showSolarHeat; } set { showSolarHeat = value; invalidated = true; } }
        bool showVolumeFlow = false;
        bool ShowVolumeFlow { get { return showVolumeFlow; } set { showVolumeFlow = value; invalidated = true; } }

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
                        toDrawOn.DrawString(val.ToString() + suffix1, SystemFonts.DefaultFont, Brushes.Red, new PointF(left.Width / 2.0f, HorLinePosition(i)), centerFormat);
                    }
                    else
                    {
                        int val1 = lowestValue1 + i * step1;
                        int val2 = lowestValue2 + i * step2;
                        toDrawOn.DrawString(val1.ToString() + suffix1 + "\n" + val2.ToString() + suffix2, SystemFonts.DefaultFont, Brushes.Red, new PointF(left.Width / 2.0f, HorLinePosition(i)), centerFormat);
                    }
                }
            }
        }

        private void calcDisplay()
        {
            // calculate the minima and maxima for all units
            Dictionary<string, double> unitMinValue = new Dictionary<string, double>();
            Dictionary<string, double> unitMaxValue = new Dictionary<string, double>();
            HashSet<string> names = new HashSet<string>();
            int minSeconds = int.MaxValue, maxSeconds = int.MinValue;
            foreach (Plant.DiagramEntry item in plant.Diagrams)
            {
                if (!unitMinValue.TryGetValue(item.unit, out double val)) unitMinValue[item.unit] = item.val;
                else unitMinValue[item.unit] = Math.Min(item.val, unitMinValue[item.unit]);
                if (!unitMaxValue.TryGetValue(item.unit, out val)) unitMaxValue[item.unit] = item.val;
                else unitMaxValue[item.unit] = Math.Max(item.val, unitMaxValue[item.unit]);
                minSeconds = Math.Min(item.timeStamp, minSeconds);
                maxSeconds = Math.Max(item.timeStamp, maxSeconds);
                names.Add(item.name);
            }
            Dictionary<string, double> unitFactor = new Dictionary<string, double>();
            Dictionary<string, double> unitOffset = new Dictionary<string, double>();
            Dictionary<string, int> unitStart = new Dictionary<string, int>();
            Dictionary<string, int> unitStep = new Dictionary<string, int>();
            foreach (string unit in unitMinValue.Keys)
            {
                if (unitMinValue[unit] < unitMaxValue[unit])
                {
                    Scale(unitMinValue[unit], unitMaxValue[unit], out int start, out int step, out double factor, out double offset);
                    unitOffset[unit] = offset;
                    unitFactor[unit] = factor;
                    unitStart[unit] = start;
                    unitStep[unit] = step;
                }
            }
            int l1start = 0, l1step = 0, l2start = 0, l2step = 0;
            int r1start = 0, r1step = 0, r2start = 0, r2step = 0;
            string l1unit = null, l2unit = null, r1unit = null, r2unit = null;
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

            float horScale = diagram.Width / 365.0f;
            Dictionary<string, List<PointF>> paths = new Dictionary<string, List<PointF>>();
            Dictionary<string, float> sum = new Dictionary<string, float>();
            Dictionary<string, int> num = new Dictionary<string, int>();
            Dictionary<string, int> currentDay = new Dictionary<string, int>();

            for (int i = 0; i < plant.Diagrams.Count; i++)
            {
                if (!sum.ContainsKey(plant.Diagrams[i].name))
                {
                    sum[plant.Diagrams[i].name] = 0.0f;
                    num[plant.Diagrams[i].name] = 0;
                    currentDay[plant.Diagrams[i].name] = 0;
                    paths[plant.Diagrams[i].name] = new List<PointF>();
                }
                if (plant.Diagrams[i].timeStamp / (3600 * 24) != currentDay[plant.Diagrams[i].name])
                {
                    float val = sum[plant.Diagrams[i].name] / num[plant.Diagrams[i].name];
                    paths[plant.Diagrams[i].name].Add(new PointF(currentDay[plant.Diagrams[i].name] * horScale, (float)(val * unitFactor[plant.Diagrams[i].unit] + unitOffset[plant.Diagrams[i].unit])));
                    currentDay[plant.Diagrams[i].name] = plant.Diagrams[i].timeStamp / (3600 * 24);
                    sum[plant.Diagrams[i].name] = 0.0f;
                    num[plant.Diagrams[i].name] = 0;
                }
                else 
                {
                    sum[plant.Diagrams[i].name] += (float)plant.Diagrams[i].val;
                    num[plant.Diagrams[i].name] += 1;
                }
            }
            using (Graphics grDiagram = diagram.CreateGraphics())
            {
                grDiagram.Clear(Color.White);
                for (int i = 0; i < 12; i++)
                {
                    grDiagram.DrawLine(Pens.LightGray, 0, HorLinePosition(i), diagram.Width, HorLinePosition(i));
                }
                //foreach (string name in paths.Keys)
                {
                    grDiagram.DrawCurve(Pens.Red, paths["warmPipe"].ToArray());
                    grDiagram.DrawCurve(Pens.Green, paths["ambientTemperature"].ToArray());
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

        private void Scale(double min, double max, out int start, out int step, out double factor, out double offset)
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
            lowest += step;
            highest -= step;
            factor = -(double)diagram.Height / (double)(highest - lowest);
            offset = diagram.Height - lowest * celsiusFactor;
            start = lowest;
        }

        private void MinMax(ref double min, ref double max, double v)
        {
            if (v < min) min = v;
            if (v > max) max = v;
        }

        public void Paint()
        {
            if (invalidated) calcDisplay();
            //using (Graphics grDiagram = diagram.CreateGraphics())
            //{
            //    grDiagram.Clear(Color.White);
            //    for (int i = 0; i < 12; i++)
            //    {
            //        grDiagram.DrawLine(Pens.LightGray, 0, HorLinePosition(i), diagram.Width, HorLinePosition(i));
            //    }
            //    ShowScale(true, 0, -20, 100, "°C");
            //}
        }
    }
}
