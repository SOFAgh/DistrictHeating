using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DistrictHeating
{
    public partial class DistrictHeating : Form
    {
        public Plant Plant { get; set; } = new Plant();
        private PaintDiagram paintDiagram;
        public DistrictHeating()
        {
            InitializeComponent();
            AddInfoButtons();
            paintDiagram = new PaintDiagram(graphicsPanel, panelLeft, panelRight, timeScale, toolTipDiagram, Plant);
            string[] stations = Climate.GetChoises();
            for (int i = 0; i < stations.Length; i++)
            {
                weatherStaionsList.Items.Add(stations[i]);
            }
            SetPlantData();
        }
        private void AddInfoButtons()
        {
            // Assuming 'tabControl' is the name of your TabControl
            TabControl? tabControl = this.Controls["tabMain"] as TabControl;

            if (tabControl != null)
            {
                foreach (TabPage? page in tabControl.TabPages)
                {
                    if (page == null) continue;
                    foreach (Control? control in page.Controls)
                    {
                        if (control == null) continue;
                        // Check if the control is a TextBox and has a non-empty Tag property
                        string? info = HelpInfo.Item(control.Name);
                        if (!string.IsNullOrEmpty(info))
                        {
                            Button infoButton = new Button
                            {
                                Text = "?",
                                Width = 20,
                                Height = control.Height,
                                Location = new System.Drawing.Point(control.Location.X + control.Width + 5, control.Location.Y)
                            };
                            infoButton.Tag = control;
                            infoButton.Click += InfoButton_Click;
                            page.Controls.Add(infoButton);
                        }
                    }
                }
            }
        }

        private void InfoButton_Click(object? sender, EventArgs e)
        {
            Button? infoButton = sender as Button;
            // Assuming the TextBox is directly next to the button
            if (infoButton == null) return;
            // Traverse parent controls to find the corresponding TextBox
            TabPage? tabPage = infoButton.Parent as TabPage;
            Control? tb = infoButton.Tag as Control;
            if (tb == null) return;
            string? info = HelpInfo.Item(tb.Name);
            if (info != null)
            {
                Label? label = FindLabelToLeft(tb);
                string title = label != null ? label.Text : tb.Text;
                InfoBox ib = new InfoBox(info, title, this.Width / 2, this.Height / 2);
                ib.ShowDialog();
            }
        }

        public static Label? FindLabelToLeft(Control control)
        {
            if (control.Parent == null)
                return null;

            foreach (Control? potentialLabel in control.Parent.Controls)
            {
                if (potentialLabel is Label)
                {
                    // Check if the label's right edge is just to the left of the control's left edge
                    bool isToLeft = (potentialLabel.Right < control.Left);
                    // Check if the label is vertically aligned with the control
                    bool isVerticallyAligned = (potentialLabel.Top < control.Bottom && potentialLabel.Bottom > control.Top);

                    if (isToLeft && isVerticallyAligned)
                    {
                        return (Label)potentialLabel;
                    }
                }
            }

            return null;
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
                Plant.StartSimulation(delegate (int d)
                {
                    progressBar.Value = d;
                    int hi = Plant.CurrentHourIndex;
                    if (hi % 24 == 0)
                    {
                        (int month, int day, int hour) = Climate.HourNumberToDate(hi);
                        currentDate.Text = "Datum: " + day.ToString() + "." + month.ToString() + ".";
                        currentDate.Refresh();
                    }
                });
                solarPercentage.Text = (Plant.solarPercentage * 100).ToString("F2") + "% ";
                electricityTotal.Text = Plant.electricityTotal.ToString("F2");
                heatProduced.Text = (Plant.heatProduced + Plant.electricityTotal).ToString("F2");
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
            netFlowTemperature.Text = (Plant.netFlowTemperature - Plant.ZeroK).ToString();
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
            boreHolePower.Text = Plant.BoreHoleField.TransferPower.ToString();
            boreholeTempFileName.Text = Plant.boreHoleTempFileName;

            // bufferStorage
            bufferStorageEnergyTransfer.Text = Plant.BufferStorage.EnergyTransfer.ToString();
            bufferStroageSize.Text = Plant.BufferStorage.Volume.ToString();
            bufferStorageInstances.Text = Plant.BufferStorage.NumberOfStorages.ToString();
            // solar
            solarFieldSize.Text = Plant.SolarThermalCollector.Area.ToString();
            solarEfficiency.Text = Plant.SolarThermalCollector.Efficiency.ToString();
            // concentrator
            pvPeak.Text = (Plant.ConcentratingHeatPump.PeakPower / 1000).ToString(); // W -> kW
            cHeatPumpPower.Text = (Plant.ConcentratingHeatPump.HeatPumpPower / 1000).ToString();
            batteryCapacity.Text = (Plant.ConcentratingHeatPump.BatteryCapacity / 1000).ToString();
            useConcentrator.Checked = Plant.BoreHoleField.useConcentratingHeatPump;
            // heating
            energyPerYear.Text = (Plant.Heating.EnergyConsumptionPerYear / 3600 / 1000000).ToString(); // J -> MWh
            hotWaterPercentage.Text = Plant.Heating.percentageHotWater.ToString();
            heatPumpEfficiency.Text = Plant.Heating.HeatPumpEfficiency.ToString();

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
            for (int i = 0; i < weatherStaionsList.Items.Count; i++)
            {
                if (weatherStaionsList.Items[i].ToString() == Plant.Climate.stationAndYear)
                {
                    weatherStaionsList.SelectedIndex = i;
                    break;
                }
            }
            weatherStaionsList_SelectedIndexChanged(weatherStaionsList, EventArgs.Empty);
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
            if (!double.TryParse(netFlowTemperature.Text, out Plant.netFlowTemperature)) return netFlowTemperature;
            Plant.netFlowTemperature += Plant.ZeroK;

            // boreHoleField
            if (int.TryParse(numBoreHoles.Text.Substring(numBoreHoles.Text.IndexOf('(') + 1, 2).Trim(), out int nb))
            {
                Plant.BoreHoleField = new BoreHoleField(nb, Plant.ZeroK + 10);
            }
            else return numBoreHoles;
            if (!double.TryParse(borHoleDistance.Text, out double bhdist)) return borHoleDistance;
            Plant.BoreHoleField.BoreHoleDistance = bhdist;
            if (!int.TryParse(numGrid.Text, out int grid)) return numGrid;
            if (!double.TryParse(boreHolePower.Text, out double transferPower)) return numGrid;
            Plant.BoreHoleField.TransferPower = transferPower;
            Plant.boreHoleTempFileName = boreholeTempFileName.Text;

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
            //// concentrator
            if (!double.TryParse(pvPeak.Text, out Plant.ConcentratingHeatPump.PeakPower)) return pvPeak;
            if (!double.TryParse(cHeatPumpPower.Text, out Plant.ConcentratingHeatPump.HeatPumpPower)) return cHeatPumpPower;
            if (!double.TryParse(batteryCapacity.Text, out Plant.ConcentratingHeatPump.BatteryCapacity)) return batteryCapacity;
            Plant.ConcentratingHeatPump.PeakPower *= 1000; // kW -> W
            Plant.ConcentratingHeatPump.HeatPumpPower *= 1000;
            Plant.ConcentratingHeatPump.BatteryCapacity *= 1000;
            Plant.BoreHoleField.useConcentratingHeatPump = useConcentrator.Checked;
            // heating
            if (!double.TryParse(energyPerYear.Text, out double ec)) return energyPerYear;
            Plant.Heating.EnergyConsumptionPerYear = ec * 3600 * 1000000; // MWh -> J
            if (!double.TryParse(hotWaterPercentage.Text, out double hw)) return hotWaterPercentage;
            Plant.Heating.percentageHotWater = hw;
            if (!double.TryParse(heatPumpEfficiency.Text, out double hpe)) return heatPumpEfficiency;
            Plant.Heating.HeatPumpEfficiency = hpe;

            Plant.Climate.LoadData(weatherStaionsList.SelectedItem.ToString());
            //// heating

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

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            paintDiagram.Paint();
        }

        private void warmPipe_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowWarmPipeTemperature = (sender as CheckBox).Checked;
        }

        private void returnPipe_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowReturnPipeTemperature = (sender as CheckBox).Checked;
        }

        private void hotPipe_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowHotPipeTemperature = (sender as CheckBox).Checked;
        }

        private void boreHoleCenter_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleTempCenter = (sender as CheckBox).Checked;
        }

        private void boreHoleBorder_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleTempBorder = (sender as CheckBox).Checked;
        }

        private void heatConsumption_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowHeatConsumption = (sender as CheckBox).Checked;
        }

        private void electricityConsumption_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowElectricityConsumption = (sender as CheckBox).Checked;
        }

        private void solarEnergy_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowSolarHeat = (sender as CheckBox).Checked;
        }

        private void boreHoleEnergyFlow_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBoreHoleEnergyFlow = (sender as CheckBox).Checked;
        }

        private void ambientTemperature_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowAmbientTemperature = (sender as CheckBox).Checked;
        }

        private void volumeFlow_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowVolumeFlow = (sender as CheckBox).Checked;
        }
        private void netLoss_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowNetLoss = (sender as CheckBox).Checked;
        }
        private void bufferEnergy_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBufferEnergy = (sender as CheckBox).Checked;
        }
        private void bufferTopTemperature_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBufferTopTemperature = (sender as CheckBox).Checked;
        }
        private void bufferBottomTemperature_CheckChanged(object sender, EventArgs e)
        {
            paintDiagram.ShowBufferBottomTemperature = (sender as CheckBox).Checked;
        }

        private void boreHoleEnergy_CheckChanged(object sender, EventArgs e)
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

        private void saveImage_Click(object sender, EventArgs e)
        {
            paintDiagram.saveImage();
        }

        private void debug_Click(object sender, EventArgs e)
        {
            //BoreHoleFieldOld bhf = new BoreHoleFieldOld(1, Plant.ZeroK + 10);
            //bhf.BoreHoleDistance = 5.2;
            //bhf.Grid = 6;
            //bhf.Initialize();
            //bhf.InitializeNew(6);
            //bhf.SomeDebugCode();
            //bhf.TransferEnergieTest(0.1 / 1000, 363.15, out double outTemp, 300);
            Plant.SaveData("");
        }

        private void saveSimulationData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName))
                {
                    outputFile.Write("Stunde, Datum");
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
                        int hournum = Plant.startSimulationHour + i;
                        (int month, int day, int hour) = Climate.HourNumberToDate(hournum);
                        outputFile.Write(hournum.ToString() + ", +" + day.ToString() + "." + month.ToString() + ". " + hour.ToString() + " Uhr");
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

        private void selectBoreholeTempFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                boreholeTempFileName.Text = saveFileDialog.FileName;
            }
        }

        private void weatherStaionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weatherStaionsList != null)
            {
                string? selected = weatherStaionsList.SelectedItem as string;
                if (selected != null)
                {
                    Cursor oldCursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    Plant.Climate.LoadData(selected);
                    weatherData.Items.Clear();
                    weatherData.Items.Add("Datum\t\tTemperatur\tGlobalstrahlung\tDiffuse Strahlung");
                    for (int i = 0; i < Plant.Climate.Temperature.Length; ++i)
                    {
                        (int month, int day, int hour) = Climate.HourNumberToDate(i);
                        string line = day.ToString("D2") + "." + month.ToString("D2") + ". " + hour.ToString("D2") + " Uhr\t" + Plant.Climate.Temperature[i].ToString("F1")
                            + "°\t\t" + Plant.Climate.GlobalSolarRadiation[i].ToString("F1") + "\t\t" + Plant.Climate.DiffuseRadiation[i].ToString("F1");
                        weatherData.Items.Add(line);
                    }
                    Cursor.Current = oldCursor;
                }
            }
        }

        private void savePlant_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                GetPlantData();
                Plant.SaveData(saveFileDialog.FileName);
            }

        }

        private void openPlant_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Plant = Plant.ReadData(openFileDialog.FileName);
                SetPlantData();
            }
        }

    }
}