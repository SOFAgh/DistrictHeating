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
            this.tabPlant = new System.Windows.Forms.TabPage();
            this.pipelineLength = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBHTES = new System.Windows.Forms.TabPage();
            this.heatCapacity = new System.Windows.Forms.TextBox();
            this.lambda = new System.Windows.Forms.TextBox();
            this.borHoleDistance = new System.Windows.Forms.TextBox();
            this.boreHoleLength = new System.Windows.Forms.TextBox();
            this.numBoreHoles = new System.Windows.Forms.ComboBox();
            this.tabSolar = new System.Windows.Forms.TabPage();
            this.tabConsumer = new System.Windows.Forms.TabPage();
            this.tabWether = new System.Windows.Forms.TabPage();
            this.saveTemperatureData = new System.Windows.Forms.Button();
            this.readTemperatureData = new System.Windows.Forms.Button();
            this.wetherData = new System.Windows.Forms.ListBox();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabGraphics = new System.Windows.Forms.TabPage();
            this.openTemperaturFile = new System.Windows.Forms.OpenFileDialog();
            this.pipeDiameter = new System.Windows.Forms.TextBox();
            this.energyPerYear = new System.Windows.Forms.TextBox();
            this.HeatingName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.vl20 = new System.Windows.Forms.TextBox();
            this.vl15 = new System.Windows.Forms.TextBox();
            this.vl10 = new System.Windows.Forms.TextBox();
            this.vl5 = new System.Windows.Forms.TextBox();
            this.vlm5 = new System.Windows.Forms.TextBox();
            this.vlm10 = new System.Windows.Forms.TextBox();
            this.vlm15 = new System.Windows.Forms.TextBox();
            this.vlm20 = new System.Windows.Forms.TextBox();
            this.vl0 = new System.Windows.Forms.TextBox();
            this.instanceNumber = new System.Windows.Forms.TextBox();
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
            this.tabPlant.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBHTES.SuspendLayout();
            this.tabConsumer.SuspendLayout();
            this.tabWether.SuspendLayout();
            this.tabSimulation.SuspendLayout();
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
            // tabPlant
            // 
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
            this.tabMain.Controls.Add(this.tabSolar);
            this.tabMain.Controls.Add(this.tabConsumer);
            this.tabMain.Controls.Add(this.tabWether);
            this.tabMain.Controls.Add(this.tabSimulation);
            this.tabMain.Controls.Add(this.tabGraphics);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1041, 618);
            this.tabMain.TabIndex = 0;
            // 
            // tabBHTES
            // 
            this.tabBHTES.Controls.Add(this.heatCapacity);
            this.tabBHTES.Controls.Add(label6);
            this.tabBHTES.Controls.Add(this.lambda);
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
            // heatCapacity
            // 
            this.heatCapacity.Location = new System.Drawing.Point(332, 176);
            this.heatCapacity.Name = "heatCapacity";
            this.heatCapacity.Size = new System.Drawing.Size(100, 23);
            this.heatCapacity.TabIndex = 6;
            // 
            // lambda
            // 
            this.lambda.Location = new System.Drawing.Point(332, 147);
            this.lambda.Name = "lambda";
            this.lambda.Size = new System.Drawing.Size(100, 23);
            this.lambda.TabIndex = 6;
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
            // tabSolar
            // 
            this.tabSolar.Location = new System.Drawing.Point(4, 24);
            this.tabSolar.Name = "tabSolar";
            this.tabSolar.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolar.Size = new System.Drawing.Size(1033, 590);
            this.tabSolar.TabIndex = 1;
            this.tabSolar.Text = "Solarthermie";
            this.tabSolar.UseVisualStyleBackColor = true;
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
            this.tabConsumer.Controls.Add(this.energyPerYear);
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
            this.tabSimulation.Controls.Add(this.button1);
            this.tabSimulation.Location = new System.Drawing.Point(4, 24);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulation.Size = new System.Drawing.Size(1033, 590);
            this.tabSimulation.TabIndex = 4;
            this.tabSimulation.Text = "Simulation";
            this.tabSimulation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(898, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Simulation Starten";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabGraphics
            // 
            this.tabGraphics.Location = new System.Drawing.Point(4, 24);
            this.tabGraphics.Name = "tabGraphics";
            this.tabGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphics.Size = new System.Drawing.Size(1033, 590);
            this.tabGraphics.TabIndex = 5;
            this.tabGraphics.Text = "Grafik";
            this.tabGraphics.UseVisualStyleBackColor = true;
            // 
            // openTemperaturFile
            // 
            this.openTemperaturFile.FileName = " ";
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
            // pipeDiameter
            // 
            this.pipeDiameter.Location = new System.Drawing.Point(333, 61);
            this.pipeDiameter.Name = "pipeDiameter";
            this.pipeDiameter.Size = new System.Drawing.Size(100, 23);
            this.pipeDiameter.TabIndex = 1;
            // 
            // energyPerYear
            // 
            this.energyPerYear.Location = new System.Drawing.Point(336, 44);
            this.energyPerYear.Name = "energyPerYear";
            this.energyPerYear.Size = new System.Drawing.Size(100, 23);
            this.energyPerYear.TabIndex = 3;
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
            // HeatingName
            // 
            this.HeatingName.FormattingEnabled = true;
            this.HeatingName.Location = new System.Drawing.Point(336, 15);
            this.HeatingName.Name = "HeatingName";
            this.HeatingName.Size = new System.Drawing.Size(121, 23);
            this.HeatingName.TabIndex = 4;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "20°";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(396, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "10°";
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(456, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "0°";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(516, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 15);
            this.label16.TabIndex = 5;
            this.label16.Text = "-10°";
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(576, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 15);
            this.label18.TabIndex = 5;
            this.label18.Text = "-20°";
            // 
            // vl20
            // 
            this.vl20.Location = new System.Drawing.Point(336, 88);
            this.vl20.Name = "vl20";
            this.vl20.Size = new System.Drawing.Size(24, 23);
            this.vl20.TabIndex = 6;
            // 
            // vl15
            // 
            this.vl15.Location = new System.Drawing.Point(366, 88);
            this.vl15.Name = "vl15";
            this.vl15.Size = new System.Drawing.Size(24, 23);
            this.vl15.TabIndex = 6;
            // 
            // vl10
            // 
            this.vl10.Location = new System.Drawing.Point(396, 88);
            this.vl10.Name = "vl10";
            this.vl10.Size = new System.Drawing.Size(24, 23);
            this.vl10.TabIndex = 6;
            // 
            // vl5
            // 
            this.vl5.Location = new System.Drawing.Point(426, 88);
            this.vl5.Name = "vl5";
            this.vl5.Size = new System.Drawing.Size(24, 23);
            this.vl5.TabIndex = 6;
            // 
            // vlm5
            // 
            this.vlm5.Location = new System.Drawing.Point(486, 88);
            this.vlm5.Name = "vlm5";
            this.vlm5.Size = new System.Drawing.Size(24, 23);
            this.vlm5.TabIndex = 6;
            // 
            // vlm10
            // 
            this.vlm10.Location = new System.Drawing.Point(516, 88);
            this.vlm10.Name = "vlm10";
            this.vlm10.Size = new System.Drawing.Size(24, 23);
            this.vlm10.TabIndex = 6;
            // 
            // vlm15
            // 
            this.vlm15.Location = new System.Drawing.Point(546, 88);
            this.vlm15.Name = "vlm15";
            this.vlm15.Size = new System.Drawing.Size(24, 23);
            this.vlm15.TabIndex = 6;
            // 
            // vlm20
            // 
            this.vlm20.Location = new System.Drawing.Point(576, 88);
            this.vlm20.Name = "vlm20";
            this.vlm20.Size = new System.Drawing.Size(24, 23);
            this.vlm20.TabIndex = 6;
            // 
            // vl0
            // 
            this.vl0.Location = new System.Drawing.Point(456, 88);
            this.vl0.Name = "vl0";
            this.vl0.Size = new System.Drawing.Size(24, 23);
            this.vl0.TabIndex = 6;
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
            label20.Text = "Anzahl dieser Heizungen im System:";
            label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // instanceNumber
            // 
            this.instanceNumber.Location = new System.Drawing.Point(336, 117);
            this.instanceNumber.Name = "instanceNumber";
            this.instanceNumber.Size = new System.Drawing.Size(100, 23);
            this.instanceNumber.TabIndex = 3;
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
            this.tabConsumer.ResumeLayout(false);
            this.tabConsumer.PerformLayout();
            this.tabWether.ResumeLayout(false);
            this.tabSimulation.ResumeLayout(false);
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
        private TextBox heatCapacity;
        private TextBox lambda;
        private Button saveTemperatureData;
        private Button readTemperatureData;
        private ListBox wetherData;
        private OpenFileDialog openTemperaturFile;
        private Button button1;
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
        private TextBox instanceNumber;
        private TextBox energyPerYear;
    }
}