﻿namespace F_15E_Strike_Eagle_Performance_Calculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.calcuateButton = new System.Windows.Forms.Button();
            this.takeoffWeightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.runwayElevationTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.OATTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RotationCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxsta8b = new System.Windows.Forms.ComboBox();
            this.comboBoxsta8 = new System.Windows.Forms.ComboBox();
            this.comboBoxsta8a = new System.Windows.Forms.ComboBox();
            this.comboBoxrcft = new System.Windows.Forms.ComboBox();
            this.comboBoxlnp = new System.Windows.Forms.ComboBox();
            this.comboBoxsta5 = new System.Windows.Forms.ComboBox();
            this.comboBoxltp = new System.Windows.Forms.ComboBox();
            this.comboBoxLcft = new System.Windows.Forms.ComboBox();
            this.comboBoxsta2b = new System.Windows.Forms.ComboBox();
            this.comboBoxsta2 = new System.Windows.Forms.ComboBox();
            this.comboBoxSta2a = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.fuelLabel = new System.Windows.Forms.Label();
            this.payloadLabel = new System.Windows.Forms.Label();
            this.LatAsymLabel = new System.Windows.Forms.Label();
            this.DragLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // calcuateButton
            // 
            this.calcuateButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.calcuateButton.Location = new System.Drawing.Point(79, 138);
            this.calcuateButton.Name = "calcuateButton";
            this.calcuateButton.Size = new System.Drawing.Size(75, 23);
            this.calcuateButton.TabIndex = 0;
            this.calcuateButton.Text = "Calculate";
            this.calcuateButton.UseVisualStyleBackColor = false;
            this.calcuateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // takeoffWeightTextBox
            // 
            this.takeoffWeightTextBox.Location = new System.Drawing.Point(125, 20);
            this.takeoffWeightTextBox.Name = "takeoffWeightTextBox";
            this.takeoffWeightTextBox.Size = new System.Drawing.Size(44, 23);
            this.takeoffWeightTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rotation/Nosewheel Liftoff/Takeoff Speeds:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "---/---/--- KCAS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ground Roll Distance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "---- Ft";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Takeoff Weight (Lbs)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Elevation (ft)";
            // 
            // runwayElevationTextBox
            // 
            this.runwayElevationTextBox.Location = new System.Drawing.Point(125, 44);
            this.runwayElevationTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.runwayElevationTextBox.Name = "runwayElevationTextBox";
            this.runwayElevationTextBox.Size = new System.Drawing.Size(44, 23);
            this.runwayElevationTextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "OAT (C)";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 92);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 19);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Max Thrust";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(125, 92);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 19);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "Mil Thrust";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // OATTextBox
            // 
            this.OATTextBox.Location = new System.Drawing.Point(125, 68);
            this.OATTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.OATTextBox.Name = "OATTextBox";
            this.OATTextBox.Size = new System.Drawing.Size(44, 23);
            this.OATTextBox.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Controls.Add(this.RotationCheckBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.OATTextBox);
            this.groupBox1.Controls.Add(this.calcuateButton);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.takeoffWeightTextBox);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.runwayElevationTextBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(217, 166);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // RotationCheckBox
            // 
            this.RotationCheckBox.AutoSize = true;
            this.RotationCheckBox.Location = new System.Drawing.Point(4, 113);
            this.RotationCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.RotationCheckBox.Name = "RotationCheckBox";
            this.RotationCheckBox.Size = new System.Drawing.Size(91, 19);
            this.RotationCheckBox.TabIndex = 14;
            this.RotationCheckBox.Text = "10° Rotation";
            this.RotationCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(264, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(356, 90);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::F_15E_Strike_Eagle_Performance_Calculator.Properties.Resources.DM_2220_2___Copy1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 142);
            this.panel1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ErrorImage = global::F_15E_Strike_Eagle_Performance_Calculator.Properties.Resources._48th_Fighter_Wing;
            this.pictureBox1.Image = global::F_15E_Strike_Eagle_Performance_Calculator.Properties.Resources._48th_Fighter_Wing;
            this.pictureBox1.Location = new System.Drawing.Point(531, 811);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(0, 902);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "© Duncan MacKellar 2023";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(3, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 181);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.comboBoxsta8b);
            this.panel3.Controls.Add(this.comboBoxsta8);
            this.panel3.Controls.Add(this.comboBoxsta8a);
            this.panel3.Controls.Add(this.comboBoxrcft);
            this.panel3.Controls.Add(this.comboBoxlnp);
            this.panel3.Controls.Add(this.comboBoxsta5);
            this.panel3.Controls.Add(this.comboBoxltp);
            this.panel3.Controls.Add(this.comboBoxLcft);
            this.panel3.Controls.Add(this.comboBoxsta2b);
            this.panel3.Controls.Add(this.comboBoxsta2);
            this.panel3.Controls.Add(this.comboBoxSta2a);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(5, 335);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 471);
            this.panel3.TabIndex = 20;
            // 
            // comboBoxsta8b
            // 
            this.comboBoxsta8b.FormattingEnabled = true;
            this.comboBoxsta8b.Location = new System.Drawing.Point(526, 304);
            this.comboBoxsta8b.Name = "comboBoxsta8b";
            this.comboBoxsta8b.Size = new System.Drawing.Size(100, 23);
            this.comboBoxsta8b.TabIndex = 13;
            this.comboBoxsta8b.SelectedIndexChanged += new System.EventHandler(this.comboBoxsta8b_SelectedIndexChanged);
            // 
            // comboBoxsta8
            // 
            this.comboBoxsta8.FormattingEnabled = true;
            this.comboBoxsta8.Location = new System.Drawing.Point(493, 244);
            this.comboBoxsta8.Name = "comboBoxsta8";
            this.comboBoxsta8.Size = new System.Drawing.Size(100, 23);
            this.comboBoxsta8.TabIndex = 12;
            this.comboBoxsta8.SelectedIndexChanged += new System.EventHandler(this.comboBoxsta8_SelectedIndexChanged);
            // 
            // comboBoxsta8a
            // 
            this.comboBoxsta8a.FormattingEnabled = true;
            this.comboBoxsta8a.Location = new System.Drawing.Point(447, 273);
            this.comboBoxsta8a.Name = "comboBoxsta8a";
            this.comboBoxsta8a.Size = new System.Drawing.Size(100, 23);
            this.comboBoxsta8a.TabIndex = 11;
            this.comboBoxsta8a.SelectedIndexChanged += new System.EventHandler(this.comboBoxsta8a_SelectedIndexChanged);
            // 
            // comboBoxrcft
            // 
            this.comboBoxrcft.FormattingEnabled = true;
            this.comboBoxrcft.Location = new System.Drawing.Point(380, 244);
            this.comboBoxrcft.Name = "comboBoxrcft";
            this.comboBoxrcft.Size = new System.Drawing.Size(100, 23);
            this.comboBoxrcft.TabIndex = 10;
            this.comboBoxrcft.SelectedIndexChanged += new System.EventHandler(this.comboBoxrcft_SelectedIndexChanged);
            // 
            // comboBoxlnp
            // 
            this.comboBoxlnp.FormattingEnabled = true;
            this.comboBoxlnp.Location = new System.Drawing.Point(316, 275);
            this.comboBoxlnp.Name = "comboBoxlnp";
            this.comboBoxlnp.Size = new System.Drawing.Size(100, 23);
            this.comboBoxlnp.TabIndex = 8;
            this.comboBoxlnp.SelectedIndexChanged += new System.EventHandler(this.comboBoxlnp_SelectedIndexChanged);
            // 
            // comboBoxsta5
            // 
            this.comboBoxsta5.FormattingEnabled = true;
            this.comboBoxsta5.Location = new System.Drawing.Point(259, 244);
            this.comboBoxsta5.Name = "comboBoxsta5";
            this.comboBoxsta5.Size = new System.Drawing.Size(100, 23);
            this.comboBoxsta5.TabIndex = 7;
            this.comboBoxsta5.SelectedIndexChanged += new System.EventHandler(this.comboBoxsta5_SelectedIndexChanged);
            // 
            // comboBoxltp
            // 
            this.comboBoxltp.FormattingEnabled = true;
            this.comboBoxltp.Location = new System.Drawing.Point(210, 275);
            this.comboBoxltp.Name = "comboBoxltp";
            this.comboBoxltp.Size = new System.Drawing.Size(100, 23);
            this.comboBoxltp.TabIndex = 6;
            this.comboBoxltp.SelectedIndexChanged += new System.EventHandler(this.comboBoxltp_SelectedIndexChanged);
            // 
            // comboBoxLcft
            // 
            this.comboBoxLcft.FormattingEnabled = true;
            this.comboBoxLcft.Location = new System.Drawing.Point(140, 244);
            this.comboBoxLcft.Name = "comboBoxLcft";
            this.comboBoxLcft.Size = new System.Drawing.Size(100, 23);
            this.comboBoxLcft.TabIndex = 4;
            this.comboBoxLcft.SelectedIndexChanged += new System.EventHandler(this.comboBoxLcft_SelectedIndexChanged);
            // 
            // comboBoxsta2b
            // 
            this.comboBoxsta2b.FormattingEnabled = true;
            this.comboBoxsta2b.Location = new System.Drawing.Point(74, 304);
            this.comboBoxsta2b.Name = "comboBoxsta2b";
            this.comboBoxsta2b.Size = new System.Drawing.Size(100, 23);
            this.comboBoxsta2b.TabIndex = 3;
            this.comboBoxsta2b.SelectedIndexChanged += new System.EventHandler(this.comboBoxsta2b_SelectedIndexChanged);
            // 
            // comboBoxsta2
            // 
            this.comboBoxsta2.FormattingEnabled = true;
            this.comboBoxsta2.Location = new System.Drawing.Point(29, 244);
            this.comboBoxsta2.Name = "comboBoxsta2";
            this.comboBoxsta2.Size = new System.Drawing.Size(100, 23);
            this.comboBoxsta2.TabIndex = 2;
            this.comboBoxsta2.SelectedIndexChanged += new System.EventHandler(this.comboBoxsta2_SelectedIndexChanged);
            // 
            // comboBoxSta2a
            // 
            this.comboBoxSta2a.FormattingEnabled = true;
            this.comboBoxSta2a.Location = new System.Drawing.Point(0, 275);
            this.comboBoxSta2a.Name = "comboBoxSta2a";
            this.comboBoxSta2a.Size = new System.Drawing.Size(100, 23);
            this.comboBoxSta2a.TabIndex = 1;
            this.comboBoxSta2a.SelectedIndexChanged += new System.EventHandler(this.comboBoxSta2a_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::F_15E_Strike_Eagle_Performance_Calculator.Properties.Resources.F15E_Stations;
            this.pictureBox2.Location = new System.Drawing.Point(0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(627, 235);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.weightLabel);
            this.groupBox3.Controls.Add(this.DragLabel);
            this.groupBox3.Controls.Add(this.LatAsymLabel);
            this.groupBox3.Controls.Add(this.payloadLabel);
            this.groupBox3.Controls.Add(this.fuelLabel);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(210, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 112);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loadout Information";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Gross Weight:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Payload:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(79, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Fuel:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Lateral Asymmetry:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "Drag Index:";
            // 
            // fuelLabel
            // 
            this.fuelLabel.AutoSize = true;
            this.fuelLabel.Location = new System.Drawing.Point(116, 19);
            this.fuelLabel.Name = "fuelLabel";
            this.fuelLabel.Size = new System.Drawing.Size(0, 15);
            this.fuelLabel.TabIndex = 5;
            // 
            // payloadLabel
            // 
            this.payloadLabel.AutoSize = true;
            this.payloadLabel.Location = new System.Drawing.Point(116, 36);
            this.payloadLabel.Name = "payloadLabel";
            this.payloadLabel.Size = new System.Drawing.Size(0, 15);
            this.payloadLabel.TabIndex = 6;
            // 
            // LatAsymLabel
            // 
            this.LatAsymLabel.AutoSize = true;
            this.LatAsymLabel.Location = new System.Drawing.Point(116, 53);
            this.LatAsymLabel.Name = "LatAsymLabel";
            this.LatAsymLabel.Size = new System.Drawing.Size(0, 15);
            this.LatAsymLabel.TabIndex = 7;
            // 
            // DragLabel
            // 
            this.DragLabel.AutoSize = true;
            this.DragLabel.Location = new System.Drawing.Point(116, 70);
            this.DragLabel.Name = "DragLabel";
            this.DragLabel.Size = new System.Drawing.Size(0, 15);
            this.DragLabel.TabIndex = 8;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(116, 87);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(0, 15);
            this.weightLabel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(634, 926);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "F-15E Strike Eagle Performance Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button calcuateButton;
        private TextBox takeoffWeightTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox runwayElevationTextBox;
        private Label label7;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox OATTextBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private CheckBox RotationCheckBox;
        private Label label8;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBoxsta8b;
        private ComboBox comboBoxsta8;
        private ComboBox comboBoxsta8a;
        private ComboBox comboBoxrcft;
        private ComboBox comboBoxlnp;
        private ComboBox comboBoxsta5;
        private ComboBox comboBoxltp;
        private ComboBox comboBoxLcft;
        private ComboBox comboBoxsta2b;
        private ComboBox comboBoxsta2;
        private ComboBox comboBoxSta2a;
        private PictureBox pictureBox2;
        private GroupBox groupBox3;
        private Label weightLabel;
        private Label DragLabel;
        private Label LatAsymLabel;
        private Label payloadLabel;
        private Label fuelLabel;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
    }
}