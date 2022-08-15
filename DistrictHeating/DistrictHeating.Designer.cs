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
            this.tabGraphics = new System.Windows.Forms.TabPage();
            this.openTemperaturFile = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.tabPlant.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBHTES.SuspendLayout();
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
    }
}