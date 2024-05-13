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
            components = new System.ComponentModel.Container();
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            Label label6;
            Label label7;
            Label label8;
            Label label9;
            Label label19;
            Label label20;
            Label label21;
            Label label22;
            Label label23;
            Label label24;
            Label label25;
            Label label26;
            Label label27;
            Label label28;
            Label label29;
            Label label30;
            Label label31;
            Label label32;
            Label label33;
            Label label34;
            Label label35;
            Label label36;
            Label label37;
            Label label38;
            Label label39;
            Label label40;
            Label label41;
            Label label42;
            Label label43;
            Label label44;
            Label label45;
            Label label46;
            Label label47;
            Label label50;
            Label label51;
            Label label52;
            tabPlant = new TabPage();
            debug = new Button();
            threePipes = new RadioButton();
            twoPipes = new RadioButton();
            numConnections = new TextBox();
            insulationLambda = new TextBox();
            pipeInsulationDiameter = new TextBox();
            pipeDiameter = new TextBox();
            pipelineLength = new TextBox();
            tabMain = new TabControl();
            tabBHTES = new TabPage();
            boreHoleTime = new HScrollBar();
            selectBoreholeTempFile = new Button();
            boreHoleFieldDisplay = new Panel();
            boreholeTempFileName = new TextBox();
            boreHolePower = new TextBox();
            numGrid = new TextBox();
            groundHeatCapacity = new TextBox();
            groundLambda = new TextBox();
            borHoleDistance = new TextBox();
            boreHoleLength = new TextBox();
            numBoreHoles = new ComboBox();
            tabBufferStorage = new TabPage();
            bufferStorageInstances = new TextBox();
            bufferStorageEnergyTransfer = new TextBox();
            bufferStroageSize = new TextBox();
            tabSolar = new TabPage();
            solarEfficiency = new TextBox();
            solarFieldSize = new TextBox();
            concentrator = new TabPage();
            useConcentrator = new CheckBox();
            batteryCapacity = new TextBox();
            cHeatPumpPower = new TextBox();
            pvPeak = new TextBox();
            tabConsumer = new TabPage();
            vlm20 = new TextBox();
            vlm15 = new TextBox();
            vlm10 = new TextBox();
            vlm5 = new TextBox();
            vl0 = new TextBox();
            vl5 = new TextBox();
            vl10 = new TextBox();
            vl15 = new TextBox();
            vl20 = new TextBox();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            HeatingName = new ComboBox();
            instanceNumber = new TextBox();
            heatPumpEfficiency = new TextBox();
            endDayTime = new TextBox();
            beginDayTime = new TextBox();
            nightTemperature = new TextBox();
            dayTemperature = new TextBox();
            energyPerYear = new TextBox();
            tabWether = new TabPage();
            saveTemperatureData = new Button();
            readTemperatureData = new Button();
            wetherData = new ListBox();
            tabSimulation = new TabPage();
            groupBox1 = new GroupBox();
            saveSimulationData = new Button();
            solarPercentage = new TextBox();
            electricityTotal = new TextBox();
            heatProduced = new TextBox();
            solarTotal = new TextBox();
            boreHoleRemoved = new TextBox();
            boreHoleAdded = new TextBox();
            progressBar = new ProgressBar();
            timeStep = new TextBox();
            numYears = new TextBox();
            startDate = new TextBox();
            startBorderTemperature = new TextBox();
            startCenterTemperature = new TextBox();
            startSimulation = new Button();
            tabGraphics = new TabPage();
            zoomMinus = new Button();
            zoomPlus = new Button();
            timeScale = new Panel();
            panelRight = new Panel();
            panelLeft = new Panel();
            graphicsPanel = new Panel();
            legend = new TabPage();
            warmPipe = new CheckBox();
            returnPipe = new CheckBox();
            hotPipe = new CheckBox();
            boreHoleCenter = new CheckBox();
            boreHoleBorder = new CheckBox();
            heatConsumption = new CheckBox();
            electricityConsumption = new CheckBox();
            solarEnergy = new CheckBox();
            boreHoleEnergyFlow = new CheckBox();
            ambientTemperature = new CheckBox();
            volumeFlow = new CheckBox();
            bufferBottomTemperature = new CheckBox();
            bufferTopTemperature = new CheckBox();
            bufferEnergy = new CheckBox();
            netLoss = new CheckBox();
            boreHoleEnergy = new CheckBox();
            openTemperaturFile = new OpenFileDialog();
            toolTipDiagram = new ToolTip(components);
            contextMenuSaveImage = new ContextMenuStrip(components);
            bildSpeichernToolStripMenuItem = new ToolStripMenuItem();
            currentDate = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            label37 = new Label();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            label41 = new Label();
            label42 = new Label();
            label43 = new Label();
            label44 = new Label();
            label45 = new Label();
            label46 = new Label();
            label47 = new Label();
            label50 = new Label();
            label51 = new Label();
            label52 = new Label();
            tabPlant.SuspendLayout();
            tabMain.SuspendLayout();
            tabBHTES.SuspendLayout();
            tabBufferStorage.SuspendLayout();
            tabSolar.SuspendLayout();
            concentrator.SuspendLayout();
            tabConsumer.SuspendLayout();
            tabWether.SuspendLayout();
            tabSimulation.SuspendLayout();
            groupBox1.SuspendLayout();
            tabGraphics.SuspendLayout();
            legend.SuspendLayout();
            contextMenuSaveImage.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(7, 47);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(366, 20);
            label1.TabIndex = 0;
            label1.Text = "Gesamtlänge des Nahwärmenetzes (m):";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(7, 84);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(366, 20);
            label2.TabIndex = 2;
            label2.Text = "Anzahl der Sonden:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(7, 123);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(366, 20);
            label3.TabIndex = 5;
            label3.Text = "Bohrtiefe (m):";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(7, 161);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(366, 20);
            label4.TabIndex = 5;
            label4.Text = "Abstand der Sonden (m):";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(7, 200);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(366, 20);
            label5.TabIndex = 5;
            label5.Text = "Wärmeleitfähigkeit des Erdreichs (W/(m·K)):";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(7, 239);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(366, 20);
            label6.TabIndex = 5;
            label6.Text = "Wärmekapazität (J/(m³·K)):";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(7, 85);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(366, 20);
            label7.TabIndex = 0;
            label7.Text = "Durchmesser der Rohre (mm):";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(10, 63);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(366, 20);
            label8.TabIndex = 2;
            label8.Text = "Jahresverbrauch (MWh):";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(11, 24);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(366, 20);
            label9.TabIndex = 2;
            label9.Text = "Art der Heizung:";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Location = new System.Drawing.Point(10, 121);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(366, 20);
            label19.TabIndex = 2;
            label19.Text = "Vorlauftemperatur bei Außentemperatur:";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            label20.Location = new System.Drawing.Point(10, 160);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(366, 20);
            label20.TabIndex = 2;
            label20.Text = "gewünschte Tagestemperatur (°C):";
            label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            label21.Location = new System.Drawing.Point(7, 124);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(366, 20);
            label21.TabIndex = 0;
            label21.Text = "Außendurchmesser Dämmung (mm):";
            label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            label22.Location = new System.Drawing.Point(7, 163);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(366, 20);
            label22.TabIndex = 0;
            label22.Text = "Wärmeleitfähigkeit Dämmung (W/(m*K)):";
            label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            label23.Location = new System.Drawing.Point(7, 201);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(366, 20);
            label23.TabIndex = 0;
            label23.Text = "Anzahl der Hausanschlüsse:";
            label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            label24.Location = new System.Drawing.Point(10, 199);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(366, 20);
            label24.TabIndex = 2;
            label24.Text = "gewünschte Nachttemperatur (°C):";
            label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            label25.Location = new System.Drawing.Point(10, 237);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(366, 20);
            label25.TabIndex = 2;
            label25.Text = "Anfang Tagestemperatur (Uhrzeit, Stunde):";
            label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            label26.Location = new System.Drawing.Point(10, 276);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(366, 20);
            label26.TabIndex = 2;
            label26.Text = "Ende Tagestemperatur (Uhrzeit, Stunde):";
            label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            label27.Location = new System.Drawing.Point(10, 315);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(366, 20);
            label27.TabIndex = 2;
            label27.Text = "Gütegrad der Wärmepumpe in %";
            label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            label28.Location = new System.Drawing.Point(10, 353);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(366, 20);
            label28.TabIndex = 2;
            label28.Text = "Anzahl dieser Heizungen im System:";
            label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            label29.Location = new System.Drawing.Point(7, 60);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(366, 20);
            label29.TabIndex = 2;
            label29.Text = "Größe des Speichers (in m³):";
            label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            label30.Location = new System.Drawing.Point(7, 99);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(366, 20);
            label30.TabIndex = 2;
            label30.Text = "Leistungsübertragung Wärmetauscher (in W/K):";
            label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            label31.Location = new System.Drawing.Point(7, 137);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(366, 20);
            label31.TabIndex = 2;
            label31.Text = "Anzahl der Pufferspeicher im System:";
            label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            label32.Location = new System.Drawing.Point(7, 51);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(366, 20);
            label32.TabIndex = 4;
            label32.Text = "Größe des Solarthermie-Felds (in m²):";
            label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            label33.Location = new System.Drawing.Point(7, 89);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(366, 20);
            label33.TabIndex = 4;
            label33.Text = "Wirkungsgrad Solarthermie (in %):";
            label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            label34.Location = new System.Drawing.Point(7, 51);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(366, 20);
            label34.TabIndex = 6;
            label34.Text = "Anfangstemperatur in der Mitte des Speichers (in °C): ";
            label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            label35.Location = new System.Drawing.Point(7, 89);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(366, 20);
            label35.TabIndex = 6;
            label35.Text = "Anfangstemperatur am Rand des Speichers (in °C): ";
            label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            label36.Location = new System.Drawing.Point(0, 33);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(366, 20);
            label36.TabIndex = 8;
            label36.Text = "Erdsondenspeicher Eintrag (MWh):";
            label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            label37.Location = new System.Drawing.Point(0, 72);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(366, 20);
            label37.TabIndex = 8;
            label37.Text = "Erdsondenspeicher Lieferung (MWh):";
            label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            label38.Location = new System.Drawing.Point(0, 111);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(366, 20);
            label38.TabIndex = 8;
            label38.Text = "Solarthermie Leistung (MWh):";
            label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            label39.Location = new System.Drawing.Point(0, 149);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(366, 20);
            label39.TabIndex = 8;
            label39.Text = "erzeugte Wärme (MWh):";
            label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            label40.Location = new System.Drawing.Point(0, 188);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(366, 20);
            label40.TabIndex = 8;
            label40.Text = "Anteil Elektrizität (MWh):";
            label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            label41.Location = new System.Drawing.Point(0, 227);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(366, 20);
            label41.TabIndex = 8;
            label41.Text = "solarer Deckungsgrad in % und COP:";
            label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            label42.Location = new System.Drawing.Point(7, 128);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(366, 20);
            label42.TabIndex = 6;
            label42.Text = "Startzeitpunkt (TT.MM,):";
            label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            label43.Location = new System.Drawing.Point(7, 167);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(366, 20);
            label43.TabIndex = 6;
            label43.Text = "Anzahl der Jahre";
            label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            label44.Location = new System.Drawing.Point(7, 205);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(366, 20);
            label44.TabIndex = 6;
            label44.Text = "Zeitschritte für die Simulation (in min)";
            label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            label45.Location = new System.Drawing.Point(7, 277);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(366, 20);
            label45.TabIndex = 5;
            label45.Text = "Anzahl Zwischenpunkte für Simulation:";
            label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            label46.Location = new System.Drawing.Point(7, 312);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(366, 20);
            label46.TabIndex = 5;
            label46.Text = "Leistung Erdsonde (W/(K*m))";
            label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            label47.Location = new System.Drawing.Point(7, 347);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(366, 20);
            label47.TabIndex = 5;
            label47.Text = "Dateiname für Ausgabe";
            label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            label50.Location = new System.Drawing.Point(34, 139);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(366, 20);
            label50.TabIndex = 4;
            label50.Text = "Akku Kapazität (kWh):";
            label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            label51.Location = new System.Drawing.Point(34, 100);
            label51.Name = "label51";
            label51.Size = new System.Drawing.Size(366, 20);
            label51.TabIndex = 5;
            label51.Text = "Elektrische Leistung der Wärmepumpe (kW):";
            label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            label52.Location = new System.Drawing.Point(34, 62);
            label52.Name = "label52";
            label52.Size = new System.Drawing.Size(366, 20);
            label52.TabIndex = 6;
            label52.Text = "Peak Leistung der Photovoltaik (kW):";
            label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPlant
            // 
            tabPlant.Controls.Add(debug);
            tabPlant.Controls.Add(threePipes);
            tabPlant.Controls.Add(twoPipes);
            tabPlant.Controls.Add(numConnections);
            tabPlant.Controls.Add(label23);
            tabPlant.Controls.Add(insulationLambda);
            tabPlant.Controls.Add(label22);
            tabPlant.Controls.Add(pipeInsulationDiameter);
            tabPlant.Controls.Add(label21);
            tabPlant.Controls.Add(pipeDiameter);
            tabPlant.Controls.Add(label7);
            tabPlant.Controls.Add(pipelineLength);
            tabPlant.Controls.Add(label1);
            tabPlant.Location = new System.Drawing.Point(4, 29);
            tabPlant.Margin = new Padding(3, 4, 3, 4);
            tabPlant.Name = "tabPlant";
            tabPlant.Padding = new Padding(3, 4, 3, 4);
            tabPlant.Size = new System.Drawing.Size(1209, 812);
            tabPlant.TabIndex = 3;
            tabPlant.Text = "Anlage";
            tabPlant.UseVisualStyleBackColor = true;
            // 
            // debug
            // 
            debug.Location = new System.Drawing.Point(1064, 737);
            debug.Margin = new Padding(3, 4, 3, 4);
            debug.Name = "debug";
            debug.Size = new System.Drawing.Size(86, 31);
            debug.TabIndex = 3;
            debug.Text = "Debug";
            debug.UseVisualStyleBackColor = true;
            debug.Click += debug_Click;
            // 
            // threePipes
            // 
            threePipes.AutoSize = true;
            threePipes.Location = new System.Drawing.Point(381, 269);
            threePipes.Margin = new Padding(3, 4, 3, 4);
            threePipes.Name = "threePipes";
            threePipes.Size = new System.Drawing.Size(107, 24);
            threePipes.TabIndex = 2;
            threePipes.TabStop = true;
            threePipes.Text = "3 Leitungen";
            threePipes.UseVisualStyleBackColor = true;
            // 
            // twoPipes
            // 
            twoPipes.AutoSize = true;
            twoPipes.Location = new System.Drawing.Point(381, 236);
            twoPipes.Margin = new Padding(3, 4, 3, 4);
            twoPipes.Name = "twoPipes";
            twoPipes.Size = new System.Drawing.Size(107, 24);
            twoPipes.TabIndex = 2;
            twoPipes.TabStop = true;
            twoPipes.Text = "2 Leitungen";
            twoPipes.UseVisualStyleBackColor = true;
            // 
            // numConnections
            // 
            numConnections.Location = new System.Drawing.Point(381, 197);
            numConnections.Margin = new Padding(3, 4, 3, 4);
            numConnections.Name = "numConnections";
            numConnections.Size = new System.Drawing.Size(114, 27);
            numConnections.TabIndex = 1;
            // 
            // insulationLambda
            // 
            insulationLambda.Location = new System.Drawing.Point(381, 159);
            insulationLambda.Margin = new Padding(3, 4, 3, 4);
            insulationLambda.Name = "insulationLambda";
            insulationLambda.Size = new System.Drawing.Size(114, 27);
            insulationLambda.TabIndex = 1;
            // 
            // pipeInsulationDiameter
            // 
            pipeInsulationDiameter.Location = new System.Drawing.Point(381, 120);
            pipeInsulationDiameter.Margin = new Padding(3, 4, 3, 4);
            pipeInsulationDiameter.Name = "pipeInsulationDiameter";
            pipeInsulationDiameter.Size = new System.Drawing.Size(114, 27);
            pipeInsulationDiameter.TabIndex = 1;
            // 
            // pipeDiameter
            // 
            pipeDiameter.Location = new System.Drawing.Point(381, 81);
            pipeDiameter.Margin = new Padding(3, 4, 3, 4);
            pipeDiameter.Name = "pipeDiameter";
            pipeDiameter.Size = new System.Drawing.Size(114, 27);
            pipeDiameter.TabIndex = 1;
            // 
            // pipelineLength
            // 
            pipelineLength.Location = new System.Drawing.Point(381, 43);
            pipelineLength.Margin = new Padding(3, 4, 3, 4);
            pipelineLength.Name = "pipelineLength";
            pipelineLength.Size = new System.Drawing.Size(114, 27);
            pipelineLength.TabIndex = 1;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabPlant);
            tabMain.Controls.Add(tabBHTES);
            tabMain.Controls.Add(tabBufferStorage);
            tabMain.Controls.Add(tabSolar);
            tabMain.Controls.Add(concentrator);
            tabMain.Controls.Add(tabConsumer);
            tabMain.Controls.Add(tabWether);
            tabMain.Controls.Add(tabSimulation);
            tabMain.Controls.Add(tabGraphics);
            tabMain.Controls.Add(legend);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new System.Drawing.Point(0, 0);
            tabMain.Margin = new Padding(3, 4, 3, 4);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(1217, 845);
            tabMain.TabIndex = 0;
            // 
            // tabBHTES
            // 
            tabBHTES.Controls.Add(boreHoleTime);
            tabBHTES.Controls.Add(selectBoreholeTempFile);
            tabBHTES.Controls.Add(boreHoleFieldDisplay);
            tabBHTES.Controls.Add(boreholeTempFileName);
            tabBHTES.Controls.Add(label47);
            tabBHTES.Controls.Add(boreHolePower);
            tabBHTES.Controls.Add(label46);
            tabBHTES.Controls.Add(numGrid);
            tabBHTES.Controls.Add(label45);
            tabBHTES.Controls.Add(groundHeatCapacity);
            tabBHTES.Controls.Add(label6);
            tabBHTES.Controls.Add(groundLambda);
            tabBHTES.Controls.Add(label5);
            tabBHTES.Controls.Add(borHoleDistance);
            tabBHTES.Controls.Add(label4);
            tabBHTES.Controls.Add(boreHoleLength);
            tabBHTES.Controls.Add(label3);
            tabBHTES.Controls.Add(numBoreHoles);
            tabBHTES.Controls.Add(label2);
            tabBHTES.Location = new System.Drawing.Point(4, 29);
            tabBHTES.Margin = new Padding(3, 4, 3, 4);
            tabBHTES.Name = "tabBHTES";
            tabBHTES.Padding = new Padding(3, 4, 3, 4);
            tabBHTES.Size = new System.Drawing.Size(1209, 812);
            tabBHTES.TabIndex = 0;
            tabBHTES.Text = "Erdsondenspeicher";
            tabBHTES.UseVisualStyleBackColor = true;
            // 
            // boreHoleTime
            // 
            boreHoleTime.Location = new System.Drawing.Point(619, 567);
            boreHoleTime.Name = "boreHoleTime";
            boreHoleTime.Size = new System.Drawing.Size(545, 26);
            boreHoleTime.TabIndex = 9;
            // 
            // selectBoreholeTempFile
            // 
            selectBoreholeTempFile.Location = new System.Drawing.Point(582, 342);
            selectBoreholeTempFile.Name = "selectBoreholeTempFile";
            selectBoreholeTempFile.Size = new System.Drawing.Size(31, 29);
            selectBoreholeTempFile.TabIndex = 8;
            selectBoreholeTempFile.Text = "...";
            selectBoreholeTempFile.UseVisualStyleBackColor = true;
            selectBoreholeTempFile.Click += selectBoreholeTempFile_Click;
            // 
            // boreHoleFieldDisplay
            // 
            boreHoleFieldDisplay.Location = new System.Drawing.Point(619, 19);
            boreHoleFieldDisplay.Name = "boreHoleFieldDisplay";
            boreHoleFieldDisplay.Size = new System.Drawing.Size(545, 545);
            boreHoleFieldDisplay.TabIndex = 7;
            boreHoleFieldDisplay.Paint += boreHoleFieldDisplay_Paint;
            // 
            // boreholeTempFileName
            // 
            boreholeTempFileName.Location = new System.Drawing.Point(379, 343);
            boreholeTempFileName.Margin = new Padding(3, 4, 3, 4);
            boreholeTempFileName.Name = "boreholeTempFileName";
            boreholeTempFileName.Size = new System.Drawing.Size(197, 27);
            boreholeTempFileName.TabIndex = 6;
            // 
            // boreHolePower
            // 
            boreHolePower.Location = new System.Drawing.Point(379, 308);
            boreHolePower.Margin = new Padding(3, 4, 3, 4);
            boreHolePower.Name = "boreHolePower";
            boreHolePower.Size = new System.Drawing.Size(114, 27);
            boreHolePower.TabIndex = 6;
            // 
            // numGrid
            // 
            numGrid.Location = new System.Drawing.Point(379, 273);
            numGrid.Margin = new Padding(3, 4, 3, 4);
            numGrid.Name = "numGrid";
            numGrid.Size = new System.Drawing.Size(114, 27);
            numGrid.TabIndex = 6;
            // 
            // groundHeatCapacity
            // 
            groundHeatCapacity.Location = new System.Drawing.Point(379, 235);
            groundHeatCapacity.Margin = new Padding(3, 4, 3, 4);
            groundHeatCapacity.Name = "groundHeatCapacity";
            groundHeatCapacity.Size = new System.Drawing.Size(114, 27);
            groundHeatCapacity.TabIndex = 6;
            // 
            // groundLambda
            // 
            groundLambda.Location = new System.Drawing.Point(379, 196);
            groundLambda.Margin = new Padding(3, 4, 3, 4);
            groundLambda.Name = "groundLambda";
            groundLambda.Size = new System.Drawing.Size(114, 27);
            groundLambda.TabIndex = 6;
            // 
            // borHoleDistance
            // 
            borHoleDistance.Location = new System.Drawing.Point(379, 157);
            borHoleDistance.Margin = new Padding(3, 4, 3, 4);
            borHoleDistance.Name = "borHoleDistance";
            borHoleDistance.Size = new System.Drawing.Size(114, 27);
            borHoleDistance.TabIndex = 6;
            // 
            // boreHoleLength
            // 
            boreHoleLength.Location = new System.Drawing.Point(379, 119);
            boreHoleLength.Margin = new Padding(3, 4, 3, 4);
            boreHoleLength.Name = "boreHoleLength";
            boreHoleLength.Size = new System.Drawing.Size(114, 27);
            boreHoleLength.TabIndex = 6;
            // 
            // numBoreHoles
            // 
            numBoreHoles.DropDownStyle = ComboBoxStyle.DropDownList;
            numBoreHoles.FormattingEnabled = true;
            numBoreHoles.Items.AddRange(new object[] { "7 (einfach)", "19 (2 Ringe)", "37 (3 Ringe)", "61 (4 Ringe)", "91 (5 Ringe)", "127 (6 Ringe)", "169 (7 Ringe)" });
            numBoreHoles.Location = new System.Drawing.Point(379, 80);
            numBoreHoles.Margin = new Padding(3, 4, 3, 4);
            numBoreHoles.Name = "numBoreHoles";
            numBoreHoles.Size = new System.Drawing.Size(215, 28);
            numBoreHoles.TabIndex = 4;
            // 
            // tabBufferStorage
            // 
            tabBufferStorage.Controls.Add(bufferStorageInstances);
            tabBufferStorage.Controls.Add(label31);
            tabBufferStorage.Controls.Add(bufferStorageEnergyTransfer);
            tabBufferStorage.Controls.Add(label30);
            tabBufferStorage.Controls.Add(bufferStroageSize);
            tabBufferStorage.Controls.Add(label29);
            tabBufferStorage.Location = new System.Drawing.Point(4, 29);
            tabBufferStorage.Margin = new Padding(3, 4, 3, 4);
            tabBufferStorage.Name = "tabBufferStorage";
            tabBufferStorage.Padding = new Padding(3, 4, 3, 4);
            tabBufferStorage.Size = new System.Drawing.Size(1209, 812);
            tabBufferStorage.TabIndex = 7;
            tabBufferStorage.Text = "Pufferspeicher";
            tabBufferStorage.UseVisualStyleBackColor = true;
            // 
            // bufferStorageInstances
            // 
            bufferStorageInstances.Location = new System.Drawing.Point(381, 133);
            bufferStorageInstances.Margin = new Padding(3, 4, 3, 4);
            bufferStorageInstances.Name = "bufferStorageInstances";
            bufferStorageInstances.Size = new System.Drawing.Size(114, 27);
            bufferStorageInstances.TabIndex = 3;
            // 
            // bufferStorageEnergyTransfer
            // 
            bufferStorageEnergyTransfer.Location = new System.Drawing.Point(381, 95);
            bufferStorageEnergyTransfer.Margin = new Padding(3, 4, 3, 4);
            bufferStorageEnergyTransfer.Name = "bufferStorageEnergyTransfer";
            bufferStorageEnergyTransfer.Size = new System.Drawing.Size(114, 27);
            bufferStorageEnergyTransfer.TabIndex = 3;
            // 
            // bufferStroageSize
            // 
            bufferStroageSize.Location = new System.Drawing.Point(381, 56);
            bufferStroageSize.Margin = new Padding(3, 4, 3, 4);
            bufferStroageSize.Name = "bufferStroageSize";
            bufferStroageSize.Size = new System.Drawing.Size(114, 27);
            bufferStroageSize.TabIndex = 3;
            // 
            // tabSolar
            // 
            tabSolar.Controls.Add(solarEfficiency);
            tabSolar.Controls.Add(label33);
            tabSolar.Controls.Add(solarFieldSize);
            tabSolar.Controls.Add(label32);
            tabSolar.Location = new System.Drawing.Point(4, 29);
            tabSolar.Margin = new Padding(3, 4, 3, 4);
            tabSolar.Name = "tabSolar";
            tabSolar.Padding = new Padding(3, 4, 3, 4);
            tabSolar.Size = new System.Drawing.Size(1209, 812);
            tabSolar.TabIndex = 1;
            tabSolar.Text = "Solarthermie";
            tabSolar.UseVisualStyleBackColor = true;
            // 
            // solarEfficiency
            // 
            solarEfficiency.Location = new System.Drawing.Point(381, 85);
            solarEfficiency.Margin = new Padding(3, 4, 3, 4);
            solarEfficiency.Name = "solarEfficiency";
            solarEfficiency.Size = new System.Drawing.Size(114, 27);
            solarEfficiency.TabIndex = 5;
            // 
            // solarFieldSize
            // 
            solarFieldSize.Location = new System.Drawing.Point(381, 47);
            solarFieldSize.Margin = new Padding(3, 4, 3, 4);
            solarFieldSize.Name = "solarFieldSize";
            solarFieldSize.Size = new System.Drawing.Size(114, 27);
            solarFieldSize.TabIndex = 5;
            solarFieldSize.Tag = "Hier ist die Modulfläche gemeint, nicht die Stellfläche.";
            // 
            // concentrator
            // 
            concentrator.Controls.Add(useConcentrator);
            concentrator.Controls.Add(batteryCapacity);
            concentrator.Controls.Add(label50);
            concentrator.Controls.Add(cHeatPumpPower);
            concentrator.Controls.Add(label51);
            concentrator.Controls.Add(pvPeak);
            concentrator.Controls.Add(label52);
            concentrator.Location = new System.Drawing.Point(4, 29);
            concentrator.Name = "concentrator";
            concentrator.Padding = new Padding(3);
            concentrator.Size = new System.Drawing.Size(1209, 812);
            concentrator.TabIndex = 9;
            concentrator.Text = "Konzentrator";
            concentrator.UseVisualStyleBackColor = true;
            // 
            // useConcentrator
            // 
            useConcentrator.AutoSize = true;
            useConcentrator.Location = new System.Drawing.Point(408, 27);
            useConcentrator.Name = "useConcentrator";
            useConcentrator.Size = new System.Drawing.Size(193, 24);
            useConcentrator.TabIndex = 12;
            useConcentrator.Text = "Konzentrator verwenden";
            useConcentrator.UseVisualStyleBackColor = true;
            // 
            // batteryCapacity
            // 
            batteryCapacity.Location = new System.Drawing.Point(408, 135);
            batteryCapacity.Margin = new Padding(3, 4, 3, 4);
            batteryCapacity.Name = "batteryCapacity";
            batteryCapacity.Size = new System.Drawing.Size(114, 27);
            batteryCapacity.TabIndex = 9;
            // 
            // cHeatPumpPower
            // 
            cHeatPumpPower.Location = new System.Drawing.Point(408, 96);
            cHeatPumpPower.Margin = new Padding(3, 4, 3, 4);
            cHeatPumpPower.Name = "cHeatPumpPower";
            cHeatPumpPower.Size = new System.Drawing.Size(114, 27);
            cHeatPumpPower.TabIndex = 10;
            // 
            // pvPeak
            // 
            pvPeak.Location = new System.Drawing.Point(408, 58);
            pvPeak.Margin = new Padding(3, 4, 3, 4);
            pvPeak.Name = "pvPeak";
            pvPeak.Size = new System.Drawing.Size(114, 27);
            pvPeak.TabIndex = 11;
            // 
            // tabConsumer
            // 
            tabConsumer.Controls.Add(vlm20);
            tabConsumer.Controls.Add(vlm15);
            tabConsumer.Controls.Add(vlm10);
            tabConsumer.Controls.Add(vlm5);
            tabConsumer.Controls.Add(vl0);
            tabConsumer.Controls.Add(vl5);
            tabConsumer.Controls.Add(vl10);
            tabConsumer.Controls.Add(vl15);
            tabConsumer.Controls.Add(vl20);
            tabConsumer.Controls.Add(label18);
            tabConsumer.Controls.Add(label17);
            tabConsumer.Controls.Add(label16);
            tabConsumer.Controls.Add(label15);
            tabConsumer.Controls.Add(label14);
            tabConsumer.Controls.Add(label13);
            tabConsumer.Controls.Add(label12);
            tabConsumer.Controls.Add(label11);
            tabConsumer.Controls.Add(label10);
            tabConsumer.Controls.Add(HeatingName);
            tabConsumer.Controls.Add(instanceNumber);
            tabConsumer.Controls.Add(heatPumpEfficiency);
            tabConsumer.Controls.Add(endDayTime);
            tabConsumer.Controls.Add(label28);
            tabConsumer.Controls.Add(beginDayTime);
            tabConsumer.Controls.Add(label27);
            tabConsumer.Controls.Add(nightTemperature);
            tabConsumer.Controls.Add(label26);
            tabConsumer.Controls.Add(dayTemperature);
            tabConsumer.Controls.Add(label25);
            tabConsumer.Controls.Add(energyPerYear);
            tabConsumer.Controls.Add(label24);
            tabConsumer.Controls.Add(label9);
            tabConsumer.Controls.Add(label20);
            tabConsumer.Controls.Add(label19);
            tabConsumer.Controls.Add(label8);
            tabConsumer.Location = new System.Drawing.Point(4, 29);
            tabConsumer.Margin = new Padding(3, 4, 3, 4);
            tabConsumer.Name = "tabConsumer";
            tabConsumer.Padding = new Padding(3, 4, 3, 4);
            tabConsumer.Size = new System.Drawing.Size(1209, 812);
            tabConsumer.TabIndex = 6;
            tabConsumer.Text = "Verbraucher";
            tabConsumer.UseVisualStyleBackColor = true;
            // 
            // vlm20
            // 
            vlm20.Location = new System.Drawing.Point(658, 117);
            vlm20.Margin = new Padding(3, 4, 3, 4);
            vlm20.Name = "vlm20";
            vlm20.Size = new System.Drawing.Size(27, 27);
            vlm20.TabIndex = 6;
            // 
            // vlm15
            // 
            vlm15.Location = new System.Drawing.Point(624, 117);
            vlm15.Margin = new Padding(3, 4, 3, 4);
            vlm15.Name = "vlm15";
            vlm15.Size = new System.Drawing.Size(27, 27);
            vlm15.TabIndex = 6;
            // 
            // vlm10
            // 
            vlm10.Location = new System.Drawing.Point(590, 117);
            vlm10.Margin = new Padding(3, 4, 3, 4);
            vlm10.Name = "vlm10";
            vlm10.Size = new System.Drawing.Size(27, 27);
            vlm10.TabIndex = 6;
            // 
            // vlm5
            // 
            vlm5.Location = new System.Drawing.Point(555, 117);
            vlm5.Margin = new Padding(3, 4, 3, 4);
            vlm5.Name = "vlm5";
            vlm5.Size = new System.Drawing.Size(27, 27);
            vlm5.TabIndex = 6;
            // 
            // vl0
            // 
            vl0.Location = new System.Drawing.Point(521, 117);
            vl0.Margin = new Padding(3, 4, 3, 4);
            vl0.Name = "vl0";
            vl0.Size = new System.Drawing.Size(27, 27);
            vl0.TabIndex = 6;
            // 
            // vl5
            // 
            vl5.Location = new System.Drawing.Point(487, 117);
            vl5.Margin = new Padding(3, 4, 3, 4);
            vl5.Name = "vl5";
            vl5.Size = new System.Drawing.Size(27, 27);
            vl5.TabIndex = 6;
            // 
            // vl10
            // 
            vl10.Location = new System.Drawing.Point(453, 117);
            vl10.Margin = new Padding(3, 4, 3, 4);
            vl10.Name = "vl10";
            vl10.Size = new System.Drawing.Size(27, 27);
            vl10.TabIndex = 6;
            // 
            // vl15
            // 
            vl15.Location = new System.Drawing.Point(418, 117);
            vl15.Margin = new Padding(3, 4, 3, 4);
            vl15.Name = "vl15";
            vl15.Size = new System.Drawing.Size(27, 27);
            vl15.TabIndex = 6;
            // 
            // vl20
            // 
            vl20.Location = new System.Drawing.Point(384, 117);
            vl20.Margin = new Padding(3, 4, 3, 4);
            vl20.Name = "vl20";
            vl20.Size = new System.Drawing.Size(27, 27);
            vl20.TabIndex = 6;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(658, 93);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(37, 20);
            label18.TabIndex = 5;
            label18.Text = "-20°";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(624, 93);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(37, 20);
            label17.TabIndex = 5;
            label17.Text = "-15°";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(590, 93);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(37, 20);
            label16.TabIndex = 5;
            label16.Text = "-10°";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(555, 93);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(29, 20);
            label15.TabIndex = 5;
            label15.Text = "-5°";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(521, 93);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(23, 20);
            label14.TabIndex = 5;
            label14.Text = "0°";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(487, 93);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(23, 20);
            label13.TabIndex = 5;
            label13.Text = "5°";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(453, 93);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(31, 20);
            label12.TabIndex = 5;
            label12.Text = "10°";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(418, 93);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(31, 20);
            label11.TabIndex = 5;
            label11.Text = "15°";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(384, 93);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(31, 20);
            label10.TabIndex = 5;
            label10.Text = "20°";
            // 
            // HeatingName
            // 
            HeatingName.FormattingEnabled = true;
            HeatingName.Location = new System.Drawing.Point(384, 20);
            HeatingName.Margin = new Padding(3, 4, 3, 4);
            HeatingName.Name = "HeatingName";
            HeatingName.Size = new System.Drawing.Size(138, 28);
            HeatingName.TabIndex = 4;
            HeatingName.SelectedIndexChanged += HeatingName_SelectedIndexChanged;
            HeatingName.TextUpdate += HeatingName_TextUpdate;
            HeatingName.Leave += HeatingName_Leave;
            // 
            // instanceNumber
            // 
            instanceNumber.Location = new System.Drawing.Point(384, 349);
            instanceNumber.Margin = new Padding(3, 4, 3, 4);
            instanceNumber.Name = "instanceNumber";
            instanceNumber.Size = new System.Drawing.Size(114, 27);
            instanceNumber.TabIndex = 3;
            // 
            // heatPumpEfficiency
            // 
            heatPumpEfficiency.Location = new System.Drawing.Point(384, 311);
            heatPumpEfficiency.Margin = new Padding(3, 4, 3, 4);
            heatPumpEfficiency.Name = "heatPumpEfficiency";
            heatPumpEfficiency.Size = new System.Drawing.Size(114, 27);
            heatPumpEfficiency.TabIndex = 3;
            // 
            // endDayTime
            // 
            endDayTime.Location = new System.Drawing.Point(384, 272);
            endDayTime.Margin = new Padding(3, 4, 3, 4);
            endDayTime.Name = "endDayTime";
            endDayTime.Size = new System.Drawing.Size(114, 27);
            endDayTime.TabIndex = 3;
            // 
            // beginDayTime
            // 
            beginDayTime.Location = new System.Drawing.Point(384, 233);
            beginDayTime.Margin = new Padding(3, 4, 3, 4);
            beginDayTime.Name = "beginDayTime";
            beginDayTime.Size = new System.Drawing.Size(114, 27);
            beginDayTime.TabIndex = 3;
            // 
            // nightTemperature
            // 
            nightTemperature.Location = new System.Drawing.Point(384, 195);
            nightTemperature.Margin = new Padding(3, 4, 3, 4);
            nightTemperature.Name = "nightTemperature";
            nightTemperature.Size = new System.Drawing.Size(114, 27);
            nightTemperature.TabIndex = 3;
            // 
            // dayTemperature
            // 
            dayTemperature.Location = new System.Drawing.Point(384, 156);
            dayTemperature.Margin = new Padding(3, 4, 3, 4);
            dayTemperature.Name = "dayTemperature";
            dayTemperature.Size = new System.Drawing.Size(114, 27);
            dayTemperature.TabIndex = 3;
            // 
            // energyPerYear
            // 
            energyPerYear.Location = new System.Drawing.Point(384, 59);
            energyPerYear.Margin = new Padding(3, 4, 3, 4);
            energyPerYear.Name = "energyPerYear";
            energyPerYear.Size = new System.Drawing.Size(114, 27);
            energyPerYear.TabIndex = 3;
            // 
            // tabWether
            // 
            tabWether.Controls.Add(saveTemperatureData);
            tabWether.Controls.Add(readTemperatureData);
            tabWether.Controls.Add(wetherData);
            tabWether.Location = new System.Drawing.Point(4, 29);
            tabWether.Margin = new Padding(3, 4, 3, 4);
            tabWether.Name = "tabWether";
            tabWether.Padding = new Padding(3, 4, 3, 4);
            tabWether.Size = new System.Drawing.Size(1209, 812);
            tabWether.TabIndex = 2;
            tabWether.Text = "Wetterdaten";
            tabWether.UseVisualStyleBackColor = true;
            // 
            // saveTemperatureData
            // 
            saveTemperatureData.Location = new System.Drawing.Point(970, 8);
            saveTemperatureData.Margin = new Padding(3, 4, 3, 4);
            saveTemperatureData.Name = "saveTemperatureData";
            saveTemperatureData.Size = new System.Drawing.Size(203, 31);
            saveTemperatureData.TabIndex = 1;
            saveTemperatureData.Text = "Temperaturdaten speichern";
            saveTemperatureData.UseVisualStyleBackColor = true;
            // 
            // readTemperatureData
            // 
            readTemperatureData.Location = new System.Drawing.Point(659, 8);
            readTemperatureData.Margin = new Padding(3, 4, 3, 4);
            readTemperatureData.Name = "readTemperatureData";
            readTemperatureData.Size = new System.Drawing.Size(203, 31);
            readTemperatureData.TabIndex = 1;
            readTemperatureData.Text = "Temperaturdaten lesen";
            readTemperatureData.UseVisualStyleBackColor = true;
            readTemperatureData.Click += readTemperatureData_Click;
            // 
            // wetherData
            // 
            wetherData.FormattingEnabled = true;
            wetherData.ItemHeight = 20;
            wetherData.Location = new System.Drawing.Point(7, 8);
            wetherData.Margin = new Padding(3, 4, 3, 4);
            wetherData.Name = "wetherData";
            wetherData.Size = new System.Drawing.Size(645, 764);
            wetherData.TabIndex = 0;
            // 
            // tabSimulation
            // 
            tabSimulation.Controls.Add(currentDate);
            tabSimulation.Controls.Add(groupBox1);
            tabSimulation.Controls.Add(progressBar);
            tabSimulation.Controls.Add(timeStep);
            tabSimulation.Controls.Add(label44);
            tabSimulation.Controls.Add(numYears);
            tabSimulation.Controls.Add(label43);
            tabSimulation.Controls.Add(startDate);
            tabSimulation.Controls.Add(label42);
            tabSimulation.Controls.Add(startBorderTemperature);
            tabSimulation.Controls.Add(label35);
            tabSimulation.Controls.Add(startCenterTemperature);
            tabSimulation.Controls.Add(label34);
            tabSimulation.Controls.Add(startSimulation);
            tabSimulation.Location = new System.Drawing.Point(4, 29);
            tabSimulation.Margin = new Padding(3, 4, 3, 4);
            tabSimulation.Name = "tabSimulation";
            tabSimulation.Padding = new Padding(3, 4, 3, 4);
            tabSimulation.Size = new System.Drawing.Size(1209, 812);
            tabSimulation.TabIndex = 4;
            tabSimulation.Text = "Simulation";
            tabSimulation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(saveSimulationData);
            groupBox1.Controls.Add(solarPercentage);
            groupBox1.Controls.Add(label41);
            groupBox1.Controls.Add(electricityTotal);
            groupBox1.Controls.Add(label40);
            groupBox1.Controls.Add(heatProduced);
            groupBox1.Controls.Add(label39);
            groupBox1.Controls.Add(solarTotal);
            groupBox1.Controls.Add(label38);
            groupBox1.Controls.Add(boreHoleRemoved);
            groupBox1.Controls.Add(label37);
            groupBox1.Controls.Add(boreHoleAdded);
            groupBox1.Controls.Add(label36);
            groupBox1.Location = new System.Drawing.Point(7, 368);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(498, 335);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ergebnisse";
            // 
            // saveSimulationData
            // 
            saveSimulationData.Location = new System.Drawing.Point(374, 257);
            saveSimulationData.Name = "saveSimulationData";
            saveSimulationData.Size = new System.Drawing.Size(114, 29);
            saveSimulationData.TabIndex = 10;
            saveSimulationData.Text = "Speichern";
            saveSimulationData.UseVisualStyleBackColor = true;
            saveSimulationData.Click += saveSimulationData_Click;
            // 
            // solarPercentage
            // 
            solarPercentage.Location = new System.Drawing.Point(374, 223);
            solarPercentage.Margin = new Padding(3, 4, 3, 4);
            solarPercentage.Name = "solarPercentage";
            solarPercentage.Size = new System.Drawing.Size(114, 27);
            solarPercentage.TabIndex = 9;
            // 
            // electricityTotal
            // 
            electricityTotal.Location = new System.Drawing.Point(374, 184);
            electricityTotal.Margin = new Padding(3, 4, 3, 4);
            electricityTotal.Name = "electricityTotal";
            electricityTotal.Size = new System.Drawing.Size(114, 27);
            electricityTotal.TabIndex = 9;
            // 
            // heatProduced
            // 
            heatProduced.Location = new System.Drawing.Point(374, 145);
            heatProduced.Margin = new Padding(3, 4, 3, 4);
            heatProduced.Name = "heatProduced";
            heatProduced.Size = new System.Drawing.Size(114, 27);
            heatProduced.TabIndex = 9;
            // 
            // solarTotal
            // 
            solarTotal.Location = new System.Drawing.Point(374, 107);
            solarTotal.Margin = new Padding(3, 4, 3, 4);
            solarTotal.Name = "solarTotal";
            solarTotal.Size = new System.Drawing.Size(114, 27);
            solarTotal.TabIndex = 9;
            // 
            // boreHoleRemoved
            // 
            boreHoleRemoved.Location = new System.Drawing.Point(374, 68);
            boreHoleRemoved.Margin = new Padding(3, 4, 3, 4);
            boreHoleRemoved.Name = "boreHoleRemoved";
            boreHoleRemoved.Size = new System.Drawing.Size(114, 27);
            boreHoleRemoved.TabIndex = 9;
            // 
            // boreHoleAdded
            // 
            boreHoleAdded.Location = new System.Drawing.Point(374, 29);
            boreHoleAdded.Margin = new Padding(3, 4, 3, 4);
            boreHoleAdded.Name = "boreHoleAdded";
            boreHoleAdded.Size = new System.Drawing.Size(114, 27);
            boreHoleAdded.TabIndex = 9;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(7, 748);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Maximum = 1000;
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(1013, 31);
            progressBar.TabIndex = 8;
            // 
            // timeStep
            // 
            timeStep.Location = new System.Drawing.Point(381, 201);
            timeStep.Margin = new Padding(3, 4, 3, 4);
            timeStep.Name = "timeStep";
            timeStep.Size = new System.Drawing.Size(114, 27);
            timeStep.TabIndex = 7;
            // 
            // numYears
            // 
            numYears.Location = new System.Drawing.Point(381, 163);
            numYears.Margin = new Padding(3, 4, 3, 4);
            numYears.Name = "numYears";
            numYears.Size = new System.Drawing.Size(114, 27);
            numYears.TabIndex = 7;
            // 
            // startDate
            // 
            startDate.Location = new System.Drawing.Point(381, 124);
            startDate.Margin = new Padding(3, 4, 3, 4);
            startDate.Name = "startDate";
            startDate.Size = new System.Drawing.Size(114, 27);
            startDate.TabIndex = 7;
            // 
            // startBorderTemperature
            // 
            startBorderTemperature.Location = new System.Drawing.Point(381, 85);
            startBorderTemperature.Margin = new Padding(3, 4, 3, 4);
            startBorderTemperature.Name = "startBorderTemperature";
            startBorderTemperature.Size = new System.Drawing.Size(114, 27);
            startBorderTemperature.TabIndex = 7;
            // 
            // startCenterTemperature
            // 
            startCenterTemperature.Location = new System.Drawing.Point(381, 47);
            startCenterTemperature.Margin = new Padding(3, 4, 3, 4);
            startCenterTemperature.Name = "startCenterTemperature";
            startCenterTemperature.Size = new System.Drawing.Size(114, 27);
            startCenterTemperature.TabIndex = 7;
            // 
            // startSimulation
            // 
            startSimulation.Location = new System.Drawing.Point(1026, 748);
            startSimulation.Margin = new Padding(3, 4, 3, 4);
            startSimulation.Name = "startSimulation";
            startSimulation.Size = new System.Drawing.Size(147, 31);
            startSimulation.TabIndex = 0;
            startSimulation.Text = "Simulation Starten";
            startSimulation.UseVisualStyleBackColor = true;
            startSimulation.Click += startSimulation_Click;
            // 
            // tabGraphics
            // 
            tabGraphics.Controls.Add(zoomMinus);
            tabGraphics.Controls.Add(zoomPlus);
            tabGraphics.Controls.Add(timeScale);
            tabGraphics.Controls.Add(panelRight);
            tabGraphics.Controls.Add(panelLeft);
            tabGraphics.Controls.Add(graphicsPanel);
            tabGraphics.Location = new System.Drawing.Point(4, 29);
            tabGraphics.Margin = new Padding(3, 4, 3, 4);
            tabGraphics.Name = "tabGraphics";
            tabGraphics.Padding = new Padding(3, 4, 3, 4);
            tabGraphics.Size = new System.Drawing.Size(1209, 812);
            tabGraphics.TabIndex = 5;
            tabGraphics.Text = "Grafik";
            tabGraphics.UseVisualStyleBackColor = true;
            // 
            // zoomMinus
            // 
            zoomMinus.Location = new System.Drawing.Point(11, 735);
            zoomMinus.Margin = new Padding(3, 4, 3, 4);
            zoomMinus.Name = "zoomMinus";
            zoomMinus.Size = new System.Drawing.Size(42, 44);
            zoomMinus.TabIndex = 3;
            zoomMinus.Text = "-";
            zoomMinus.UseVisualStyleBackColor = true;
            zoomMinus.Click += zoomMinus_Click;
            // 
            // zoomPlus
            // 
            zoomPlus.Location = new System.Drawing.Point(1131, 735);
            zoomPlus.Margin = new Padding(3, 4, 3, 4);
            zoomPlus.Name = "zoomPlus";
            zoomPlus.Size = new System.Drawing.Size(42, 44);
            zoomPlus.TabIndex = 3;
            zoomPlus.Text = "+";
            zoomPlus.UseVisualStyleBackColor = true;
            zoomPlus.Click += zoomPlus_Click;
            // 
            // timeScale
            // 
            timeScale.Dock = DockStyle.Bottom;
            timeScale.Location = new System.Drawing.Point(50, 764);
            timeScale.Margin = new Padding(3, 4, 3, 4);
            timeScale.Name = "timeScale";
            timeScale.Size = new System.Drawing.Size(1095, 44);
            timeScale.TabIndex = 2;
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(1145, 4);
            panelRight.Margin = new Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(61, 804);
            panelRight.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(3, 4);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(47, 804);
            panelLeft.TabIndex = 1;
            // 
            // graphicsPanel
            // 
            graphicsPanel.Dock = DockStyle.Fill;
            graphicsPanel.Location = new System.Drawing.Point(3, 4);
            graphicsPanel.Margin = new Padding(3, 4, 3, 4);
            graphicsPanel.Name = "graphicsPanel";
            graphicsPanel.Size = new System.Drawing.Size(1203, 804);
            graphicsPanel.TabIndex = 0;
            graphicsPanel.Paint += graphicsPanel_Paint;
            graphicsPanel.MouseClick += graphicsPanel_MouseClick;
            graphicsPanel.MouseDown += graphicsPanel_MouseDown;
            graphicsPanel.MouseMove += graphicsPanel_MouseMove;
            graphicsPanel.MouseUp += graphicsPanel_MouseUp;
            // 
            // legend
            // 
            legend.Controls.Add(warmPipe);
            legend.Controls.Add(returnPipe);
            legend.Controls.Add(hotPipe);
            legend.Controls.Add(boreHoleCenter);
            legend.Controls.Add(boreHoleBorder);
            legend.Controls.Add(heatConsumption);
            legend.Controls.Add(electricityConsumption);
            legend.Controls.Add(solarEnergy);
            legend.Controls.Add(boreHoleEnergyFlow);
            legend.Controls.Add(ambientTemperature);
            legend.Controls.Add(volumeFlow);
            legend.Controls.Add(bufferBottomTemperature);
            legend.Controls.Add(bufferTopTemperature);
            legend.Controls.Add(bufferEnergy);
            legend.Controls.Add(netLoss);
            legend.Controls.Add(boreHoleEnergy);
            legend.Location = new System.Drawing.Point(4, 29);
            legend.Margin = new Padding(3, 4, 3, 4);
            legend.Name = "legend";
            legend.Padding = new Padding(3, 4, 3, 4);
            legend.Size = new System.Drawing.Size(1209, 812);
            legend.TabIndex = 8;
            legend.Text = "Legende";
            legend.UseVisualStyleBackColor = true;
            // 
            // warmPipe
            // 
            warmPipe.AutoSize = true;
            warmPipe.ForeColor = System.Drawing.Color.DarkOrange;
            warmPipe.Location = new System.Drawing.Point(273, 99);
            warmPipe.Margin = new Padding(3, 4, 3, 4);
            warmPipe.Name = "warmPipe";
            warmPipe.Size = new System.Drawing.Size(239, 24);
            warmPipe.TabIndex = 0;
            warmPipe.Text = "Vorlauf (warm) Netzleitung (°C)";
            warmPipe.UseVisualStyleBackColor = true;
            warmPipe.CheckedChanged += warmPipe_CheckedChanged;
            // 
            // returnPipe
            // 
            returnPipe.AutoSize = true;
            returnPipe.ForeColor = System.Drawing.Color.Black;
            returnPipe.Location = new System.Drawing.Point(273, 125);
            returnPipe.Margin = new Padding(3, 4, 3, 4);
            returnPipe.Name = "returnPipe";
            returnPipe.Size = new System.Drawing.Size(197, 24);
            returnPipe.TabIndex = 0;
            returnPipe.Text = "Rücklauf Netzleitung (°C)";
            returnPipe.UseVisualStyleBackColor = true;
            returnPipe.CheckedChanged += returnPipe_CheckedChanged;
            // 
            // hotPipe
            // 
            hotPipe.AutoSize = true;
            hotPipe.ForeColor = System.Drawing.Color.Maroon;
            hotPipe.Location = new System.Drawing.Point(273, 152);
            hotPipe.Margin = new Padding(3, 4, 3, 4);
            hotPipe.Name = "hotPipe";
            hotPipe.Size = new System.Drawing.Size(230, 24);
            hotPipe.TabIndex = 0;
            hotPipe.Text = "Vorlauf (heiß) Netzleitung (°C)";
            hotPipe.UseVisualStyleBackColor = true;
            hotPipe.CheckedChanged += hotPipe_CheckedChanged;
            // 
            // boreHoleCenter
            // 
            boreHoleCenter.AutoSize = true;
            boreHoleCenter.ForeColor = System.Drawing.Color.Red;
            boreHoleCenter.Location = new System.Drawing.Point(273, 179);
            boreHoleCenter.Margin = new Padding(3, 4, 3, 4);
            boreHoleCenter.Name = "boreHoleCenter";
            boreHoleCenter.Size = new System.Drawing.Size(195, 24);
            boreHoleCenter.TabIndex = 0;
            boreHoleCenter.Text = "Erdsondenfeld Mitte (°C)";
            boreHoleCenter.UseVisualStyleBackColor = true;
            boreHoleCenter.CheckedChanged += boreHoleCenter_CheckedChanged;
            // 
            // boreHoleBorder
            // 
            boreHoleBorder.AutoSize = true;
            boreHoleBorder.ForeColor = System.Drawing.Color.Purple;
            boreHoleBorder.Location = new System.Drawing.Point(273, 205);
            boreHoleBorder.Margin = new Padding(3, 4, 3, 4);
            boreHoleBorder.Name = "boreHoleBorder";
            boreHoleBorder.Size = new System.Drawing.Size(194, 24);
            boreHoleBorder.TabIndex = 0;
            boreHoleBorder.Text = "Erdsondenfeld Rand (°C)";
            boreHoleBorder.UseVisualStyleBackColor = true;
            boreHoleBorder.CheckedChanged += boreHoleBorder_CheckedChanged;
            // 
            // heatConsumption
            // 
            heatConsumption.AutoSize = true;
            heatConsumption.ForeColor = System.Drawing.Color.Fuchsia;
            heatConsumption.Location = new System.Drawing.Point(273, 232);
            heatConsumption.Margin = new Padding(3, 4, 3, 4);
            heatConsumption.Name = "heatConsumption";
            heatConsumption.Size = new System.Drawing.Size(237, 24);
            heatConsumption.TabIndex = 0;
            heatConsumption.Text = "Wärmeverbrauch Heizung (kW)";
            heatConsumption.UseVisualStyleBackColor = true;
            heatConsumption.CheckedChanged += heatConsumption_CheckedChanged;
            // 
            // electricityConsumption
            // 
            electricityConsumption.AutoSize = true;
            electricityConsumption.ForeColor = System.Drawing.Color.DeepPink;
            electricityConsumption.Location = new System.Drawing.Point(273, 259);
            electricityConsumption.Margin = new Padding(3, 4, 3, 4);
            electricityConsumption.Name = "electricityConsumption";
            electricityConsumption.Size = new System.Drawing.Size(338, 24);
            electricityConsumption.TabIndex = 0;
            electricityConsumption.Text = "Stromverbrauch Heizung (Wärmepumpe) (kW)";
            electricityConsumption.UseVisualStyleBackColor = true;
            electricityConsumption.CheckedChanged += electricityConsumption_CheckedChanged;
            // 
            // solarEnergy
            // 
            solarEnergy.AutoSize = true;
            solarEnergy.ForeColor = System.Drawing.Color.Olive;
            solarEnergy.Location = new System.Drawing.Point(273, 285);
            solarEnergy.Margin = new Padding(3, 4, 3, 4);
            solarEnergy.Name = "solarEnergy";
            solarEnergy.Size = new System.Drawing.Size(210, 24);
            solarEnergy.TabIndex = 0;
            solarEnergy.Text = "Leistung Solarthermie (kW)";
            solarEnergy.UseVisualStyleBackColor = true;
            solarEnergy.CheckedChanged += solarEnergy_CheckedChanged;
            // 
            // boreHoleEnergyFlow
            // 
            boreHoleEnergyFlow.AutoSize = true;
            boreHoleEnergyFlow.ForeColor = System.Drawing.Color.Navy;
            boreHoleEnergyFlow.Location = new System.Drawing.Point(273, 312);
            boreHoleEnergyFlow.Margin = new Padding(3, 4, 3, 4);
            boreHoleEnergyFlow.Name = "boreHoleEnergyFlow";
            boreHoleEnergyFlow.Size = new System.Drawing.Size(245, 24);
            boreHoleEnergyFlow.TabIndex = 0;
            boreHoleEnergyFlow.Text = "Energiefluss Erdsondenfeld (kW)";
            boreHoleEnergyFlow.UseVisualStyleBackColor = true;
            boreHoleEnergyFlow.CheckedChanged += boreHoleEnergyFlow_CheckedChanged;
            // 
            // ambientTemperature
            // 
            ambientTemperature.AutoSize = true;
            ambientTemperature.ForeColor = System.Drawing.Color.Blue;
            ambientTemperature.Location = new System.Drawing.Point(273, 339);
            ambientTemperature.Margin = new Padding(3, 4, 3, 4);
            ambientTemperature.Name = "ambientTemperature";
            ambientTemperature.Size = new System.Drawing.Size(272, 24);
            ambientTemperature.TabIndex = 0;
            ambientTemperature.Text = "Außentemperatur (Wetterdaten) (°C)";
            ambientTemperature.UseVisualStyleBackColor = true;
            ambientTemperature.CheckedChanged += ambientTemperature_CheckedChanged;
            // 
            // volumeFlow
            // 
            volumeFlow.AutoSize = true;
            volumeFlow.ForeColor = System.Drawing.Color.Teal;
            volumeFlow.Location = new System.Drawing.Point(273, 365);
            volumeFlow.Margin = new Padding(3, 4, 3, 4);
            volumeFlow.Name = "volumeFlow";
            volumeFlow.Size = new System.Drawing.Size(256, 24);
            volumeFlow.TabIndex = 0;
            volumeFlow.Text = "Volumenfluss im Leitungsnetz (l/s)";
            volumeFlow.UseVisualStyleBackColor = true;
            volumeFlow.CheckedChanged += volumeFlow_CheckedChanged;
            // 
            // bufferBottomTemperature
            // 
            bufferBottomTemperature.AutoSize = true;
            bufferBottomTemperature.ForeColor = System.Drawing.Color.Gold;
            bufferBottomTemperature.Location = new System.Drawing.Point(273, 525);
            bufferBottomTemperature.Margin = new Padding(3, 4, 3, 4);
            bufferBottomTemperature.Name = "bufferBottomTemperature";
            bufferBottomTemperature.Size = new System.Drawing.Size(246, 24);
            bufferBottomTemperature.TabIndex = 0;
            bufferBottomTemperature.Text = "Pufferspeicher Temperatur unten";
            bufferBottomTemperature.UseVisualStyleBackColor = true;
            bufferBottomTemperature.CheckedChanged += bufferBottomTemperature_CheckedChanged;
            // 
            // bufferTopTemperature
            // 
            bufferTopTemperature.AutoSize = true;
            bufferTopTemperature.ForeColor = System.Drawing.Color.YellowGreen;
            bufferTopTemperature.Location = new System.Drawing.Point(273, 492);
            bufferTopTemperature.Margin = new Padding(3, 4, 3, 4);
            bufferTopTemperature.Name = "bufferTopTemperature";
            bufferTopTemperature.Size = new System.Drawing.Size(243, 24);
            bufferTopTemperature.TabIndex = 0;
            bufferTopTemperature.Text = "Pufferspeicher Temperatur oben";
            bufferTopTemperature.UseVisualStyleBackColor = true;
            bufferTopTemperature.CheckedChanged += bufferTopTemperature_CheckedChanged;
            // 
            // bufferEnergy
            // 
            bufferEnergy.AutoSize = true;
            bufferEnergy.ForeColor = System.Drawing.Color.LawnGreen;
            bufferEnergy.Location = new System.Drawing.Point(273, 459);
            bufferEnergy.Margin = new Padding(3, 4, 3, 4);
            bufferEnergy.Name = "bufferEnergy";
            bufferEnergy.Size = new System.Drawing.Size(252, 24);
            bufferEnergy.TabIndex = 0;
            bufferEnergy.Text = "Puffersepeicher Energie (in MWh)";
            bufferEnergy.UseVisualStyleBackColor = true;
            bufferEnergy.CheckedChanged += bufferEnergy_CheckedChanged;
            // 
            // netLoss
            // 
            netLoss.AutoSize = true;
            netLoss.ForeColor = System.Drawing.Color.Indigo;
            netLoss.Location = new System.Drawing.Point(273, 425);
            netLoss.Margin = new Padding(3, 4, 3, 4);
            netLoss.Name = "netLoss";
            netLoss.Size = new System.Drawing.Size(193, 24);
            netLoss.TabIndex = 0;
            netLoss.Text = "Leitungsverluste im Netz";
            netLoss.UseVisualStyleBackColor = true;
            netLoss.CheckedChanged += netLoss_CheckedChanged;
            // 
            // boreHoleEnergy
            // 
            boreHoleEnergy.AutoSize = true;
            boreHoleEnergy.ForeColor = System.Drawing.Color.Brown;
            boreHoleEnergy.Location = new System.Drawing.Point(273, 392);
            boreHoleEnergy.Margin = new Padding(3, 4, 3, 4);
            boreHoleEnergy.Name = "boreHoleEnergy";
            boreHoleEnergy.Size = new System.Drawing.Size(403, 24);
            boreHoleEnergy.TabIndex = 0;
            boreHoleEnergy.Text = "Energie im Erdsondenfeld (bezogen aud 10°C) (in MWh)";
            boreHoleEnergy.UseVisualStyleBackColor = true;
            boreHoleEnergy.CheckedChanged += boreHoleEnergy_CheckedChanged;
            // 
            // openTemperaturFile
            // 
            openTemperaturFile.FileName = " ";
            // 
            // contextMenuSaveImage
            // 
            contextMenuSaveImage.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuSaveImage.Items.AddRange(new ToolStripItem[] { bildSpeichernToolStripMenuItem });
            contextMenuSaveImage.Name = "contextMenuStrip1";
            contextMenuSaveImage.Size = new System.Drawing.Size(172, 28);
            contextMenuSaveImage.Opening += contextMenuSaveImage_Opening;
            // 
            // bildSpeichernToolStripMenuItem
            // 
            bildSpeichernToolStripMenuItem.Name = "bildSpeichernToolStripMenuItem";
            bildSpeichernToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            bildSpeichernToolStripMenuItem.Text = "Bild speichern";
            bildSpeichernToolStripMenuItem.Click += saveImage_Click;
            // 
            // currentDate
            // 
            currentDate.AutoSize = true;
            currentDate.Location = new System.Drawing.Point(7, 714);
            currentDate.Name = "currentDate";
            currentDate.Size = new System.Drawing.Size(122, 20);
            currentDate.TabIndex = 10;
            currentDate.Text = "laufendes Datum";
            // 
            // DistrictHeating
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1217, 845);
            Controls.Add(tabMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DistrictHeating";
            Text = "Simulation einer Anlage mit Solarthermie, Erdsonden-Wärmespeicher und Wärmeverbrauchern";
            tabPlant.ResumeLayout(false);
            tabPlant.PerformLayout();
            tabMain.ResumeLayout(false);
            tabBHTES.ResumeLayout(false);
            tabBHTES.PerformLayout();
            tabBufferStorage.ResumeLayout(false);
            tabBufferStorage.PerformLayout();
            tabSolar.ResumeLayout(false);
            tabSolar.PerformLayout();
            concentrator.ResumeLayout(false);
            concentrator.PerformLayout();
            tabConsumer.ResumeLayout(false);
            tabConsumer.PerformLayout();
            tabWether.ResumeLayout(false);
            tabSimulation.ResumeLayout(false);
            tabSimulation.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabGraphics.ResumeLayout(false);
            legend.ResumeLayout(false);
            legend.PerformLayout();
            contextMenuSaveImage.ResumeLayout(false);
            ResumeLayout(false);
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
        private Button saveSimulationData;
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
    }
}