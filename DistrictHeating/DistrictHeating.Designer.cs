using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistrictHeating
{
    partial class DistrictHeating
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label label32;
            System.Windows.Forms.Label label33;
            System.Windows.Forms.Label label34;
            System.Windows.Forms.Label label35;
            System.Windows.Forms.Label label36;
            System.Windows.Forms.Label label37;
            System.Windows.Forms.Label label38;
            System.Windows.Forms.Label label39;
            System.Windows.Forms.Label label40;
            System.Windows.Forms.Label label41;
            this.tabPlant = new System.Windows.Forms.TabPage();
            this.threePipes = new System.Windows.Forms.RadioButton();
            this.twoPipes = new System.Windows.Forms.RadioButton();
            this.numConnections = new System.Windows.Forms.TextBox();
            this.insulationLambda = new System.Windows.Forms.TextBox();
            this.pipeInsulationDiameter = new System.Windows.Forms.TextBox();
            this.pipeDiameter = new System.Windows.Forms.TextBox();
            this.pipelineLength = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBHTES = new System.Windows.Forms.TabPage();
            this.groundHeatCapacity = new System.Windows.Forms.TextBox();
            this.groundLambda = new System.Windows.Forms.TextBox();
            this.borHoleDistance = new System.Windows.Forms.TextBox();
            this.boreHoleLength = new System.Windows.Forms.TextBox();
            this.numBoreHoles = new System.Windows.Forms.ComboBox();
            this.tabBufferStorage = new System.Windows.Forms.TabPage();
            this.bufferStorageInstances = new System.Windows.Forms.TextBox();
            this.bufferStorageEnergyTransfer = new System.Windows.Forms.TextBox();
            this.bufferStroageSize = new System.Windows.Forms.TextBox();
            this.tabSolar = new System.Windows.Forms.TabPage();
            this.solarEfficiency = new System.Windows.Forms.TextBox();
            this.solarFieldSize = new System.Windows.Forms.TextBox();
            this.tabConsumer = new System.Windows.Forms.TabPage();
            this.vlm20 = new System.Windows.Forms.TextBox();
            this.vlm15 = new System.Windows.Forms.TextBox();
            this.vlm10 = new System.Windows.Forms.TextBox();
            this.vlm5 = new System.Windows.Forms.TextBox();
            this.vl0 = new System.Windows.Forms.TextBox();
            this.vl5 = new System.Windows.Forms.TextBox();
            this.vl10 = new System.Windows.Forms.TextBox();
            this.vl15 = new System.Windows.Forms.TextBox();
            this.vl20 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.HeatingName = new System.Windows.Forms.ComboBox();
            this.instanceNumber = new System.Windows.Forms.TextBox();
            this.heatPumpEfficiency = new System.Windows.Forms.TextBox();
            this.endDayTime = new System.Windows.Forms.TextBox();
            this.beginDayTime = new System.Windows.Forms.TextBox();
            this.nightTemperature = new System.Windows.Forms.TextBox();
            this.dayTemperature = new System.Windows.Forms.TextBox();
            this.energyPerYear = new System.Windows.Forms.TextBox();
            this.tabWether = new System.Windows.Forms.TabPage();
            this.saveTemperatureData = new System.Windows.Forms.Button();
            this.readTemperatureData = new System.Windows.Forms.Button();
            this.wetherData = new System.Windows.Forms.ListBox();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startBorderTemperature = new System.Windows.Forms.TextBox();
            this.startCenterTemperature = new System.Windows.Forms.TextBox();
            this.startSimulation = new System.Windows.Forms.Button();
            this.tabGraphics = new System.Windows.Forms.TabPage();
            this.zoomMinus = new System.Windows.Forms.Button();
            this.zoomPlus = new System.Windows.Forms.Button();
            this.timeScale = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.graphicsPanel = new System.Windows.Forms.Panel();
            this.legend = new System.Windows.Forms.TabPage();
            this.warmPipe = new System.Windows.Forms.CheckBox();
            this.returnPipe = new System.Windows.Forms.CheckBox();
            this.hotPipe = new System.Windows.Forms.CheckBox();
            this.boreHoleCenter = new System.Windows.Forms.CheckBox();
            this.boreHoleBorder = new System.Windows.Forms.CheckBox();
            this.heatConsumption = new System.Windows.Forms.CheckBox();
            this.electricityConsumption = new System.Windows.Forms.CheckBox();
            this.solarEnergy = new System.Windows.Forms.CheckBox();
            this.boreHoleEnergyFlow = new System.Windows.Forms.CheckBox();
            this.ambientTemperature = new System.Windows.Forms.CheckBox();
            this.volumeFlow = new System.Windows.Forms.CheckBox();
            this.boreHoleEnergy = new System.Windows.Forms.CheckBox();
            this.openTemperaturFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTipDiagram = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boreHoleAdded = new System.Windows.Forms.TextBox();
            this.boreHoleRemoved = new System.Windows.Forms.TextBox();
            this.solarTotal = new System.Windows.Forms.TextBox();
            this.heatProduced = new System.Windows.Forms.TextBox();
            this.electricityTotal = new System.Windows.Forms.TextBox();
            this.solarPercentage = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            label39 = new System.Windows.Forms.Label();
            label40 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            this.tabPlant.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBHTES.SuspendLayout();
            this.tabBufferStorage.SuspendLayout();
            this.tabSolar.SuspendLayout();
            this.tabConsumer.SuspendLayout();
            this.tabWether.SuspendLayout();
            this.tabSimulation.SuspendLayout();
            this.tabGraphics.SuspendLayout();
            this.legend.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(6, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(320, 15);
            label1.TabIndex = 0;
            label1.Text = "Gesamtlänge des Nahwärmenetzes (m):";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(6, 63);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(320, 15);
            label2.TabIndex = 2;
            label2.Text = "Anzahl der Sonden:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(6, 92);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(320, 15);
            label3.TabIndex = 5;
            label3.Text = "Bohrtiefe (m):";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(6, 121);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(320, 15);
            label4.TabIndex = 5;
            label4.Text = "Abstand der Sonden (m):";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(6, 150);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(320, 15);
            label5.TabIndex = 5;
            label5.Text = "Wärmeleitfähigkeit des Erdreichs (W/(m·K)):";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(6, 179);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(320, 15);
            label6.TabIndex = 5;
            label6.Text = "Wärmekapazität (J/(m³·K)):";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(6, 64);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(320, 15);
            label7.TabIndex = 0;
            label7.Text = "Durchmesser der Rohre (mm):";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(9, 47);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(320, 15);
            label8.TabIndex = 2;
            label8.Text = "Jahresverbrauch (MWh):";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(10, 18);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(320, 15);
            label9.TabIndex = 2;
            label9.Text = "Art der Heizung:";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Location = new System.Drawing.Point(9, 91);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(320, 15);
            label19.TabIndex = 2;
            label19.Text = "Vorlauftemperatur bei Außentemperatur:";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            label20.Location = new System.Drawing.Point(9, 120);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(320, 15);
            label20.TabIndex = 2;
            label20.Text = "gewünschte Tagestemperatur (°C):";
            label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            label21.Location = new System.Drawing.Point(6, 93);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(320, 15);
            label21.TabIndex = 0;
            label21.Text = "Außendurchmesser Dämmung (mm):";
            label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            label22.Location = new System.Drawing.Point(6, 122);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(320, 15);
            label22.TabIndex = 0;
            label22.Text = "Wärmeleitfähigkeit Dämmung (W/(m*K)):";
            label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            label23.Location = new System.Drawing.Point(6, 151);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(320, 15);
            label23.TabIndex = 0;
            label23.Text = "Anzahl der Hausanschlüsse:";
            label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            label24.Location = new System.Drawing.Point(9, 149);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(320, 15);
            label24.TabIndex = 2;
            label24.Text = "gewünschte Nachttemperatur (°C):";
            label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            label25.Location = new System.Drawing.Point(9, 178);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(320, 15);
            label25.TabIndex = 2;
            label25.Text = "Anfang Tagestemperatur (Uhrzeit, Stunde):";
            label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            label26.Location = new System.Drawing.Point(9, 207);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(320, 15);
            label26.TabIndex = 2;
            label26.Text = "Ende Tagestemperatur (Uhrzeit, Stunde):";
            label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            label27.Location = new System.Drawing.Point(9, 236);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(320, 15);
            label27.TabIndex = 2;
            label27.Text = "Gütegrad der Wärmepumpe in %";
            label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            label28.Location = new System.Drawing.Point(9, 265);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(320, 15);
            label28.TabIndex = 2;
            label28.Text = "Anzahl dieser Heizungen im System:";
            label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            label29.Location = new System.Drawing.Point(6, 45);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(320, 15);
            label29.TabIndex = 2;
            label29.Text = "Größe des Speichers (in m³):";
            label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            label30.Location = new System.Drawing.Point(6, 74);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(320, 15);
            label30.TabIndex = 2;
            label30.Text = "Leistungsübertragung Wärmetauscher (in W/K):";
            label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            label31.Location = new System.Drawing.Point(6, 103);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(320, 15);
            label31.TabIndex = 2;
            label31.Text = "Anzahl der Pufferspeicher im System:";
            label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            label32.Location = new System.Drawing.Point(6, 38);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(320, 15);
            label32.TabIndex = 4;
            label32.Text = "Größe des Solarthermie-Felds (in m²):";
            label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            label33.Location = new System.Drawing.Point(6, 67);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(320, 15);
            label33.TabIndex = 4;
            label33.Text = "Wirkungsgrad Solarthermie (in %):";
            label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            label34.Location = new System.Drawing.Point(6, 38);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(320, 15);
            label34.TabIndex = 6;
            label34.Text = "Anfangstemperatur in der Mitte des Speichers (in °C): ";
            label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            label35.Location = new System.Drawing.Point(6, 67);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(320, 15);
            label35.TabIndex = 6;
            label35.Text = "Anfangstemperatur am Rand des Speichers (in °C): ";
            label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPlant
            // 
            this.tabPlant.Controls.Add(this.threePipes);
            this.tabPlant.Controls.Add(this.twoPipes);
            this.tabPlant.Controls.Add(this.numConnections);
            this.tabPlant.Controls.Add(label23);
            this.tabPlant.Controls.Add(this.insulationLambda);
            this.tabPlant.Controls.Add(label22);
            this.tabPlant.Controls.Add(this.pipeInsulationDiameter);
            this.tabPlant.Controls.Add(label21);
            this.tabPlant.Controls.Add(this.pipeDiameter);
            this.tabPlant.Controls.Add(label7);
            this.tabPlant.Controls.Add(this.pipelineLength);
            this.tabPlant.Controls.Add(label1);
            this.tabPlant.Location = new System.Drawing.Point(4, 24);
            this.tabPlant.Name = "tabPlant";
            this.tabPlant.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlant.Size = new System.Drawing.Size(1033, 590);
            this.tabPlant.TabIndex = 3;
            this.tabPlant.Text = "Anlage";
            this.tabPlant.UseVisualStyleBackColor = true;
            // 
            // threePipes
            // 
            this.threePipes.AutoSize = true;
            this.threePipes.Location = new System.Drawing.Point(333, 202);
            this.threePipes.Name = "threePipes";
            this.threePipes.Size = new System.Drawing.Size(87, 19);
            this.threePipes.TabIndex = 2;
            this.threePipes.TabStop = true;
            this.threePipes.Text = "3 Leitungen";
            this.threePipes.UseVisualStyleBackColor = true;
            // 
            // twoPipes
            // 
            this.twoPipes.AutoSize = true;
            this.twoPipes.Location = new System.Drawing.Point(333, 177);
            this.twoPipes.Name = "twoPipes";
            this.twoPipes.Size = new System.Drawing.Size(87, 19);
            this.twoPipes.TabIndex = 2;
            this.twoPipes.TabStop = true;
            this.twoPipes.Text = "2 Leitungen";
            this.twoPipes.UseVisualStyleBackColor = true;
            // 
            // numConnections
            // 
            this.numConnections.Location = new System.Drawing.Point(333, 148);
            this.numConnections.Name = "numConnections";
            this.numConnections.Size = new System.Drawing.Size(100, 23);
            this.numConnections.TabIndex = 1;
            // 
            // insulationLambda
            // 
            this.insulationLambda.Location = new System.Drawing.Point(333, 119);
            this.insulationLambda.Name = "insulationLambda";
            this.insulationLambda.Size = new System.Drawing.Size(100, 23);
            this.insulationLambda.TabIndex = 1;
            // 
            // pipeInsulationDiameter
            // 
            this.pipeInsulationDiameter.Location = new System.Drawing.Point(333, 90);
            this.pipeInsulationDiameter.Name = "pipeInsulationDiameter";
            this.pipeInsulationDiameter.Size = new System.Drawing.Size(100, 23);
            this.pipeInsulationDiameter.TabIndex = 1;
            // 
            // pipeDiameter
            // 
            this.pipeDiameter.Location = new System.Drawing.Point(333, 61);
            this.pipeDiameter.Name = "pipeDiameter";
            this.pipeDiameter.Size = new System.Drawing.Size(100, 23);
            this.pipeDiameter.TabIndex = 1;
            // 
            // pipelineLength
            // 
            this.pipelineLength.Location = new System.Drawing.Point(333, 32);
            this.pipelineLength.Name = "pipelineLength";
            this.pipelineLength.Size = new System.Drawing.Size(100, 23);
            this.pipelineLength.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPlant);
            this.tabMain.Controls.Add(this.tabBHTES);
            this.tabMain.Controls.Add(this.tabBufferStorage);
            this.tabMain.Controls.Add(this.tabSolar);
            this.tabMain.Controls.Add(this.tabConsumer);
            this.tabMain.Controls.Add(this.tabWether);
            this.tabMain.Controls.Add(this.tabSimulation);
            this.tabMain.Controls.Add(this.tabGraphics);
            this.tabMain.Controls.Add(this.legend);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1041, 618);
            this.tabMain.TabIndex = 0;
            // 
            // tabBHTES
            // 
            this.tabBHTES.Controls.Add(this.groundHeatCapacity);
            this.tabBHTES.Controls.Add(label6);
            this.tabBHTES.Controls.Add(this.groundLambda);
            this.tabBHTES.Controls.Add(label5);
            this.tabBHTES.Controls.Add(this.borHoleDistance);
            this.tabBHTES.Controls.Add(label4);
            this.tabBHTES.Controls.Add(this.boreHoleLength);
            this.tabBHTES.Controls.Add(label3);
            this.tabBHTES.Controls.Add(this.numBoreHoles);
            this.tabBHTES.Controls.Add(label2);
            this.tabBHTES.Location = new System.Drawing.Point(4, 24);
            this.tabBHTES.Name = "tabBHTES";
            this.tabBHTES.Padding = new System.Windows.Forms.Padding(3);
            this.tabBHTES.Size = new System.Drawing.Size(1033, 590);
            this.tabBHTES.TabIndex = 0;
            this.tabBHTES.Text = "Erdsondenspeicher";
            this.tabBHTES.UseVisualStyleBackColor = true;
            // 
            // groundHeatCapacity
            // 
            this.groundHeatCapacity.Location = new System.Drawing.Point(332, 176);
            this.groundHeatCapacity.Name = "groundHeatCapacity";
            this.groundHeatCapacity.Size = new System.Drawing.Size(100, 23);
            this.groundHeatCapacity.TabIndex = 6;
            // 
            // groundLambda
            // 
            this.groundLambda.Location = new System.Drawing.Point(332, 147);
            this.groundLambda.Name = "groundLambda";
            this.groundLambda.Size = new System.Drawing.Size(100, 23);
            this.groundLambda.TabIndex = 6;
            // 
            // borHoleDistance
            // 
            this.borHoleDistance.Location = new System.Drawing.Point(332, 118);
            this.borHoleDistance.Name = "borHoleDistance";
            this.borHoleDistance.Size = new System.Drawing.Size(100, 23);
            this.borHoleDistance.TabIndex = 6;
            // 
            // boreHoleLength
            // 
            this.boreHoleLength.Location = new System.Drawing.Point(332, 89);
            this.boreHoleLength.Name = "boreHoleLength";
            this.boreHoleLength.Size = new System.Drawing.Size(100, 23);
            this.boreHoleLength.TabIndex = 6;
            // 
            // numBoreHoles
            // 
            this.numBoreHoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numBoreHoles.FormattingEnabled = true;
            this.numBoreHoles.Items.AddRange(new object[] {
            "7 (einfach)",
            "19 (2 Ringe)",
            "37 (3 Ringe)",
            "61 (4 Ringe)",
            "91 (5 Ringe)",
            "127 (6 Ringe)",
            "169 (7 Ringe)"});
            this.numBoreHoles.Location = new System.Drawing.Point(332, 60);
            this.numBoreHoles.Name = "numBoreHoles";
            this.numBoreHoles.Size = new System.Drawing.Size(189, 23);
            this.numBoreHoles.TabIndex = 4;
            // 
            // tabBufferStorage
            // 
            this.tabBufferStorage.Controls.Add(this.bufferStorageInstances);
            this.tabBufferStorage.Controls.Add(label31);
            this.tabBufferStorage.Controls.Add(this.bufferStorageEnergyTransfer);
            this.tabBufferStorage.Controls.Add(label30);
            this.tabBufferStorage.Controls.Add(this.bufferStroageSize);
            this.tabBufferStorage.Controls.Add(label29);
            this.tabBufferStorage.Location = new System.Drawing.Point(4, 24);
            this.tabBufferStorage.Name = "tabBufferStorage";
            this.tabBufferStorage.Padding = new System.Windows.Forms.Padding(3);
            this.tabBufferStorage.Size = new System.Drawing.Size(1033, 590);
            this.tabBufferStorage.TabIndex = 7;
            this.tabBufferStorage.Text = "Pufferspeicher";
            this.tabBufferStorage.UseVisualStyleBackColor = true;
            // 
            // bufferStorageInstances
            // 
            this.bufferStorageInstances.Location = new System.Drawing.Point(333, 100);
            this.bufferStorageInstances.Name = "bufferStorageInstances";
            this.bufferStorageInstances.Size = new System.Drawing.Size(100, 23);
            this.bufferStorageInstances.TabIndex = 3;
            // 
            // bufferStorageEnergyTransfer
            // 
            this.bufferStorageEnergyTransfer.Location = new System.Drawing.Point(333, 71);
            this.bufferStorageEnergyTransfer.Name = "bufferStorageEnergyTransfer";
            this.bufferStorageEnergyTransfer.Size = new System.Drawing.Size(100, 23);
            this.bufferStorageEnergyTransfer.TabIndex = 3;
            // 
            // bufferStroageSize
            // 
            this.bufferStroageSize.Location = new System.Drawing.Point(333, 42);
            this.bufferStroageSize.Name = "bufferStroageSize";
            this.bufferStroageSize.Size = new System.Drawing.Size(100, 23);
            this.bufferStroageSize.TabIndex = 3;
            // 
            // tabSolar
            // 
            this.tabSolar.Controls.Add(this.solarEfficiency);
            this.tabSolar.Controls.Add(label33);
            this.tabSolar.Controls.Add(this.solarFieldSize);
            this.tabSolar.Controls.Add(label32);
            this.tabSolar.Location = new System.Drawing.Point(4, 24);
            this.tabSolar.Name = "tabSolar";
            this.tabSolar.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolar.Size = new System.Drawing.Size(1033, 590);
            this.tabSolar.TabIndex = 1;
            this.tabSolar.Text = "Solarthermie";
            this.tabSolar.UseVisualStyleBackColor = true;
            // 
            // solarEfficiency
            // 
            this.solarEfficiency.Location = new System.Drawing.Point(333, 64);
            this.solarEfficiency.Name = "solarEfficiency";
            this.solarEfficiency.Size = new System.Drawing.Size(100, 23);
            this.solarEfficiency.TabIndex = 5;
            // 
            // solarFieldSize
            // 
            this.solarFieldSize.Location = new System.Drawing.Point(333, 35);
            this.solarFieldSize.Name = "solarFieldSize";
            this.solarFieldSize.Size = new System.Drawing.Size(100, 23);
            this.solarFieldSize.TabIndex = 5;
            // 
            // tabConsumer
            // 
            this.tabConsumer.Controls.Add(this.vlm20);
            this.tabConsumer.Controls.Add(this.vlm15);
            this.tabConsumer.Controls.Add(this.vlm10);
            this.tabConsumer.Controls.Add(this.vlm5);
            this.tabConsumer.Controls.Add(this.vl0);
            this.tabConsumer.Controls.Add(this.vl5);
            this.tabConsumer.Controls.Add(this.vl10);
            this.tabConsumer.Controls.Add(this.vl15);
            this.tabConsumer.Controls.Add(this.vl20);
            this.tabConsumer.Controls.Add(this.label18);
            this.tabConsumer.Controls.Add(this.label17);
            this.tabConsumer.Controls.Add(this.label16);
            this.tabConsumer.Controls.Add(this.label15);
            this.tabConsumer.Controls.Add(this.label14);
            this.tabConsumer.Controls.Add(this.label13);
            this.tabConsumer.Controls.Add(this.label12);
            this.tabConsumer.Controls.Add(this.label11);
            this.tabConsumer.Controls.Add(this.label10);
            this.tabConsumer.Controls.Add(this.HeatingName);
            this.tabConsumer.Controls.Add(this.instanceNumber);
            this.tabConsumer.Controls.Add(this.heatPumpEfficiency);
            this.tabConsumer.Controls.Add(this.endDayTime);
            this.tabConsumer.Controls.Add(label28);
            this.tabConsumer.Controls.Add(this.beginDayTime);
            this.tabConsumer.Controls.Add(label27);
            this.tabConsumer.Controls.Add(this.nightTemperature);
            this.tabConsumer.Controls.Add(label26);
            this.tabConsumer.Controls.Add(this.dayTemperature);
            this.tabConsumer.Controls.Add(label25);
            this.tabConsumer.Controls.Add(this.energyPerYear);
            this.tabConsumer.Controls.Add(label24);
            this.tabConsumer.Controls.Add(label9);
            this.tabConsumer.Controls.Add(label20);
            this.tabConsumer.Controls.Add(label19);
            this.tabConsumer.Controls.Add(label8);
            this.tabConsumer.Location = new System.Drawing.Point(4, 24);
            this.tabConsumer.Name = "tabConsumer";
            this.tabConsumer.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsumer.Size = new System.Drawing.Size(1033, 590);
            this.tabConsumer.TabIndex = 6;
            this.tabConsumer.Text = "Verbraucher";
            this.tabConsumer.UseVisualStyleBackColor = true;
            // 
            // vlm20
            // 
            this.vlm20.Location = new System.Drawing.Point(576, 88);
            this.vlm20.Name = "vlm20";
            this.vlm20.Size = new System.Drawing.Size(24, 23);
            this.vlm20.TabIndex = 6;
            // 
            // vlm15
            // 
            this.vlm15.Location = new System.Drawing.Point(546, 88);
            this.vlm15.Name = "vlm15";
            this.vlm15.Size = new System.Drawing.Size(24, 23);
            this.vlm15.TabIndex = 6;
            // 
            // vlm10
            // 
            this.vlm10.Location = new System.Drawing.Point(516, 88);
            this.vlm10.Name = "vlm10";
            this.vlm10.Size = new System.Drawing.Size(24, 23);
            this.vlm10.TabIndex = 6;
            // 
            // vlm5
            // 
            this.vlm5.Location = new System.Drawing.Point(486, 88);
            this.vlm5.Name = "vlm5";
            this.vlm5.Size = new System.Drawing.Size(24, 23);
            this.vlm5.TabIndex = 6;
            // 
            // vl0
            // 
            this.vl0.Location = new System.Drawing.Point(456, 88);
            this.vl0.Name = "vl0";
            this.vl0.Size = new System.Drawing.Size(24, 23);
            this.vl0.TabIndex = 6;
            // 
            // vl5
            // 
            this.vl5.Location = new System.Drawing.Point(426, 88);
            this.vl5.Name = "vl5";
            this.vl5.Size = new System.Drawing.Size(24, 23);
            this.vl5.TabIndex = 6;
            // 
            // vl10
            // 
            this.vl10.Location = new System.Drawing.Point(396, 88);
            this.vl10.Name = "vl10";
            this.vl10.Size = new System.Drawing.Size(24, 23);
            this.vl10.TabIndex = 6;
            // 
            // vl15
            // 
            this.vl15.Location = new System.Drawing.Point(366, 88);
            this.vl15.Name = "vl15";
            this.vl15.Size = new System.Drawing.Size(24, 23);
            this.vl15.TabIndex = 6;
            // 
            // vl20
            // 
            this.vl20.Location = new System.Drawing.Point(336, 88);
            this.vl20.Name = "vl20";
            this.vl20.Size = new System.Drawing.Size(24, 23);
            this.vl20.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(576, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 15);
            this.label18.TabIndex = 5;
            this.label18.Text = "-20°";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(546, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 15);
            this.label17.TabIndex = 5;
            this.label17.Text = "-15°";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(516, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 15);
            this.label16.TabIndex = 5;
            this.label16.Text = "-10°";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(486, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 15);
            this.label15.TabIndex = 5;
            this.label15.Text = "-5°";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(456, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "0°";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(426, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "5°";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(396, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "10°";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(366, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "15°";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "20°";
            // 
            // HeatingName
            // 
            this.HeatingName.FormattingEnabled = true;
            this.HeatingName.Location = new System.Drawing.Point(336, 15);
            this.HeatingName.Name = "HeatingName";
            this.HeatingName.Size = new System.Drawing.Size(121, 23);
            this.HeatingName.TabIndex = 4;
            this.HeatingName.SelectedIndexChanged += new System.EventHandler(this.HeatingName_SelectedIndexChanged);
            this.HeatingName.TextUpdate += new System.EventHandler(this.HeatingName_TextUpdate);
            this.HeatingName.Leave += new System.EventHandler(this.HeatingName_Leave);
            // 
            // instanceNumber
            // 
            this.instanceNumber.Location = new System.Drawing.Point(336, 262);
            this.instanceNumber.Name = "instanceNumber";
            this.instanceNumber.Size = new System.Drawing.Size(100, 23);
            this.instanceNumber.TabIndex = 3;
            // 
            // heatPumpEfficiency
            // 
            this.heatPumpEfficiency.Location = new System.Drawing.Point(336, 233);
            this.heatPumpEfficiency.Name = "heatPumpEfficiency";
            this.heatPumpEfficiency.Size = new System.Drawing.Size(100, 23);
            this.heatPumpEfficiency.TabIndex = 3;
            // 
            // endDayTime
            // 
            this.endDayTime.Location = new System.Drawing.Point(336, 204);
            this.endDayTime.Name = "endDayTime";
            this.endDayTime.Size = new System.Drawing.Size(100, 23);
            this.endDayTime.TabIndex = 3;
            // 
            // beginDayTime
            // 
            this.beginDayTime.Location = new System.Drawing.Point(336, 175);
            this.beginDayTime.Name = "beginDayTime";
            this.beginDayTime.Size = new System.Drawing.Size(100, 23);
            this.beginDayTime.TabIndex = 3;
            // 
            // nightTemperature
            // 
            this.nightTemperature.Location = new System.Drawing.Point(336, 146);
            this.nightTemperature.Name = "nightTemperature";
            this.nightTemperature.Size = new System.Drawing.Size(100, 23);
            this.nightTemperature.TabIndex = 3;
            // 
            // dayTemperature
            // 
            this.dayTemperature.Location = new System.Drawing.Point(336, 117);
            this.dayTemperature.Name = "dayTemperature";
            this.dayTemperature.Size = new System.Drawing.Size(100, 23);
            this.dayTemperature.TabIndex = 3;
            // 
            // energyPerYear
            // 
            this.energyPerYear.Location = new System.Drawing.Point(336, 44);
            this.energyPerYear.Name = "energyPerYear";
            this.energyPerYear.Size = new System.Drawing.Size(100, 23);
            this.energyPerYear.TabIndex = 3;
            // 
            // tabWether
            // 
            this.tabWether.Controls.Add(this.saveTemperatureData);
            this.tabWether.Controls.Add(this.readTemperatureData);
            this.tabWether.Controls.Add(this.wetherData);
            this.tabWether.Location = new System.Drawing.Point(4, 24);
            this.tabWether.Name = "tabWether";
            this.tabWether.Padding = new System.Windows.Forms.Padding(3);
            this.tabWether.Size = new System.Drawing.Size(1033, 590);
            this.tabWether.TabIndex = 2;
            this.tabWether.Text = "Wetterdaten";
            this.tabWether.UseVisualStyleBackColor = true;
            // 
            // saveTemperatureData
            // 
            this.saveTemperatureData.Location = new System.Drawing.Point(849, 6);
            this.saveTemperatureData.Name = "saveTemperatureData";
            this.saveTemperatureData.Size = new System.Drawing.Size(178, 23);
            this.saveTemperatureData.TabIndex = 1;
            this.saveTemperatureData.Text = "Temperaturdaten speichern";
            this.saveTemperatureData.UseVisualStyleBackColor = true;
            // 
            // readTemperatureData
            // 
            this.readTemperatureData.Location = new System.Drawing.Point(577, 6);
            this.readTemperatureData.Name = "readTemperatureData";
            this.readTemperatureData.Size = new System.Drawing.Size(178, 23);
            this.readTemperatureData.TabIndex = 1;
            this.readTemperatureData.Text = "Temperaturdaten lesen";
            this.readTemperatureData.UseVisualStyleBackColor = true;
            this.readTemperatureData.Click += new System.EventHandler(this.readTemperatureData_Click);
            // 
            // wetherData
            // 
            this.wetherData.FormattingEnabled = true;
            this.wetherData.ItemHeight = 15;
            this.wetherData.Location = new System.Drawing.Point(6, 6);
            this.wetherData.Name = "wetherData";
            this.wetherData.Size = new System.Drawing.Size(565, 574);
            this.wetherData.TabIndex = 0;
            // 
            // tabSimulation
            // 
            this.tabSimulation.Controls.Add(this.groupBox1);
            this.tabSimulation.Controls.Add(this.progressBar);
            this.tabSimulation.Controls.Add(this.startBorderTemperature);
            this.tabSimulation.Controls.Add(label35);
            this.tabSimulation.Controls.Add(this.startCenterTemperature);
            this.tabSimulation.Controls.Add(label34);
            this.tabSimulation.Controls.Add(this.startSimulation);
            this.tabSimulation.Location = new System.Drawing.Point(4, 24);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulation.Size = new System.Drawing.Size(1033, 590);
            this.tabSimulation.TabIndex = 4;
            this.tabSimulation.Text = "Simulation";
            this.tabSimulation.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 561);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(886, 23);
            this.progressBar.TabIndex = 8;
            // 
            // startBorderTemperature
            // 
            this.startBorderTemperature.Location = new System.Drawing.Point(333, 64);
            this.startBorderTemperature.Name = "startBorderTemperature";
            this.startBorderTemperature.Size = new System.Drawing.Size(100, 23);
            this.startBorderTemperature.TabIndex = 7;
            // 
            // startCenterTemperature
            // 
            this.startCenterTemperature.Location = new System.Drawing.Point(333, 35);
            this.startCenterTemperature.Name = "startCenterTemperature";
            this.startCenterTemperature.Size = new System.Drawing.Size(100, 23);
            this.startCenterTemperature.TabIndex = 7;
            // 
            // startSimulation
            // 
            this.startSimulation.Location = new System.Drawing.Point(898, 561);
            this.startSimulation.Name = "startSimulation";
            this.startSimulation.Size = new System.Drawing.Size(129, 23);
            this.startSimulation.TabIndex = 0;
            this.startSimulation.Text = "Simulation Starten";
            this.startSimulation.UseVisualStyleBackColor = true;
            this.startSimulation.Click += new System.EventHandler(this.startSimulation_Click);
            // 
            // tabGraphics
            // 
            this.tabGraphics.Controls.Add(this.zoomMinus);
            this.tabGraphics.Controls.Add(this.zoomPlus);
            this.tabGraphics.Controls.Add(this.timeScale);
            this.tabGraphics.Controls.Add(this.panelRight);
            this.tabGraphics.Controls.Add(this.panelLeft);
            this.tabGraphics.Controls.Add(this.graphicsPanel);
            this.tabGraphics.Location = new System.Drawing.Point(4, 24);
            this.tabGraphics.Name = "tabGraphics";
            this.tabGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphics.Size = new System.Drawing.Size(1033, 590);
            this.tabGraphics.TabIndex = 5;
            this.tabGraphics.Text = "Grafik";
            this.tabGraphics.UseVisualStyleBackColor = true;
            // 
            // zoomMinus
            // 
            this.zoomMinus.Location = new System.Drawing.Point(10, 551);
            this.zoomMinus.Name = "zoomMinus";
            this.zoomMinus.Size = new System.Drawing.Size(37, 33);
            this.zoomMinus.TabIndex = 3;
            this.zoomMinus.Text = "-";
            this.zoomMinus.UseVisualStyleBackColor = true;
            this.zoomMinus.Click += new System.EventHandler(this.zoomMinus_Click);
            // 
            // zoomPlus
            // 
            this.zoomPlus.Location = new System.Drawing.Point(990, 551);
            this.zoomPlus.Name = "zoomPlus";
            this.zoomPlus.Size = new System.Drawing.Size(37, 33);
            this.zoomPlus.TabIndex = 3;
            this.zoomPlus.Text = "+";
            this.zoomPlus.UseVisualStyleBackColor = true;
            this.zoomPlus.Click += new System.EventHandler(this.zoomPlus_Click);
            // 
            // timeScale
            // 
            this.timeScale.Location = new System.Drawing.Point(53, 551);
            this.timeScale.Name = "timeScale";
            this.timeScale.Size = new System.Drawing.Size(931, 33);
            this.timeScale.TabIndex = 2;
            // 
            // panelRight
            // 
            this.panelRight.Location = new System.Drawing.Point(990, 6);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(37, 539);
            this.panelRight.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Location = new System.Drawing.Point(6, 6);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(41, 539);
            this.panelLeft.TabIndex = 1;
            // 
            // graphicsPanel
            // 
            this.graphicsPanel.Location = new System.Drawing.Point(53, 6);
            this.graphicsPanel.Name = "graphicsPanel";
            this.graphicsPanel.Size = new System.Drawing.Size(931, 539);
            this.graphicsPanel.TabIndex = 0;
            this.graphicsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel_Paint);
            this.graphicsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel_MouseDown);
            this.graphicsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel_MouseMove);
            this.graphicsPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel_MouseUp);
            // 
            // legend
            // 
            this.legend.Controls.Add(this.warmPipe);
            this.legend.Controls.Add(this.returnPipe);
            this.legend.Controls.Add(this.hotPipe);
            this.legend.Controls.Add(this.boreHoleCenter);
            this.legend.Controls.Add(this.boreHoleBorder);
            this.legend.Controls.Add(this.heatConsumption);
            this.legend.Controls.Add(this.electricityConsumption);
            this.legend.Controls.Add(this.solarEnergy);
            this.legend.Controls.Add(this.boreHoleEnergyFlow);
            this.legend.Controls.Add(this.ambientTemperature);
            this.legend.Controls.Add(this.volumeFlow);
            this.legend.Controls.Add(this.boreHoleEnergy);
            this.legend.Location = new System.Drawing.Point(4, 24);
            this.legend.Name = "legend";
            this.legend.Padding = new System.Windows.Forms.Padding(3);
            this.legend.Size = new System.Drawing.Size(1033, 590);
            this.legend.TabIndex = 8;
            this.legend.Text = "Legende";
            this.legend.UseVisualStyleBackColor = true;
            // 
            // warmPipe
            // 
            this.warmPipe.AutoSize = true;
            this.warmPipe.ForeColor = System.Drawing.Color.DarkOrange;
            this.warmPipe.Location = new System.Drawing.Point(239, 74);
            this.warmPipe.Name = "warmPipe";
            this.warmPipe.Size = new System.Drawing.Size(192, 19);
            this.warmPipe.TabIndex = 0;
            this.warmPipe.Text = "Vorlauf (warm) Netzleitung (°C)";
            this.warmPipe.UseVisualStyleBackColor = true;
            this.warmPipe.CheckedChanged += new System.EventHandler(this.warmPipe_CheckedChanged);
            // 
            // returnPipe
            // 
            this.returnPipe.AutoSize = true;
            this.returnPipe.ForeColor = System.Drawing.Color.Black;
            this.returnPipe.Location = new System.Drawing.Point(239, 94);
            this.returnPipe.Name = "returnPipe";
            this.returnPipe.Size = new System.Drawing.Size(160, 19);
            this.returnPipe.TabIndex = 0;
            this.returnPipe.Text = "Rücklauf Netzleitung (°C)";
            this.returnPipe.UseVisualStyleBackColor = true;
            this.returnPipe.CheckedChanged += new System.EventHandler(this.returnPipe_CheckedChanged);
            // 
            // hotPipe
            // 
            this.hotPipe.AutoSize = true;
            this.hotPipe.ForeColor = System.Drawing.Color.Maroon;
            this.hotPipe.Location = new System.Drawing.Point(239, 114);
            this.hotPipe.Name = "hotPipe";
            this.hotPipe.Size = new System.Drawing.Size(185, 19);
            this.hotPipe.TabIndex = 0;
            this.hotPipe.Text = "Vorlauf (heiß) Netzleitung (°C)";
            this.hotPipe.UseVisualStyleBackColor = true;
            this.hotPipe.CheckedChanged += new System.EventHandler(this.hotPipe_CheckedChanged);
            // 
            // boreHoleCenter
            // 
            this.boreHoleCenter.AutoSize = true;
            this.boreHoleCenter.ForeColor = System.Drawing.Color.Red;
            this.boreHoleCenter.Location = new System.Drawing.Point(239, 134);
            this.boreHoleCenter.Name = "boreHoleCenter";
            this.boreHoleCenter.Size = new System.Drawing.Size(157, 19);
            this.boreHoleCenter.TabIndex = 0;
            this.boreHoleCenter.Text = "Erdsondenfeld Mitte (°C)";
            this.boreHoleCenter.UseVisualStyleBackColor = true;
            this.boreHoleCenter.CheckedChanged += new System.EventHandler(this.boreHoleCenter_CheckedChanged);
            // 
            // boreHoleBorder
            // 
            this.boreHoleBorder.AutoSize = true;
            this.boreHoleBorder.ForeColor = System.Drawing.Color.Purple;
            this.boreHoleBorder.Location = new System.Drawing.Point(239, 154);
            this.boreHoleBorder.Name = "boreHoleBorder";
            this.boreHoleBorder.Size = new System.Drawing.Size(156, 19);
            this.boreHoleBorder.TabIndex = 0;
            this.boreHoleBorder.Text = "Erdsondenfeld Rand (°C)";
            this.boreHoleBorder.UseVisualStyleBackColor = true;
            this.boreHoleBorder.CheckedChanged += new System.EventHandler(this.boreHoleBorder_CheckedChanged);
            // 
            // heatConsumption
            // 
            this.heatConsumption.AutoSize = true;
            this.heatConsumption.ForeColor = System.Drawing.Color.Fuchsia;
            this.heatConsumption.Location = new System.Drawing.Point(239, 174);
            this.heatConsumption.Name = "heatConsumption";
            this.heatConsumption.Size = new System.Drawing.Size(192, 19);
            this.heatConsumption.TabIndex = 0;
            this.heatConsumption.Text = "Wärmeverbrauch Heizung (kW)";
            this.heatConsumption.UseVisualStyleBackColor = true;
            this.heatConsumption.CheckedChanged += new System.EventHandler(this.heatConsumption_CheckedChanged);
            // 
            // electricityConsumption
            // 
            this.electricityConsumption.AutoSize = true;
            this.electricityConsumption.ForeColor = System.Drawing.Color.DeepPink;
            this.electricityConsumption.Location = new System.Drawing.Point(239, 194);
            this.electricityConsumption.Name = "electricityConsumption";
            this.electricityConsumption.Size = new System.Drawing.Size(273, 19);
            this.electricityConsumption.TabIndex = 0;
            this.electricityConsumption.Text = "Stromverbrauch Heizung (Wärmepumpe) (kW)";
            this.electricityConsumption.UseVisualStyleBackColor = true;
            this.electricityConsumption.CheckedChanged += new System.EventHandler(this.electricityConsumption_CheckedChanged);
            // 
            // solarEnergy
            // 
            this.solarEnergy.AutoSize = true;
            this.solarEnergy.ForeColor = System.Drawing.Color.Olive;
            this.solarEnergy.Location = new System.Drawing.Point(239, 214);
            this.solarEnergy.Name = "solarEnergy";
            this.solarEnergy.Size = new System.Drawing.Size(169, 19);
            this.solarEnergy.TabIndex = 0;
            this.solarEnergy.Text = "Leistung Solarthermie (kW)";
            this.solarEnergy.UseVisualStyleBackColor = true;
            this.solarEnergy.CheckedChanged += new System.EventHandler(this.solarEnergy_CheckedChanged);
            // 
            // boreHoleEnergyFlow
            // 
            this.boreHoleEnergyFlow.AutoSize = true;
            this.boreHoleEnergyFlow.ForeColor = System.Drawing.Color.Navy;
            this.boreHoleEnergyFlow.Location = new System.Drawing.Point(239, 234);
            this.boreHoleEnergyFlow.Name = "boreHoleEnergyFlow";
            this.boreHoleEnergyFlow.Size = new System.Drawing.Size(196, 19);
            this.boreHoleEnergyFlow.TabIndex = 0;
            this.boreHoleEnergyFlow.Text = "Energiefluss Erdsondenfeld (kW)";
            this.boreHoleEnergyFlow.UseVisualStyleBackColor = true;
            this.boreHoleEnergyFlow.CheckedChanged += new System.EventHandler(this.boreHoleEnergyFlow_CheckedChanged);
            // 
            // ambientTemperature
            // 
            this.ambientTemperature.AutoSize = true;
            this.ambientTemperature.ForeColor = System.Drawing.Color.Blue;
            this.ambientTemperature.Location = new System.Drawing.Point(239, 254);
            this.ambientTemperature.Name = "ambientTemperature";
            this.ambientTemperature.Size = new System.Drawing.Size(220, 19);
            this.ambientTemperature.TabIndex = 0;
            this.ambientTemperature.Text = "Außentemperatur (Wetterdaten) (°C)";
            this.ambientTemperature.UseVisualStyleBackColor = true;
            this.ambientTemperature.CheckedChanged += new System.EventHandler(this.ambientTemperature_CheckedChanged);
            // 
            // volumeFlow
            // 
            this.volumeFlow.AutoSize = true;
            this.volumeFlow.ForeColor = System.Drawing.Color.Teal;
            this.volumeFlow.Location = new System.Drawing.Point(239, 274);
            this.volumeFlow.Name = "volumeFlow";
            this.volumeFlow.Size = new System.Drawing.Size(208, 19);
            this.volumeFlow.TabIndex = 0;
            this.volumeFlow.Text = "Volumenfluss im Leitungsnetz (l/s)";
            this.volumeFlow.UseVisualStyleBackColor = true;
            this.volumeFlow.CheckedChanged += new System.EventHandler(this.volumeFlow_CheckedChanged);
            // 
            // boreHoleEnergy
            // 
            this.boreHoleEnergy.AutoSize = true;
            this.boreHoleEnergy.ForeColor = System.Drawing.Color.Brown;
            this.boreHoleEnergy.Location = new System.Drawing.Point(239, 294);
            this.boreHoleEnergy.Name = "boreHoleEnergy";
            this.boreHoleEnergy.Size = new System.Drawing.Size(321, 19);
            this.boreHoleEnergy.TabIndex = 0;
            this.boreHoleEnergy.Text = "Energie im Erdsondenfeld (bezogen aud 10°C) (in MWh)";
            this.boreHoleEnergy.UseVisualStyleBackColor = true;
            this.boreHoleEnergy.CheckedChanged += new System.EventHandler(this.boreHoleEnergy_CheckedChanged);
            // 
            // openTemperaturFile
            // 
            this.openTemperaturFile.FileName = " ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.solarPercentage);
            this.groupBox1.Controls.Add(label41);
            this.groupBox1.Controls.Add(this.electricityTotal);
            this.groupBox1.Controls.Add(label40);
            this.groupBox1.Controls.Add(this.heatProduced);
            this.groupBox1.Controls.Add(label39);
            this.groupBox1.Controls.Add(this.solarTotal);
            this.groupBox1.Controls.Add(label38);
            this.groupBox1.Controls.Add(this.boreHoleRemoved);
            this.groupBox1.Controls.Add(label37);
            this.groupBox1.Controls.Add(this.boreHoleAdded);
            this.groupBox1.Controls.Add(label36);
            this.groupBox1.Location = new System.Drawing.Point(6, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 434);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ergebnisse";
            // 
            // boreHoleAdded
            // 
            this.boreHoleAdded.Location = new System.Drawing.Point(327, 22);
            this.boreHoleAdded.Name = "boreHoleAdded";
            this.boreHoleAdded.Size = new System.Drawing.Size(100, 23);
            this.boreHoleAdded.TabIndex = 9;
            // 
            // label36
            // 
            label36.Location = new System.Drawing.Point(0, 25);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(320, 15);
            label36.TabIndex = 8;
            label36.Text = "Erdsondenspeicher Eintrag (MWh):";
            label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            label37.Location = new System.Drawing.Point(0, 54);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(320, 15);
            label37.TabIndex = 8;
            label37.Text = "Erdsondenspeicher Lieferung (MWh):";
            label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boreHoleRemoved
            // 
            this.boreHoleRemoved.Location = new System.Drawing.Point(327, 51);
            this.boreHoleRemoved.Name = "boreHoleRemoved";
            this.boreHoleRemoved.Size = new System.Drawing.Size(100, 23);
            this.boreHoleRemoved.TabIndex = 9;
            // 
            // label38
            // 
            label38.Location = new System.Drawing.Point(0, 83);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(320, 15);
            label38.TabIndex = 8;
            label38.Text = "Solarthermie Leistung (MWh):";
            label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solarTotal
            // 
            this.solarTotal.Location = new System.Drawing.Point(327, 80);
            this.solarTotal.Name = "solarTotal";
            this.solarTotal.Size = new System.Drawing.Size(100, 23);
            this.solarTotal.TabIndex = 9;
            // 
            // label39
            // 
            label39.Location = new System.Drawing.Point(0, 112);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(320, 15);
            label39.TabIndex = 8;
            label39.Text = "erzeugte Wärme (MWh):";
            label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // heatProduced
            // 
            this.heatProduced.Location = new System.Drawing.Point(327, 109);
            this.heatProduced.Name = "heatProduced";
            this.heatProduced.Size = new System.Drawing.Size(100, 23);
            this.heatProduced.TabIndex = 9;
            // 
            // label40
            // 
            label40.Location = new System.Drawing.Point(0, 141);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(320, 15);
            label40.TabIndex = 8;
            label40.Text = "Anteil Elektrizität (MWh):";
            label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // electricityTotal
            // 
            this.electricityTotal.Location = new System.Drawing.Point(327, 138);
            this.electricityTotal.Name = "electricityTotal";
            this.electricityTotal.Size = new System.Drawing.Size(100, 23);
            this.electricityTotal.TabIndex = 9;
            // 
            // label41
            // 
            label41.Location = new System.Drawing.Point(0, 170);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(320, 15);
            label41.TabIndex = 8;
            label41.Text = "solarer Deckungsgrad in % und COP:";
            label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solarPercentage
            // 
            this.solarPercentage.Location = new System.Drawing.Point(327, 167);
            this.solarPercentage.Name = "solarPercentage";
            this.solarPercentage.Size = new System.Drawing.Size(100, 23);
            this.solarPercentage.TabIndex = 9;
            // 
            // DistrictHeating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 642);
            this.Controls.Add(this.tabMain);
            this.Name = "DistrictHeating";
            this.Text = "Simulation einer Anlage mit Solarthermie, Erdsonden-Wärmespeicher und Wärmeverbra" +
    "uchern";
            this.tabPlant.ResumeLayout(false);
            this.tabPlant.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabBHTES.ResumeLayout(false);
            this.tabBHTES.PerformLayout();
            this.tabBufferStorage.ResumeLayout(false);
            this.tabBufferStorage.PerformLayout();
            this.tabSolar.ResumeLayout(false);
            this.tabSolar.PerformLayout();
            this.tabConsumer.ResumeLayout(false);
            this.tabConsumer.PerformLayout();
            this.tabWether.ResumeLayout(false);
            this.tabSimulation.ResumeLayout(false);
            this.tabSimulation.PerformLayout();
            this.tabGraphics.ResumeLayout(false);
            this.legend.ResumeLayout(false);
            this.legend.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabMain;
        private TabPage tabBHTES;
        private TabPage tabSolar;
        private TabPage tabWether;
        private TabPage tabPlant;
        private TabPage tabSimulation;
        private TabPage tabGraphics;
        private TabPage tabConsumer;
        private TextBox pipelineLength;
        private ComboBox numBoreHoles;
        private TextBox borHoleDistance;
        private TextBox boreHoleLength;
        private TextBox groundHeatCapacity;
        private TextBox groundLambda;
        private Button saveTemperatureData;
        private Button readTemperatureData;
        private ListBox wetherData;
        private OpenFileDialog openTemperaturFile;
        private Button startSimulation;
        private TextBox pipeDiameter;
        private TextBox vlm20;
        private TextBox vlm15;
        private TextBox vlm10;
        private TextBox vlm5;
        private TextBox vl0;
        private TextBox vl5;
        private TextBox vl10;
        private TextBox vl15;
        private TextBox vl20;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private ComboBox HeatingName;
        private TextBox dayTemperature;
        private TextBox energyPerYear;
        private RadioButton threePipes;
        private RadioButton twoPipes;
        private TextBox insulationLambda;
        private TextBox pipeInsulationDiameter;
        private TextBox numConnections;
        private TextBox heatPumpEfficiency;
        private TextBox endDayTime;
        private TextBox beginDayTime;
        private TextBox nightTemperature;
        private TextBox instanceNumber;
        private TabPage tabBufferStorage;
        private TextBox bufferStorageEnergyTransfer;
        private TextBox bufferStroageSize;
        private TextBox bufferStorageInstances;
        private TextBox solarEfficiency;
        private TextBox solarFieldSize;
        private Panel graphicsPanel;
        private TextBox startBorderTemperature;
        private TextBox startCenterTemperature;
        private Panel panelRight;
        private Panel panelLeft;
        private Panel timeScale;
        private TabPage legend;
        private CheckBox warmPipe;
        private CheckBox returnPipe;
        private CheckBox hotPipe;
        private CheckBox boreHoleCenter;
        private CheckBox boreHoleBorder;
        private CheckBox heatConsumption;
        private CheckBox electricityConsumption;
        private CheckBox solarEnergy;
        private CheckBox boreHoleEnergyFlow;
        private CheckBox ambientTemperature;
        private CheckBox volumeFlow;
        private CheckBox boreHoleEnergy;
        private ToolTip toolTipDiagram;
        private Button zoomMinus;
        private Button zoomPlus;
        private ProgressBar progressBar;
        private GroupBox groupBox1;
        private TextBox solarPercentage;
        private TextBox electricityTotal;
        private TextBox heatProduced;
        private TextBox solarTotal;
        private TextBox boreHoleRemoved;
        private TextBox boreHoleAdded;
    }
}