using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace DistrictHeating
{
    public partial class DistrictHeating : Form
    {
        public Plant Plant { get; set; } = new Plant();
        private int HeatingNameIndex;
        private PaintDiagram paintDiagram;
        public DistrictHeating()
        {
            InitializeComponent();
            paintDiagram = new PaintDiagram(graphicsPanel, panelLeft, panelRight, timeScale, toolTipDiagram, Plant);
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
            if (ctrl == null)
            {
                Plant.StartSimulation(delegate (int d) { progressBar.Value = d; });
                solarPercentage.Text = (Plant.solarPercentage * 100).ToString("F2") + "% ";
                electricityTotal.Text = Plant.electricityTotal.ToString("F2");
                heatProduced.Text = Plant.heatProduced.ToString("F2");
                solarTotal.Text = Plant.solarTotal.ToString("F2");
                boreHoleRemoved.Text = Plant.boreHoleRemoved.ToString("F2");
                boreHoleAdded.Text = Plant.boreHoleAdded.ToString("F2");
            }
            else ctrl?.Focus();
        }
        private void SetPlantData()
        {
            // plant
            pipelineLength.Text = Plant.Pipeline.length.ToString("#");
            pipeDiameter.Text = (Plant.Pipeline.innerDiameter * 1000).ToString("#"); // mm to m
            insulationLambda.Text = Plant.Pipeline.insulationLambda.ToString();
            pipeInsulationDiameter.Text = (Plant.Pipeline.outerDiameter * 1000).ToString();
            numConnections.Text = Plant.Pipeline.connections.ToString();
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
            borHoleDistance.Text = Plant.BoreHoleField.BoreHoleDistance.ToString();
            boreHoleLength.Text = Plant.BoreHoleField.Length.ToString();
            groundHeatCapacity.Text = Plant.BoreHoleField.HeatCapacity.ToString();
            groundLambda.Text = Plant.BoreHoleField.Lambda.ToString();
            startCenterTemperature.Text = (Plant.BoreHoleField.startBoreholeFieldCenterTemperature - Plant.ZeroK).ToString();
            startBorderTemperature.Text = (Plant.BoreHoleField.startBoreholeFieldBorderTemperature - Plant.ZeroK).ToString();
            startDate.Text = Plant.GetStartTime();
            timeStep.Text = Plant.TimeStep.ToString();
            numYears.Text = Plant.NumYears.ToString();
            numGrid.Text = Plant.BoreHoleField.Grid.ToString();
            // bufferStorage
            bufferStorageEnergyTransfer.Text = Plant.BufferStorage.EnergyTransfer.ToString();
            bufferStroageSize.Text = Plant.BufferStorage.Volume.ToString();
            bufferStorageInstances.Text = Plant.BufferStorage.NumberOfStorages.ToString();
            // solar
            solarFieldSize.Text = Plant.SolarThermalCollector.Area.ToString();
            solarEfficiency.Text = Plant.SolarThermalCollector.Efficiency.ToString();
            // heating
            SetHeatingNameData(0);
            returnPipe.Checked = paintDiagram.ShowReturnPipeTemperature;
            warmPipe.Checked = paintDiagram.ShowWarmPipeTemperature;
            hotPipe.Checked = paintDiagram.ShowHotPipeTemperature;
            boreHoleCenter.Checked = paintDiagram.ShowBoreHoleTempCenter;
            boreHoleBorder.Checked = paintDiagram.ShowBoreHoleTempBorder;
            heatConsumption.Checked = paintDiagram.ShowHeatConsumption;
            electricityConsumption.Checked = paintDiagram.ShowElectricityConsumption;
            solarEnergy.Checked = paintDiagram.ShowSolarHeat;
            boreHoleEnergyFlow.Checked = paintDiagram.ShowBoreHoleEnergyFlow;
            ambientTemperature.Checked = paintDiagram.ShowAmbientTemperature;
            volumeFlow.Checked = paintDiagram.ShowVolumeFlow;
            netLoss.Checked = paintDiagram.ShowNetLoss;
            boreHoleEnergy.Checked = paintDiagram.ShowBoreHoleEnergy;

        }
        public Control? GetPlantData()
        {
            // plant
            if (!double.TryParse(pipelineLength.Text, out Plant.Pipeline.length)) return pipelineLength;
            if (!double.TryParse(pipeDiameter.Text, out Plant.Pipeline.innerDiameter)) return pipeDiameter;
            Plant.Pipeline.innerDiameter /= 1000;
            if (!double.TryParse(insulationLambda.Text, out Plant.Pipeline.insulationLambda)) return insulationLambda;
            if (!double.TryParse(pipeInsulationDiameter.Text, out Plant.Pipeline.outerDiameter)) return pipeInsulationDiameter;
            Plant.Pipeline.outerDiameter /= 1000;
            if (!int.TryParse(numConnections.Text, out Plant.Pipeline.connections)) return numConnections;
            // boreHoleField
            // TODO: Anzahl der Bohrlöcher veränderbar machen!!!
            if (int.TryParse(numBoreHoles.Text.Substring(numBoreHoles.Text.IndexOf('(') + 1, 2).Trim(), out int nb))
            {
                Plant.BoreHoleField = new BoreHoleField(nb, Plant.ZeroK + 10);
            }
            else return numBoreHoles;
            if (!double.TryParse(borHoleDistance.Text, out double bhdist)) return borHoleDistance;
            Plant.BoreHoleField.BoreHoleDistance = bhdist;
            if (!int.TryParse(numGrid.Text, out int grid)) return numGrid;
            if (grid > 1 && grid < 50) Plant.BoreHoleField.Grid = grid; ;
            if (!double.TryParse(boreHoleLength.Text, out Plant.BoreHoleField.Length)) return boreHoleLength;
            if (!double.TryParse(groundHeatCapacity.Text, out Plant.BoreHoleField.HeatCapacity)) return groundHeatCapacity;
            if (!double.TryParse(groundLambda.Text, out Plant.BoreHoleField.Lambda)) return groundLambda;
            if (!double.TryParse(startCenterTemperature.Text, out Plant.BoreHoleField.startBoreholeFieldCenterTemperature)) return startCenterTemperature;
            string[] dateParts = startDate.Text.Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (dateParts.Length == 2)
            {
                Plant.SetStartTime(dateParts[0], dateParts[1]);
            }
            if (!double.TryParse(numYears.Text, out double ny)) return numYears;
            Plant.NumYears = ny;
            if (!int.TryParse(timeStep.Text, out int ts)) return timeStep;
            Plant.TimeStep = ts;

            Plant.BoreHoleField.startBoreholeFieldCenterTemperature += Plant.ZeroK;
            if (!double.TryParse(startBorderTemperature.Text, out Plant.BoreHoleField.startBoreholeFieldBorderTemperature)) return startBorderTemperature;
            Plant.BoreHoleField.startBoreholeFieldBorderTemperature += Plant.ZeroK;
            //// bufferStorage
            if (!double.TryParse(bufferStorageEnergyTransfer.Text, out Plant.BufferStorage.EnergyTransfer)) return bufferStorageEnergyTransfer;
            if (!double.TryParse(bufferStroageSize.Text, out Plant.BufferStorage.Volume)) return bufferStroageSize;
            if (!int.TryParse(bufferStorageInstances.Text, out Plant.BufferStorage.NumberOfStorages)) return bufferStorageInstances;
            //// solar
            if (!double.TryParse(solarFieldSize.Text, out Plant.SolarThermalCollector.Area)) return solarFieldSize;
            if (!double.TryParse(solarEfficiency.Text, out Plant.SolarThermalCollector.Efficiency)) return solarEfficiency;
            //// heating

            GetHeatingNameData(HeatingName.SelectedIndex);
            paintDiagram.ShowReturnPipeTemperature = returnPipe.Checked;
            paintDiagram.ShowWarmPipeTemperature = warmPipe.Checked;
            paintDiagram.ShowHotPipeTemperature = hotPipe.Checked;
            paintDiagram.ShowBoreHoleTempCenter = boreHoleCenter.Checked;
            paintDiagram.ShowBoreHoleTempBorder = boreHoleBorder.Checked;
            paintDiagram.ShowHeatConsumption = heatConsumption.Checked;
            paintDiagram.ShowElectricityConsumption = electricityConsumption.Checked;
            paintDiagram.ShowSolarHeat = solarEnergy.Checked;
            paintDiagram.ShowBoreHoleEnergyFlow = boreHoleEnergyFlow.Checked;
            paintDiagram.ShowAmbientTemperature = ambientTemperature.Checked;
            paintDiagram.ShowVolumeFlow = volumeFlow.Checked;
            paintDiagram.ShowNetLoss = netLoss.Checked;
            paintDiagram.ShowBoreHoleEnergy = boreHoleEnergy.Checked;
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
            paintDiagram.Paint();
        }

        private void warmPipe_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowWarmPipeTemperature = (sender as CheckBox).Checked;
        }

        private void returnPipe_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowReturnPipeTemperature = (sender as CheckBox).Checked;
        }

        private void hotPipe_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowHotPipeTemperature = (sender as CheckBox).Checked;
        }

        private void boreHoleCenter_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleTempCenter = (sender as CheckBox).Checked;
        }

        private void boreHoleBorder_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleTempBorder = (sender as CheckBox).Checked;
        }

        private void heatConsumption_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowHeatConsumption = (sender as CheckBox).Checked;
        }

        private void electricityConsumption_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowElectricityConsumption = (sender as CheckBox).Checked;
        }

        private void solarEnergy_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowSolarHeat = (sender as CheckBox).Checked;
        }

        private void boreHoleEnergyFlow_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleEnergyFlow = (sender as CheckBox).Checked;
        }

        private void ambientTemperature_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowAmbientTemperature = (sender as CheckBox).Checked;
        }

        private void volumeFlow_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowVolumeFlow = (sender as CheckBox).Checked;
        }
        private void netLoss_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowNetLoss = (sender as CheckBox).Checked;
        }
        private void bufferEnergy_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBufferEnergy = (sender as CheckBox).Checked;
        }
        private void bufferTopTemperature_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBufferTopTemperature = (sender as CheckBox).Checked;
        }
        private void bufferBottomTemperature_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBufferBottomTemperature = (sender as CheckBox).Checked;
        }

        private void boreHoleEnergy_CheckedChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleEnergy = (sender as CheckBox).Checked;
        }

        private void graphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel)
            {
                paintDiagram.OnMouseMove(e);
            }
        }

        private void zoomPlus_Click(object sender, EventArgs e)
        {
            paintDiagram.ZoomPlus();
        }

        private void zoomMinus_Click(object sender, EventArgs e)
        {
            paintDiagram.ZoomMinus();
        }

        private void graphicsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            paintDiagram.OnMouseDown(e);
        }

        private void graphicsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            paintDiagram.OnMouseUp(e);
        }

        private void boreHoleFieldDisplay_Paint(object sender, PaintEventArgs e)
        {
            Plant.BoreHoleField.Paint(sender as Panel);
        }

        private void graphicsPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = graphicsPanel.PointToScreen(e.Location);
                contextMenuSaveImage.Show(p.X, p.Y);
            }

        }

        private void contextMenuSaveImage_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            paintDiagram.saveImage();
        }

        private void debug_Click(object sender, EventArgs e)
        {
            BoreHoleFieldOld bhf = new BoreHoleFieldOld(1, Plant.ZeroK + 10);
            bhf.BoreHoleDistance = 5.2;
            bhf.Grid = 6;
            bhf.Initialize();
            bhf.InitializeNew(6);
            bhf.SomeDebugCode();
            bhf.TransferEnergieTest(0.1 / 1000, 363.15, out double outTemp, 300);
        }

        private void saveSimulationData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName))
                {
                    outputFile.Write("Stunde");
                    int maxLength = 0;
                    List<string> columns = new List<string>();
                    foreach (string column in Plant.Diagrams.Keys)
                    {
                        outputFile.Write(", " + column);
                        maxLength = Math.Max(maxLength, Plant.Diagrams[column].Count);
                        columns.Add(column);
                    }
                    outputFile.WriteLine();
                    for (int i = 0; i < maxLength; i++)
                    {
                        outputFile.Write(i.ToString());
                        for (int j = 0; j < columns.Count; j++)
                        {
                            List<Plant.DiagramEntry> l = Plant.Diagrams[columns[j]];
                            double val;
                            if (l.Count == maxLength) val = l[i].val;
                            else val = l[i / 24].val;
                            outputFile.Write(", " + val.ToString("F2", CultureInfo.InvariantCulture));
                        }
                        outputFile.WriteLine();
                    }
                }
            }
        }
    }
}