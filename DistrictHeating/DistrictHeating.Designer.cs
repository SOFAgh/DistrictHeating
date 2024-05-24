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
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label label32;
            System.Windows.Forms.Label label33;
            System.Windows.Forms.Label label34;
            System.Windows.Forms.Label label35;
            System.Windows.Forms.Label label42;
            System.Windows.Forms.Label label43;
            System.Windows.Forms.Label label44;
            System.Windows.Forms.Label label45;
            System.Windows.Forms.Label label46;
            System.Windows.Forms.Label label47;
            System.Windows.Forms.Label label50;
            System.Windows.Forms.Label label51;
            System.Windows.Forms.Label label52;
            System.Windows.Forms.Label label49;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label41;
            System.Windows.Forms.Label label40;
            System.Windows.Forms.Label label39;
            System.Windows.Forms.Label label38;
            System.Windows.Forms.Label label37;
            System.Windows.Forms.Label label36;
            this.tabPlant = new System.Windows.Forms.TabPage();
            this.openPlant = new System.Windows.Forms.Button();
            this.savePlant = new System.Windows.Forms.Button();
            this.debug = new System.Windows.Forms.Button();
            this.netFlowTemperature = new System.Windows.Forms.TextBox();
            this.numConnections = new System.Windows.Forms.TextBox();
            this.insulationLambda = new System.Windows.Forms.TextBox();
            this.pipeInsulationDiameter = new System.Windows.Forms.TextBox();
            this.pipeDiameter = new System.Windows.Forms.TextBox();
            this.pipelineLength = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBHTES = new System.Windows.Forms.TabPage();
            this.boreHoleTime = new System.Windows.Forms.HScrollBar();
            this.selectBoreholeTempFile = new System.Windows.Forms.Button();
            this.boreHoleFieldDisplay = new System.Windows.Forms.Panel();
            this.boreholeTempFileName = new System.Windows.Forms.TextBox();
            this.boreHolePower = new System.Windows.Forms.TextBox();
            this.numGrid = new System.Windows.Forms.TextBox();
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
            this.concentrator = new System.Windows.Forms.TabPage();
            this.useConcentrator = new System.Windows.Forms.CheckBox();
            this.batteryCapacity = new System.Windows.Forms.TextBox();
            this.cHeatPumpPower = new System.Windows.Forms.TextBox();
            this.pvPeak = new System.Windows.Forms.TextBox();
            this.tabConsumer = new System.Windows.Forms.TabPage();
            this.heatPumpEfficiency = new System.Windows.Forms.TextBox();
            this.hotWaterPercentage = new System.Windows.Forms.TextBox();
            this.energyPerYear = new System.Windows.Forms.TextBox();
            this.tabWether = new System.Windows.Forms.TabPage();
            this.label48 = new System.Windows.Forms.Label();
            this.weatherStaionsList = new System.Windows.Forms.ComboBox();
            this.weatherData = new System.Windows.Forms.ListBox();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.saveSimulationData = new System.Windows.Forms.Button();
            this.solarPercentage = new System.Windows.Forms.TextBox();
            this.electricityTotal = new System.Windows.Forms.TextBox();
            this.heatProduced = new System.Windows.Forms.TextBox();
            this.solarTotal = new System.Windows.Forms.TextBox();
            this.boreHoleRemoved = new System.Windows.Forms.TextBox();
            this.boreHoleAdded = new System.Windows.Forms.TextBox();
            this.currentDate = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timeStep = new System.Windows.Forms.TextBox();
            this.numYears = new System.Windows.Forms.TextBox();
            this.startDate = new System.Windows.Forms.TextBox();
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
            this.bufferBottomTemperature = new System.Windows.Forms.CheckBox();
            this.bufferTopTemperature = new System.Windows.Forms.CheckBox();
            this.bufferEnergy = new System.Windows.Forms.CheckBox();
            this.netLoss = new System.Windows.Forms.CheckBox();
            this.boreHoleEnergy = new System.Windows.Forms.CheckBox();
            this.openTemperaturFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTipDiagram = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuSaveImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bildSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            label42 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            label44 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            label46 = new System.Windows.Forms.Label();
            label47 = new System.Windows.Forms.Label();
            label50 = new System.Windows.Forms.Label();
            label51 = new System.Windows.Forms.Label();
            label52 = new System.Windows.Forms.Label();
            label49 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            label40 = new System.Windows.Forms.Label();
            label39 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            this.tabPlant.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBHTES.SuspendLayout();
            this.tabBufferStorage.SuspendLayout();
            this.tabSolar.SuspendLayout();
            this.concentrator.SuspendLayout();
            this.tabConsumer.SuspendLayout();
            this.tabWether.SuspendLayout();
            this.tabSimulation.SuspendLayout();
            this.tabGraphics.SuspendLayout();
            this.legend.SuspendLayout();
            this.contextMenuSaveImage.SuspendLayout();
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
            // label27
            // 
            label27.Location = new System.Drawing.Point(9, 105);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(320, 15);
            label27.TabIndex = 2;
            label27.Text = "Gütegrad der Wärmepumpe in %";
            label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label42
            // 
            label42.Location = new System.Drawing.Point(6, 96);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(320, 15);
            label42.TabIndex = 6;
            label42.Text = "Startzeitpunkt (TT.MM.):";
            label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            label43.Location = new System.Drawing.Point(6, 125);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(320, 15);
            label43.TabIndex = 6;
            label43.Text = "Anzahl der Jahre";
            label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            label44.Location = new System.Drawing.Point(6, 154);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(320, 15);
            label44.TabIndex = 6;
            label44.Text = "Zeitschritte für die Simulation (in min)";
            label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            label45.Location = new System.Drawing.Point(6, 208);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(320, 15);
            label45.TabIndex = 5;
            label45.Text = "Anzahl Zwischenpunkte für Simulation:";
            label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            label46.Location = new System.Drawing.Point(6, 234);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(320, 15);
            label46.TabIndex = 5;
            label46.Text = "Leistung Erdsonde (W/(K*m))";
            label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            label47.Location = new System.Drawing.Point(6, 260);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(320, 15);
            label47.TabIndex = 5;
            label47.Text = "Dateiname für Ausgabe";
            label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            label50.Location = new System.Drawing.Point(30, 104);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(320, 15);
            label50.TabIndex = 4;
            label50.Text = "Akku Kapazität (kWh):";
            label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            label51.Location = new System.Drawing.Point(30, 75);
            label51.Name = "label51";
            label51.Size = new System.Drawing.Size(320, 15);
            label51.TabIndex = 5;
            label51.Text = "Elektrische Leistung der Wärmepumpe (kW):";
            label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            label52.Location = new System.Drawing.Point(30, 46);
            label52.Name = "label52";
            label52.Size = new System.Drawing.Size(320, 15);
            label52.TabIndex = 6;
            label52.Text = "Peak Leistung der Photovoltaik (kW):";
            label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label49
            // 
            label49.Location = new System.Drawing.Point(6, 180);
            label49.Name = "label49";
            label49.Size = new System.Drawing.Size(320, 15);
            label49.TabIndex = 0;
            label49.Text = "minimale Vorlauftemperatur im Netz:";
            label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(9, 76);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(320, 15);
            label9.TabIndex = 2;
            label9.Text = "Anteil für Warmwasserbereitung (%):";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            label41.Location = new System.Drawing.Point(6, 440);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(320, 15);
            label41.TabIndex = 11;
            label41.Text = "solarer Deckungsgrad in % und COP:";
            label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            label40.Location = new System.Drawing.Point(6, 411);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(320, 15);
            label40.TabIndex = 12;
            label40.Text = "Anteil Elektrizität (MWh):";
            label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            label39.Location = new System.Drawing.Point(6, 382);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(320, 15);
            label39.TabIndex = 13;
            label39.Text = "erzeugte Wärme (MWh):";
            label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            label38.Location = new System.Drawing.Point(6, 353);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(320, 15);
            label38.TabIndex = 14;
            label38.Text = "Solarthermie Leistung (MWh):";
            label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            label37.Location = new System.Drawing.Point(6, 324);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(320, 15);
            label37.TabIndex = 15;
            label37.Text = "Erdsondenspeicher Lieferung (MWh):";
            label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            label36.Location = new System.Drawing.Point(6, 295);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(320, 15);
            label36.TabIndex = 16;
            label36.Text = "Erdsondenspeicher Eintrag (MWh):";
            label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPlant
            // 
            this.tabPlant.Controls.Add(this.openPlant);
            this.tabPlant.Controls.Add(this.savePlant);
            this.tabPlant.Controls.Add(this.debug);
            this.tabPlant.Controls.Add(this.netFlowTemperature);
            this.tabPlant.Controls.Add(label49);
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
            this.tabPlant.Size = new System.Drawing.Size(1057, 606);
            this.tabPlant.TabIndex = 3;
            this.tabPlant.Text = "Anlage";
            this.tabPlant.UseVisualStyleBackColor = true;
            // 
            // openPlant
            // 
            this.openPlant.Location = new System.Drawing.Point(333, 286);
            this.openPlant.Name = "openPlant";
            this.openPlant.Size = new System.Drawing.Size(100, 23);
            this.openPlant.TabIndex = 4;
            this.openPlant.Text = "Öffnen";
            this.openPlant.UseVisualStyleBackColor = true;
            this.openPlant.Click += new System.EventHandler(this.openPlant_Click);
            // 
            // savePlant
            // 
            this.savePlant.Location = new System.Drawing.Point(333, 257);
            this.savePlant.Name = "savePlant";
            this.savePlant.Size = new System.Drawing.Size(100, 23);
            this.savePlant.TabIndex = 4;
            this.savePlant.Text = "Speichern";
            this.savePlant.UseVisualStyleBackColor = true;
            this.savePlant.Click += new System.EventHandler(this.savePlant_Click);
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(931, 553);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(75, 23);
            this.debug.TabIndex = 3;
            this.debug.Text = "Debug";
            this.debug.UseVisualStyleBackColor = true;
            // 
            // netFlowTemperature
            // 
            this.netFlowTemperature.Location = new System.Drawing.Point(333, 177);
            this.netFlowTemperature.Name = "netFlowTemperature";
            this.netFlowTemperature.Size = new System.Drawing.Size(100, 23);
            this.netFlowTemperature.TabIndex = 1;
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
            this.tabMain.Controls.Add(this.concentrator);
            this.tabMain.Controls.Add(this.tabConsumer);
            this.tabMain.Controls.Add(this.tabWether);
            this.tabMain.Controls.Add(this.tabSimulation);
            this.tabMain.Controls.Add(this.tabGraphics);
            this.tabMain.Controls.Add(this.legend);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1065, 634);
            this.tabMain.TabIndex = 0;
            // 
            // tabBHTES
            // 
            this.tabBHTES.Controls.Add(this.boreHoleTime);
            this.tabBHTES.Controls.Add(this.selectBoreholeTempFile);
            this.tabBHTES.Controls.Add(this.boreHoleFieldDisplay);
            this.tabBHTES.Controls.Add(this.boreholeTempFileName);
            this.tabBHTES.Controls.Add(label47);
            this.tabBHTES.Controls.Add(this.boreHolePower);
            this.tabBHTES.Controls.Add(label46);
            this.tabBHTES.Controls.Add(this.numGrid);
            this.tabBHTES.Controls.Add(label45);
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
            this.tabBHTES.Size = new System.Drawing.Size(1057, 606);
            this.tabBHTES.TabIndex = 0;
            this.tabBHTES.Text = "Erdsondenspeicher";
            this.tabBHTES.UseVisualStyleBackColor = true;
            // 
            // boreHoleTime
            // 
            this.boreHoleTime.Location = new System.Drawing.Point(570, 425);
            this.boreHoleTime.Name = "boreHoleTime";
            this.boreHoleTime.Size = new System.Drawing.Size(449, 26);
            this.boreHoleTime.TabIndex = 9;
            // 
            // selectBoreholeTempFile
            // 
            this.selectBoreholeTempFile.Location = new System.Drawing.Point(509, 256);
            this.selectBoreholeTempFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectBoreholeTempFile.Name = "selectBoreholeTempFile";
            this.selectBoreholeTempFile.Size = new System.Drawing.Size(27, 22);
            this.selectBoreholeTempFile.TabIndex = 8;
            this.selectBoreholeTempFile.Text = "...";
            this.selectBoreholeTempFile.UseVisualStyleBackColor = true;
            this.selectBoreholeTempFile.Click += new System.EventHandler(this.selectBoreholeTempFile_Click);
            // 
            // boreHoleFieldDisplay
            // 
            this.boreHoleFieldDisplay.Location = new System.Drawing.Point(570, 14);
            this.boreHoleFieldDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boreHoleFieldDisplay.Name = "boreHoleFieldDisplay";
            this.boreHoleFieldDisplay.Size = new System.Drawing.Size(449, 409);
            this.boreHoleFieldDisplay.TabIndex = 7;
            this.boreHoleFieldDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.boreHoleFieldDisplay_Paint);
            // 
            // boreholeTempFileName
            // 
            this.boreholeTempFileName.Location = new System.Drawing.Point(332, 257);
            this.boreholeTempFileName.Name = "boreholeTempFileName";
            this.boreholeTempFileName.Size = new System.Drawing.Size(173, 23);
            this.boreholeTempFileName.TabIndex = 6;
            // 
            // boreHolePower
            // 
            this.boreHolePower.Location = new System.Drawing.Point(332, 231);
            this.boreHolePower.Name = "boreHolePower";
            this.boreHolePower.Size = new System.Drawing.Size(100, 23);
            this.boreHolePower.TabIndex = 6;
            // 
            // numGrid
            // 
            this.numGrid.Location = new System.Drawing.Point(332, 205);
            this.numGrid.Name = "numGrid";
            this.numGrid.Size = new System.Drawing.Size(100, 23);
            this.numGrid.TabIndex = 6;
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
            this.tabBufferStorage.Size = new System.Drawing.Size(1057, 606);
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
            this.tabSolar.Size = new System.Drawing.Size(1057, 606);
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
            this.solarFieldSize.Tag = "Hier ist die Modulfläche gemeint, nicht die Stellfläche.";
            // 
            // concentrator
            // 
            this.concentrator.Controls.Add(this.useConcentrator);
            this.concentrator.Controls.Add(this.batteryCapacity);
            this.concentrator.Controls.Add(label50);
            this.concentrator.Controls.Add(this.cHeatPumpPower);
            this.concentrator.Controls.Add(label51);
            this.concentrator.Controls.Add(this.pvPeak);
            this.concentrator.Controls.Add(label52);
            this.concentrator.Location = new System.Drawing.Point(4, 24);
            this.concentrator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.concentrator.Name = "concentrator";
            this.concentrator.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.concentrator.Size = new System.Drawing.Size(1057, 606);
            this.concentrator.TabIndex = 9;
            this.concentrator.Text = "Konzentrator";
            this.concentrator.UseVisualStyleBackColor = true;
            // 
            // useConcentrator
            // 
            this.useConcentrator.AutoSize = true;
            this.useConcentrator.Location = new System.Drawing.Point(357, 20);
            this.useConcentrator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.useConcentrator.Name = "useConcentrator";
            this.useConcentrator.Size = new System.Drawing.Size(155, 19);
            this.useConcentrator.TabIndex = 12;
            this.useConcentrator.Text = "Konzentrator verwenden";
            this.useConcentrator.UseVisualStyleBackColor = true;
            // 
            // batteryCapacity
            // 
            this.batteryCapacity.Location = new System.Drawing.Point(357, 101);
            this.batteryCapacity.Name = "batteryCapacity";
            this.batteryCapacity.Size = new System.Drawing.Size(100, 23);
            this.batteryCapacity.TabIndex = 9;
            // 
            // cHeatPumpPower
            // 
            this.cHeatPumpPower.Location = new System.Drawing.Point(357, 72);
            this.cHeatPumpPower.Name = "cHeatPumpPower";
            this.cHeatPumpPower.Size = new System.Drawing.Size(100, 23);
            this.cHeatPumpPower.TabIndex = 10;
            // 
            // pvPeak
            // 
            this.pvPeak.Location = new System.Drawing.Point(357, 44);
            this.pvPeak.Name = "pvPeak";
            this.pvPeak.Size = new System.Drawing.Size(100, 23);
            this.pvPeak.TabIndex = 11;
            // 
            // tabConsumer
            // 
            this.tabConsumer.Controls.Add(this.heatPumpEfficiency);
            this.tabConsumer.Controls.Add(label27);
            this.tabConsumer.Controls.Add(this.hotWaterPercentage);
            this.tabConsumer.Controls.Add(label9);
            this.tabConsumer.Controls.Add(this.energyPerYear);
            this.tabConsumer.Controls.Add(label8);
            this.tabConsumer.Location = new System.Drawing.Point(4, 24);
            this.tabConsumer.Name = "tabConsumer";
            this.tabConsumer.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsumer.Size = new System.Drawing.Size(1057, 606);
            this.tabConsumer.TabIndex = 6;
            this.tabConsumer.Text = "Verbraucher";
            this.tabConsumer.UseVisualStyleBackColor = true;
            // 
            // heatPumpEfficiency
            // 
            this.heatPumpEfficiency.Location = new System.Drawing.Point(336, 102);
            this.heatPumpEfficiency.Name = "heatPumpEfficiency";
            this.heatPumpEfficiency.Size = new System.Drawing.Size(100, 23);
            this.heatPumpEfficiency.TabIndex = 3;
            // 
            // hotWaterPercentage
            // 
            this.hotWaterPercentage.Location = new System.Drawing.Point(336, 73);
            this.hotWaterPercentage.Name = "hotWaterPercentage";
            this.hotWaterPercentage.Size = new System.Drawing.Size(100, 23);
            this.hotWaterPercentage.TabIndex = 3;
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
            this.tabWether.Controls.Add(this.label48);
            this.tabWether.Controls.Add(this.weatherStaionsList);
            this.tabWether.Controls.Add(this.weatherData);
            this.tabWether.Location = new System.Drawing.Point(4, 24);
            this.tabWether.Name = "tabWether";
            this.tabWether.Padding = new System.Windows.Forms.Padding(3);
            this.tabWether.Size = new System.Drawing.Size(1057, 606);
            this.tabWether.TabIndex = 2;
            this.tabWether.Text = "Wetterdaten";
            this.tabWether.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(8, 9);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(166, 15);
            this.label48.TabIndex = 2;
            this.label48.Text = "Wetterdaten: Station und Jahr:";
            // 
            // weatherStaionsList
            // 
            this.weatherStaionsList.FormattingEnabled = true;
            this.weatherStaionsList.Location = new System.Drawing.Point(180, 6);
            this.weatherStaionsList.Name = "weatherStaionsList";
            this.weatherStaionsList.Size = new System.Drawing.Size(275, 23);
            this.weatherStaionsList.TabIndex = 1;
            this.weatherStaionsList.SelectedIndexChanged += new System.EventHandler(this.weatherStaionsList_SelectedIndexChanged);
            // 
            // weatherData
            // 
            this.weatherData.FormattingEnabled = true;
            this.weatherData.ItemHeight = 15;
            this.weatherData.Location = new System.Drawing.Point(6, 36);
            this.weatherData.Name = "weatherData";
            this.weatherData.Size = new System.Drawing.Size(565, 544);
            this.weatherData.TabIndex = 0;
            // 
            // tabSimulation
            // 
            this.tabSimulation.Controls.Add(this.label10);
            this.tabSimulation.Controls.Add(this.saveSimulationData);
            this.tabSimulation.Controls.Add(this.solarPercentage);
            this.tabSimulation.Controls.Add(label41);
            this.tabSimulation.Controls.Add(this.electricityTotal);
            this.tabSimulation.Controls.Add(label40);
            this.tabSimulation.Controls.Add(this.heatProduced);
            this.tabSimulation.Controls.Add(label39);
            this.tabSimulation.Controls.Add(this.solarTotal);
            this.tabSimulation.Controls.Add(label38);
            this.tabSimulation.Controls.Add(this.boreHoleRemoved);
            this.tabSimulation.Controls.Add(label37);
            this.tabSimulation.Controls.Add(this.boreHoleAdded);
            this.tabSimulation.Controls.Add(label36);
            this.tabSimulation.Controls.Add(this.currentDate);
            this.tabSimulation.Controls.Add(this.progressBar);
            this.tabSimulation.Controls.Add(this.timeStep);
            this.tabSimulation.Controls.Add(label44);
            this.tabSimulation.Controls.Add(this.numYears);
            this.tabSimulation.Controls.Add(label43);
            this.tabSimulation.Controls.Add(this.startDate);
            this.tabSimulation.Controls.Add(label42);
            this.tabSimulation.Controls.Add(this.startBorderTemperature);
            this.tabSimulation.Controls.Add(label35);
            this.tabSimulation.Controls.Add(this.startCenterTemperature);
            this.tabSimulation.Controls.Add(label34);
            this.tabSimulation.Controls.Add(this.startSimulation);
            this.tabSimulation.Location = new System.Drawing.Point(4, 24);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulation.Size = new System.Drawing.Size(1057, 606);
            this.tabSimulation.TabIndex = 4;
            this.tabSimulation.Text = "Simulation";
            this.tabSimulation.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(424, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ergebnisse der Simulation, erst verfügbar, nachdem die Simulation gelaufen ist ";
            // 
            // saveSimulationData
            // 
            this.saveSimulationData.Location = new System.Drawing.Point(333, 463);
            this.saveSimulationData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveSimulationData.Name = "saveSimulationData";
            this.saveSimulationData.Size = new System.Drawing.Size(100, 22);
            this.saveSimulationData.TabIndex = 23;
            this.saveSimulationData.Text = "Speichern";
            this.saveSimulationData.UseVisualStyleBackColor = true;
            this.saveSimulationData.Click += new System.EventHandler(this.saveSimulationData_Click);
            // 
            // solarPercentage
            // 
            this.solarPercentage.Location = new System.Drawing.Point(333, 437);
            this.solarPercentage.Name = "solarPercentage";
            this.solarPercentage.Size = new System.Drawing.Size(100, 23);
            this.solarPercentage.TabIndex = 17;
            // 
            // electricityTotal
            // 
            this.electricityTotal.Location = new System.Drawing.Point(333, 408);
            this.electricityTotal.Name = "electricityTotal";
            this.electricityTotal.Size = new System.Drawing.Size(100, 23);
            this.electricityTotal.TabIndex = 18;
            // 
            // heatProduced
            // 
            this.heatProduced.Location = new System.Drawing.Point(333, 379);
            this.heatProduced.Name = "heatProduced";
            this.heatProduced.Size = new System.Drawing.Size(100, 23);
            this.heatProduced.TabIndex = 19;
            // 
            // solarTotal
            // 
            this.solarTotal.Location = new System.Drawing.Point(333, 350);
            this.solarTotal.Name = "solarTotal";
            this.solarTotal.Size = new System.Drawing.Size(100, 23);
            this.solarTotal.TabIndex = 20;
            // 
            // boreHoleRemoved
            // 
            this.boreHoleRemoved.Location = new System.Drawing.Point(333, 321);
            this.boreHoleRemoved.Name = "boreHoleRemoved";
            this.boreHoleRemoved.Size = new System.Drawing.Size(100, 23);
            this.boreHoleRemoved.TabIndex = 21;
            // 
            // boreHoleAdded
            // 
            this.boreHoleAdded.Location = new System.Drawing.Point(333, 292);
            this.boreHoleAdded.Name = "boreHoleAdded";
            this.boreHoleAdded.Size = new System.Drawing.Size(100, 23);
            this.boreHoleAdded.TabIndex = 22;
            // 
            // currentDate
            // 
            this.currentDate.AutoSize = true;
            this.currentDate.Location = new System.Drawing.Point(6, 536);
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(97, 15);
            this.currentDate.TabIndex = 10;
            this.currentDate.Text = "laufendes Datum";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 561);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(886, 23);
            this.progressBar.TabIndex = 8;
            // 
            // timeStep
            // 
            this.timeStep.Location = new System.Drawing.Point(333, 151);
            this.timeStep.Name = "timeStep";
            this.timeStep.Size = new System.Drawing.Size(100, 23);
            this.timeStep.TabIndex = 7;
            // 
            // numYears
            // 
            this.numYears.Location = new System.Drawing.Point(333, 122);
            this.numYears.Name = "numYears";
            this.numYears.Size = new System.Drawing.Size(100, 23);
            this.numYears.TabIndex = 7;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(333, 93);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(100, 23);
            this.startDate.TabIndex = 7;
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
            this.tabGraphics.Size = new System.Drawing.Size(1057, 606);
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
            // 
            // zoomPlus
            // 
            this.zoomPlus.Location = new System.Drawing.Point(990, 551);
            this.zoomPlus.Name = "zoomPlus";
            this.zoomPlus.Size = new System.Drawing.Size(37, 33);
            this.zoomPlus.TabIndex = 3;
            this.zoomPlus.Text = "+";
            this.zoomPlus.UseVisualStyleBackColor = true;
            // 
            // timeScale
            // 
            this.timeScale.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeScale.Location = new System.Drawing.Point(44, 570);
            this.timeScale.Name = "timeScale";
            this.timeScale.Size = new System.Drawing.Size(957, 33);
            this.timeScale.TabIndex = 2;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1001, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(53, 600);
            this.panelRight.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(41, 600);
            this.panelLeft.TabIndex = 1;
            // 
            // graphicsPanel
            // 
            this.graphicsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel.Location = new System.Drawing.Point(3, 3);
            this.graphicsPanel.Name = "graphicsPanel";
            this.graphicsPanel.Size = new System.Drawing.Size(1051, 600);
            this.graphicsPanel.TabIndex = 0;
            this.graphicsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel_Paint);
            this.graphicsPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel_MouseClick);
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
            this.legend.Controls.Add(this.bufferBottomTemperature);
            this.legend.Controls.Add(this.bufferTopTemperature);
            this.legend.Controls.Add(this.bufferEnergy);
            this.legend.Controls.Add(this.netLoss);
            this.legend.Controls.Add(this.boreHoleEnergy);
            this.legend.Location = new System.Drawing.Point(4, 24);
            this.legend.Name = "legend";
            this.legend.Padding = new System.Windows.Forms.Padding(3);
            this.legend.Size = new System.Drawing.Size(1057, 606);
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
            this.warmPipe.CheckedChanged += new System.EventHandler(this.warmPipe_CheckChanged);
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
            this.returnPipe.CheckedChanged += new System.EventHandler(this.returnPipe_CheckChanged);
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
            this.hotPipe.CheckedChanged += new System.EventHandler(this.hotPipe_CheckChanged);
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
            this.boreHoleCenter.CheckedChanged += new System.EventHandler(this.boreHoleCenter_CheckChanged);
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
            this.boreHoleBorder.CheckedChanged += new System.EventHandler(this.boreHoleBorder_CheckChanged);
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
            this.heatConsumption.CheckedChanged += new System.EventHandler(this.heatConsumption_CheckChanged);
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
            this.electricityConsumption.CheckedChanged += new System.EventHandler(this.electricityConsumption_CheckChanged);
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
            this.solarEnergy.CheckedChanged += new System.EventHandler(this.solarEnergy_CheckChanged);
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
            this.boreHoleEnergyFlow.CheckedChanged += new System.EventHandler(this.boreHoleEnergyFlow_CheckChanged);
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
            this.ambientTemperature.CheckedChanged += new System.EventHandler(this.ambientTemperature_CheckChanged);
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
            this.volumeFlow.CheckedChanged += new System.EventHandler(this.volumeFlow_CheckChanged);
            // 
            // bufferBottomTemperature
            // 
            this.bufferBottomTemperature.AutoSize = true;
            this.bufferBottomTemperature.ForeColor = System.Drawing.Color.Gold;
            this.bufferBottomTemperature.Location = new System.Drawing.Point(239, 394);
            this.bufferBottomTemperature.Name = "bufferBottomTemperature";
            this.bufferBottomTemperature.Size = new System.Drawing.Size(199, 19);
            this.bufferBottomTemperature.TabIndex = 0;
            this.bufferBottomTemperature.Text = "Pufferspeicher Temperatur unten";
            this.bufferBottomTemperature.UseVisualStyleBackColor = true;
            this.bufferBottomTemperature.CheckedChanged += new System.EventHandler(this.bufferBottomTemperature_CheckChanged);
            // 
            // bufferTopTemperature
            // 
            this.bufferTopTemperature.AutoSize = true;
            this.bufferTopTemperature.ForeColor = System.Drawing.Color.YellowGreen;
            this.bufferTopTemperature.Location = new System.Drawing.Point(239, 369);
            this.bufferTopTemperature.Name = "bufferTopTemperature";
            this.bufferTopTemperature.Size = new System.Drawing.Size(195, 19);
            this.bufferTopTemperature.TabIndex = 0;
            this.bufferTopTemperature.Text = "Pufferspeicher Temperatur oben";
            this.bufferTopTemperature.UseVisualStyleBackColor = true;
            this.bufferTopTemperature.CheckedChanged += new System.EventHandler(this.bufferTopTemperature_CheckChanged);
            // 
            // bufferEnergy
            // 
            this.bufferEnergy.AutoSize = true;
            this.bufferEnergy.ForeColor = System.Drawing.Color.LawnGreen;
            this.bufferEnergy.Location = new System.Drawing.Point(239, 344);
            this.bufferEnergy.Name = "bufferEnergy";
            this.bufferEnergy.Size = new System.Drawing.Size(203, 19);
            this.bufferEnergy.TabIndex = 0;
            this.bufferEnergy.Text = "Puffersepeicher Energie (in MWh)";
            this.bufferEnergy.UseVisualStyleBackColor = true;
            this.bufferEnergy.CheckedChanged += new System.EventHandler(this.bufferEnergy_CheckChanged);
            // 
            // netLoss
            // 
            this.netLoss.AutoSize = true;
            this.netLoss.ForeColor = System.Drawing.Color.Indigo;
            this.netLoss.Location = new System.Drawing.Point(239, 319);
            this.netLoss.Name = "netLoss";
            this.netLoss.Size = new System.Drawing.Size(156, 19);
            this.netLoss.TabIndex = 0;
            this.netLoss.Text = "Leitungsverluste im Netz";
            this.netLoss.UseVisualStyleBackColor = true;
            this.netLoss.CheckedChanged += new System.EventHandler(this.netLoss_CheckChanged);
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
            this.boreHoleEnergy.CheckedChanged += new System.EventHandler(this.boreHoleEnergy_CheckChanged);
            // 
            // openTemperaturFile
            // 
            this.openTemperaturFile.FileName = " ";
            // 
            // contextMenuSaveImage
            // 
            this.contextMenuSaveImage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuSaveImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bildSpeichernToolStripMenuItem});
            this.contextMenuSaveImage.Name = "contextMenuStrip1";
            this.contextMenuSaveImage.Size = new System.Drawing.Size(149, 26);
            // 
            // bildSpeichernToolStripMenuItem
            // 
            this.bildSpeichernToolStripMenuItem.Name = "bildSpeichernToolStripMenuItem";
            this.bildSpeichernToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.bildSpeichernToolStripMenuItem.Text = "Bild speichern";
            this.bildSpeichernToolStripMenuItem.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // DistrictHeating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 634);
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
            this.concentrator.ResumeLayout(false);
            this.concentrator.PerformLayout();
            this.tabConsumer.ResumeLayout(false);
            this.tabConsumer.PerformLayout();
            this.tabWether.ResumeLayout(false);
            this.tabWether.PerformLayout();
            this.tabSimulation.ResumeLayout(false);
            this.tabSimulation.PerformLayout();
            this.tabGraphics.ResumeLayout(false);
            this.legend.ResumeLayout(false);
            this.legend.PerformLayout();
            this.contextMenuSaveImage.ResumeLayout(false);
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
        private ListBox weatherData;
        private OpenFileDialog openTemperaturFile;
        private Button startSimulation;
        private TextBox pipeDiameter;
        private TextBox energyPerYear;
        private TextBox insulationLambda;
        private TextBox pipeInsulationDiameter;
        private TextBox numConnections;
        private TextBox heatPumpEfficiency;
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
        private CheckBox netLoss;
        private Panel boreHoleFieldDisplay;
        private CheckBox bufferBottomTemperature;
        private CheckBox bufferTopTemperature;
        private CheckBox bufferEnergy;
        private ContextMenuStrip contextMenuSaveImage;
        private ToolStripMenuItem bildSpeichernToolStripMenuItem;
        private TextBox startDate;
        private TextBox timeStep;
        private TextBox numYears;
        private TextBox numGrid;
        private Button debug;
        private HScrollBar boreHoleTime;
        private Button selectBoreholeTempFile;
        private TextBox boreholeTempFileName;
        private TextBox boreHolePower;
        private TabPage concentrator;
        private TextBox batteryCapacity;
        private TextBox cHeatPumpPower;
        private TextBox pvPeak;
        private CheckBox useConcentrator;
        private Label currentDate;
        private Label label48;
        private ComboBox weatherStaionsList;
        private TextBox netFlowTemperature;
        private TextBox hotWaterPercentage;
        private Button openPlant;
        private Button savePlant;
        private Button saveSimulationData;
        private TextBox solarPercentage;
        private TextBox electricityTotal;
        private TextBox heatProduced;
        private TextBox solarTotal;
        private TextBox boreHoleRemoved;
        private TextBox boreHoleAdded;
        private Label label10;
    }
}