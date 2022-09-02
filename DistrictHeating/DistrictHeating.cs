using System;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace DistrictHeating
{
    public partial class DistrictHeating : Form
    {
        public Plant Plant { get; set; } = new Plant();
        private int HeatingNameIndex;
        public DistrictHeating()
        {
            InitializeComponent();
            SetPlantData();
        }

        private void readTemperatureData_Click(object sender, EventArgs e)
        {
            openTemperaturFile.Filter = "txt Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";
            openTemperaturFile.FilterIndex = 2;
            openTemperaturFile.RestoreDirectory = true;
            if (DialogResult.OK == openTemperaturFile.ShowDialog())
            {
                Dictionary<int, double[]> yearToTemp = new Dictionary<int, double[]>();
                var fileStream = openTemperaturFile.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {

                }
            }
        }

        private void startSimulation_Click(object sender, EventArgs e)
        {
            // Plant.CheckSolarHeatConsitency();
            // Plant.CheckBoreHoleFieldAndSolarConsistency();
            Control? ctrl = GetPlantData();
            if (ctrl == null) Plant.StartSimulation();
            else ctrl?.Focus();
        }
        private void SetPlantData()
        {
            // plant
            pipelineLength.Text = Plant.PiplineLength.ToString("#");
            pipeDiameter.Text = (Plant.PipeDiameter * 1000).ToString("#"); // mm to m
            insulationLambda.Text = Plant.InsulationLambda.ToString();
            pipeInsulationDiameter.Text = (Plant.PipeInsulationDiameter * 1000).ToString();
            numConnections.Text = Plant.NumConnections.ToString();
            // boreHoleField
            for (int i = 0; i < numBoreHoles.Items.Count; i++)
            {
                numBoreHoles.SelectedIndex = 0;
                if (numBoreHoles.Items[i].ToString().StartsWith(Plant.BoreHoleField.NumberOfBoreHoles.ToString()))
                {
                    numBoreHoles.SelectedIndex = i;
                    break;
                }
            }
            borHoleDistance.Text = Plant.BoreHoleField.Distance.ToString();
            boreHoleLength.Text = Plant.BoreHoleField.Length.ToString();
            groundHeatCapacity.Text = Plant.BoreHoleField.HeatCapacity.ToString();
            groundLambda.Text = Plant.BoreHoleField.Lambda.ToString();
            startCenterTemperature.Text = (Plant.BoreHoleField.startBoreholeFieldCenterTemperature - Plant.ZeroK).ToString();
            startBorderTemperature.Text = (Plant.BoreHoleField.startBoreholeFieldBorderTemperature - Plant.ZeroK).ToString();
            // bufferStorage
            bufferStorageEnergyTransfer.Text = Plant.BufferStorage.EnergyTransfer.ToString();
            bufferStroageSize.Text = Plant.BufferStorage.Volume.ToString();
            bufferStorageInstances.Text = Plant.BufferStorage.NumberOfStorages.ToString();
            // solar
            solarFieldSize.Text = Plant.SolarThermalCollector.Area.ToString();
            solarEfficiency.Text = Plant.SolarThermalCollector.Efficiency.ToString();
            // heating
            SetHeatingNameData(0);
        }
        public Control? GetPlantData()
        {
            // plant
            if (!double.TryParse(pipelineLength.Text, out Plant.PiplineLength)) return pipelineLength;
            if (!double.TryParse(pipeDiameter.Text, out Plant.PipeDiameter)) return pipeDiameter;
            Plant.PipeDiameter /= 1000;
            if (!double.TryParse(insulationLambda.Text, out Plant.InsulationLambda)) return insulationLambda;
            if (!double.TryParse(pipeInsulationDiameter.Text, out Plant.PipeInsulationDiameter)) return pipeInsulationDiameter;
            Plant.PipeInsulationDiameter /= 1000;
            if (!int.TryParse(numConnections.Text, out Plant.NumConnections)) return numConnections;
            // boreHoleField
            // TODO: Anzahl der Bohrlöcher veränderbar machen!!!
            //for (int i = 0; i < numBoreHoles.Items.Count; i++)
            //{
            //    numBoreHoles.SelectedIndex = 0;
            //    if (numBoreHoles.Items[i].ToString().StartsWith(Plant.BoreHoleField.NumberOfBoreHoles.ToString()))
            //    {
            //        numBoreHoles.SelectedIndex = i;
            //        break;
            //    }
            //}
            //borHoleDistance.Text = Plant.BoreHoleField.Distance.ToString();
            //boreHoleLength.Text = Plant.BoreHoleField.Length.ToString();
            //groundHeatCapacity.Text = Plant.BoreHoleField.HeatCapacity.ToString();
            //groundLambda.Text = Plant.BoreHoleField.Lambda.ToString();
            if (!double.TryParse(startCenterTemperature.Text, out Plant.BoreHoleField.startBoreholeFieldCenterTemperature)) return startCenterTemperature;
            Plant.BoreHoleField.startBoreholeFieldCenterTemperature += Plant.ZeroK;
            if (!double.TryParse(startBorderTemperature.Text, out Plant.BoreHoleField.startBoreholeFieldBorderTemperature)) return startBorderTemperature;
            Plant.BoreHoleField.startBoreholeFieldBorderTemperature += Plant.ZeroK;
            //// bufferStorage
            //bufferStorageEnergyTransfer.Text = Plant.BufferStorage.EnergyTransfer.ToString();
            //bufferStroageSize.Text = Plant.BufferStorage.Volume.ToString();
            //bufferStorageInstances.Text = Plant.BufferStorage.NumberOfStorages.ToString();
            //// solar
            //solarFieldSize.Text = Plant.SolarThermalCollector.Area.ToString();
            //solarEfficiency.Text = Plant.SolarThermalCollector.Efficiency.ToString();
            //// heating

            GetHeatingNameData(HeatingName.SelectedIndex);
            return null;
        }
        private void SetHeatingNameData(int indexToSelect)
        {
            HeatingName.Items.Clear();
            for (int i = 0; i < Plant.Heating.Count; i++)
            {
                HeatingName.Items.Add(Plant.Heating[i].Name);
            }
            HeatingName.Items.Add("--- neuer Eintrag ---");

            HeatingName.SelectedIndex = indexToSelect;
        }

        private void HeatingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HeatingNameIndex != HeatingName.SelectedIndex) GetHeatingNameData(HeatingNameIndex);
            HeatingNameIndex = HeatingName.SelectedIndex;
            if ("--- neuer Eintrag ---" == HeatingName.GetItemText(HeatingName.SelectedItem))
            {
                HeatingConsumer n = HeatingConsumer.RadiatorHeating;
                n.Name = "Bezeichnung";
                Plant.Heating.Add(n);
                SetHeatingNameData(0);
                int ind = HeatingName.FindString(n.Name);
                HeatingName.SelectedIndex = ind;
            }
            for (int i = 0; i < Plant.Heating.Count; i++)
            {
                if (Plant.Heating[i].Name == HeatingName.GetItemText(HeatingName.SelectedItem))
                {
                    energyPerYear.Text = (Plant.Heating[i].EnergyConsumptionPerYear / 3600 / 1000).ToString("#");
                    vl20.Text = Plant.Heating[i].SupplyTemp[0].ToString();
                    vl15.Text = Plant.Heating[i].SupplyTemp[1].ToString();
                    vl10.Text = Plant.Heating[i].SupplyTemp[2].ToString();
                    vl5.Text = Plant.Heating[i].SupplyTemp[3].ToString();
                    vl0.Text = Plant.Heating[i].SupplyTemp[4].ToString();
                    vlm5.Text = Plant.Heating[i].SupplyTemp[5].ToString();
                    vlm10.Text = Plant.Heating[i].SupplyTemp[6].ToString();
                    vlm15.Text = Plant.Heating[i].SupplyTemp[7].ToString();
                    vlm20.Text = Plant.Heating[i].SupplyTemp[8].ToString();
                    dayTemperature.Text = Plant.Heating[i].DayTemperature.ToString("#");
                    nightTemperature.Text = Plant.Heating[i].NightTemperature.ToString("#");
                    beginDayTime.Text = Plant.Heating[i].DayStartHour.ToString("#");
                    endDayTime.Text = Plant.Heating[i].DayEndHour.ToString("#");
                    heatPumpEfficiency.Text = (Plant.Heating[i].HeatPumpEfficiency * 100).ToString("#");
                    instanceNumber.Text = Plant.Heating[i].NumberOfInstances.ToString("#");
                    break;
                }
            }
        }
        private void GetHeatingNameData(int index)
        {
            if (index >= 0 && index < Plant.Heating.Count)
            {
                if (double.TryParse(energyPerYear.Text, out double epy)) Plant.Heating[index].EnergyConsumptionPerYear = epy * 3600 * 1000;
                double.TryParse(vl20.Text, out Plant.Heating[index].SupplyTemp[0]);
                double.TryParse(vl15.Text, out Plant.Heating[index].SupplyTemp[1]);
                double.TryParse(vl10.Text, out Plant.Heating[index].SupplyTemp[2]);
                double.TryParse(vl5.Text, out Plant.Heating[index].SupplyTemp[3]);
                double.TryParse(vl0.Text, out Plant.Heating[index].SupplyTemp[4]);
                double.TryParse(vlm5.Text, out Plant.Heating[index].SupplyTemp[5]);
                double.TryParse(vlm10.Text, out Plant.Heating[index].SupplyTemp[6]);
                double.TryParse(vlm15.Text, out Plant.Heating[index].SupplyTemp[7]);
                double.TryParse(vlm20.Text, out Plant.Heating[index].SupplyTemp[8]);
                if (double.TryParse(dayTemperature.Text, out double dyt)) Plant.Heating[index].DayTemperature = dyt;
                if (double.TryParse(nightTemperature.Text, out double nt)) Plant.Heating[index].NightTemperature = nt;
                if (int.TryParse(beginDayTime.Text, out int dsh)) Plant.Heating[index].DayStartHour = dsh;
                if (int.TryParse(endDayTime.Text, out int deh)) Plant.Heating[index].DayEndHour = deh;
                if (double.TryParse(heatPumpEfficiency.Text, out double hpe)) Plant.Heating[index].HeatPumpEfficiency = hpe / 100;
                if (int.TryParse(instanceNumber.Text, out int noi)) Plant.Heating[index].NumberOfInstances = noi;
            }
        }

        private void HeatingName_TextUpdate(object sender, EventArgs e)
        {
            string txt = HeatingName.Text;
            Plant.Heating[HeatingNameIndex].Name = txt;
        }

        private void HeatingName_Leave(object sender, EventArgs e)
        {
            SetHeatingNameData(HeatingNameIndex);
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            Graphics gLeft = panelLeft.CreateGraphics();
            Graphics gRight = panelRight.CreateGraphics();

            g.FillRectangle(new SolidBrush(Color.LightYellow), p.DisplayRectangle);

            double tempMin = double.MaxValue;
            double tempMax = double.MinValue;
            for (int i = 0; i < Plant.heatConsumptionPerHour.Count; i++)
            {
                tempMin = Math.Min(tempMin, Plant.returnPipeTempPerHour[i]);
                tempMax = Math.Max(tempMax, Plant.returnPipeTempPerHour[i]);
                tempMin = Math.Min(tempMin, Plant.warmPipeTempPerHour[i]);
                tempMax = Math.Max(tempMax, Plant.warmPipeTempPerHour[i]);
                tempMin = Math.Min(tempMin, Plant.hotPipeTempPerHour[i]);
                tempMax = Math.Max(tempMax, Plant.hotPipeTempPerHour[i]);
                tempMin = Math.Min(tempMin, Plant.boreHoleTempBorderPerHour[i]);
                tempMax = Math.Max(tempMax, Plant.boreHoleTempBorderPerHour[i]);
                tempMin = Math.Min(tempMin, Plant.boreHoleTempCenterPerHour[i]);
                tempMax = Math.Max(tempMax, Plant.boreHoleTempCenterPerHour[i]);
            }
            Pen penBlack = new Pen(new SolidBrush(Color.Black), 1);

            int horLineDiff = p.Height / 13;
            for (int i = 0; i < 12; i++)
            {
                g.DrawLine(penBlack, 0, (i + 1) * horLineDiff, p.Width, (i + 1) * horLineDiff);
                gLeft.DrawString(i.ToString(),)
            }
            //Matrix transformMatrix = new Matrix();
            //List<PointF> pHeat = new List<PointF>();
            //List<PointF> pElectr = new List<PointF>();
            //float max = 0;
            //for (int i = 0; i < Plant.heatConsumptionPerHour.Count; i++)
            //{
            //    float b = (float)(Plant.heatConsumptionPerHour[i] / 1e7);
            //    pHeat.Add(new PointF(i, b));
            //    max = Math.Max(max, b);
            //    b = (float)(Plant.electricityConsumptionPerHour[i] / 1e7);
            //    pElectr.Add(new PointF(i, b));
            //    max = Math.Max(max, b);
            //}
            //max *= 1.2f;
            //transformMatrix = new Matrix(p.DisplayRectangle.Width / (float)(Plant.heatConsumptionPerHour.Count), 0, 0, -p.DisplayRectangle.Height / max, 0, p.DisplayRectangle.Height);
            //g.Transform = transformMatrix;
            //Brush brush = new SolidBrush(Color.Blue);
            //Pen penHeat = new Pen(brush, 2);
            //Pen penElectr = new Pen(new SolidBrush(Color.Green), 2);
            //g.DrawCurve(penHeat, pHeat.ToArray());
            //g.DrawCurve(penElectr, pElectr.ToArray());
        }
    }
}