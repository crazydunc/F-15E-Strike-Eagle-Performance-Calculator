namespace F_15E_Strike_Eagle_Performance_Calculator
{
    partial class MissionLegUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LegIdTextLabel = new Label();
            panel1 = new Panel();
            buttonStores = new Button();
            label7 = new Label();
            AARtextBox = new TextBox();
            FuelRemLabel = new Label();
            label6 = new Label();
            checkBoxAAR = new CheckBox();
            DelaytextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            FuelUsedValueLabel = new Label();
            FuelUsedLabel = new Label();
            SpeedTexbox = new TextBox();
            label1 = new Label();
            AltitudeTextbox = new TextBox();
            AltitudeLabelName = new Label();
            LegDistanceValueLabel = new Label();
            DistanceLabelName = new Label();
            WaypointToNameLabel = new Label();
            WaypointToLabel = new Label();
            WaypointFromNameLabel = new Label();
            WaypointFromLabel = new Label();
            LegIdValueLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LegIdTextLabel
            // 
            LegIdTextLabel.AutoSize = true;
            LegIdTextLabel.Location = new Point(5, 17);
            LegIdTextLabel.Name = "LegIdTextLabel";
            LegIdTextLabel.Size = new Size(29, 15);
            LegIdTextLabel.TabIndex = 0;
            LegIdTextLabel.Text = "Leg:";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonStores);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(AARtextBox);
            panel1.Controls.Add(FuelRemLabel);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(checkBoxAAR);
            panel1.Controls.Add(DelaytextBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(FuelUsedValueLabel);
            panel1.Controls.Add(FuelUsedLabel);
            panel1.Controls.Add(SpeedTexbox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(AltitudeTextbox);
            panel1.Controls.Add(AltitudeLabelName);
            panel1.Controls.Add(LegDistanceValueLabel);
            panel1.Controls.Add(DistanceLabelName);
            panel1.Controls.Add(WaypointToNameLabel);
            panel1.Controls.Add(WaypointToLabel);
            panel1.Controls.Add(WaypointFromNameLabel);
            panel1.Controls.Add(WaypointFromLabel);
            panel1.Controls.Add(LegIdValueLabel);
            panel1.Controls.Add(LegIdTextLabel);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1053, 48);
            panel1.TabIndex = 1;
            // 
            // buttonStores
            // 
            buttonStores.Location = new Point(829, 13);
            buttonStores.Name = "buttonStores";
            buttonStores.Size = new Size(75, 23);
            buttonStores.TabIndex = 23;
            buttonStores.Text = "Stores";
            buttonStores.UseVisualStyleBackColor = true;
            buttonStores.Visible = false;
            buttonStores.Click += buttonStores_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(720, 26);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 22;
            label7.Text = "Onload:";
            // 
            // AARtextBox
            // 
            AARtextBox.Enabled = false;
            AARtextBox.Location = new Point(775, 23);
            AARtextBox.Name = "AARtextBox";
            AARtextBox.Size = new Size(48, 23);
            AARtextBox.TabIndex = 21;
            AARtextBox.Text = "0";
            AARtextBox.Leave += AARtextBox_Leave;
            // 
            // FuelRemLabel
            // 
            FuelRemLabel.AutoSize = true;
            FuelRemLabel.Location = new Point(966, 28);
            FuelRemLabel.Name = "FuelRemLabel";
            FuelRemLabel.Size = new Size(37, 15);
            FuelRemLabel.TabIndex = 20;
            FuelRemLabel.Text = "23456";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(909, 27);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 19;
            label6.Text = "Fuel Rem: ";
            // 
            // checkBoxAAR
            // 
            checkBoxAAR.AutoSize = true;
            checkBoxAAR.Location = new Point(720, 5);
            checkBoxAAR.Name = "checkBoxAAR";
            checkBoxAAR.Size = new Size(49, 19);
            checkBoxAAR.TabIndex = 18;
            checkBoxAAR.Text = "AAR";
            checkBoxAAR.UseVisualStyleBackColor = true;
            checkBoxAAR.CheckedChanged += checkBoxAAR_CheckedChanged;
            // 
            // DelaytextBox
            // 
            DelaytextBox.Location = new Point(686, 13);
            DelaytextBox.Name = "DelaytextBox";
            DelaytextBox.Size = new Size(28, 23);
            DelaytextBox.TabIndex = 17;
            DelaytextBox.Text = "0";
            DelaytextBox.Leave += DelaytextBox_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(614, 17);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 16;
            label5.Text = "Delay (mins):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1014, 27);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 15;
            label4.Text = "23456";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1014, 8);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 14;
            label3.Text = "23456";
            // 
            // FuelUsedValueLabel
            // 
            FuelUsedValueLabel.AutoSize = true;
            FuelUsedValueLabel.Location = new Point(966, 8);
            FuelUsedValueLabel.Name = "FuelUsedValueLabel";
            FuelUsedValueLabel.Size = new Size(37, 15);
            FuelUsedValueLabel.TabIndex = 13;
            FuelUsedValueLabel.Text = "23456";
            // 
            // FuelUsedLabel
            // 
            FuelUsedLabel.AutoSize = true;
            FuelUsedLabel.Location = new Point(909, 7);
            FuelUsedLabel.Name = "FuelUsedLabel";
            FuelUsedLabel.Size = new Size(63, 15);
            FuelUsedLabel.TabIndex = 12;
            FuelUsedLabel.Text = "Fuel Burn: ";
            // 
            // SpeedTexbox
            // 
            SpeedTexbox.Location = new Point(571, 13);
            SpeedTexbox.Name = "SpeedTexbox";
            SpeedTexbox.Size = new Size(37, 23);
            SpeedTexbox.TabIndex = 11;
            SpeedTexbox.Text = "600";
            SpeedTexbox.Leave += SpeedTexbox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(532, 17);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 10;
            label1.Text = "KTAS";
            // 
            // AltitudeTextbox
            // 
            AltitudeTextbox.Location = new Point(481, 13);
            AltitudeTextbox.Name = "AltitudeTextbox";
            AltitudeTextbox.Size = new Size(45, 23);
            AltitudeTextbox.TabIndex = 9;
            AltitudeTextbox.Text = "40000";
            AltitudeTextbox.Leave += AltitudeTextbox_TextChanged;
            // 
            // AltitudeLabelName
            // 
            AltitudeLabelName.AutoSize = true;
            AltitudeLabelName.Location = new Point(451, 17);
            AltitudeLabelName.Name = "AltitudeLabelName";
            AltitudeLabelName.Size = new Size(25, 15);
            AltitudeLabelName.TabIndex = 8;
            AltitudeLabelName.Text = "Alt:";
            // 
            // LegDistanceValueLabel
            // 
            LegDistanceValueLabel.AutoSize = true;
            LegDistanceValueLabel.Location = new Point(412, 17);
            LegDistanceValueLabel.Name = "LegDistanceValueLabel";
            LegDistanceValueLabel.Size = new Size(25, 15);
            LegDistanceValueLabel.TabIndex = 7;
            LegDistanceValueLabel.Text = "464";
            // 
            // DistanceLabelName
            // 
            DistanceLabelName.AutoSize = true;
            DistanceLabelName.Location = new Point(354, 17);
            DistanceLabelName.Name = "DistanceLabelName";
            DistanceLabelName.Size = new Size(61, 15);
            DistanceLabelName.TabIndex = 6;
            DistanceLabelName.Text = "Dist (NM):";
            // 
            // WaypointToNameLabel
            // 
            WaypointToNameLabel.AutoSize = true;
            WaypointToNameLabel.Location = new Point(218, 17);
            WaypointToNameLabel.Name = "WaypointToNameLabel";
            WaypointToNameLabel.Size = new Size(37, 15);
            WaypointToNameLabel.TabIndex = 5;
            WaypointToNameLabel.Text = "WPT1";
            // 
            // WaypointToLabel
            // 
            WaypointToLabel.AutoSize = true;
            WaypointToLabel.Location = new Point(196, 17);
            WaypointToLabel.Name = "WaypointToLabel";
            WaypointToLabel.Size = new Size(22, 15);
            WaypointToLabel.TabIndex = 4;
            WaypointToLabel.Text = "To:";
            // 
            // WaypointFromNameLabel
            // 
            WaypointFromNameLabel.AutoSize = true;
            WaypointFromNameLabel.Location = new Point(91, 17);
            WaypointFromNameLabel.Name = "WaypointFromNameLabel";
            WaypointFromNameLabel.Size = new Size(41, 15);
            WaypointFromNameLabel.TabIndex = 3;
            WaypointFromNameLabel.Text = "Anapa";
            // 
            // WaypointFromLabel
            // 
            WaypointFromLabel.AutoSize = true;
            WaypointFromLabel.Location = new Point(56, 17);
            WaypointFromLabel.Name = "WaypointFromLabel";
            WaypointFromLabel.Size = new Size(38, 15);
            WaypointFromLabel.TabIndex = 2;
            WaypointFromLabel.Text = "From:";
            // 
            // LegIdValueLabel
            // 
            LegIdValueLabel.AutoSize = true;
            LegIdValueLabel.Location = new Point(30, 17);
            LegIdValueLabel.Name = "LegIdValueLabel";
            LegIdValueLabel.Size = new Size(25, 15);
            LegIdValueLabel.TabIndex = 1;
            LegIdValueLabel.Text = "199";
            // 
            // MissionLegUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Controls.Add(panel1);
            Name = "MissionLegUserControl";
            Size = new Size(1061, 54);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label LegIdTextLabel;
        private Panel panel1;
        private Label LegDistanceValueLabel;
        private Label DistanceLabelName;
        private Label WaypointToNameLabel;
        private Label WaypointToLabel;
        private Label WaypointFromNameLabel;
        private Label WaypointFromLabel;
        private Label LegIdValueLabel;
        private Label AltitudeLabelName;
        private TextBox AARtextBox;
        private Label FuelRemLabel;
        private TextBox SpeedTexbox;
        private Label label1;
        private TextBox AltitudeTextbox;
        private Label FuelUsedValueLabel;
        private Label FuelUsedLabel;
        private Label label3;
        private Label label4;
        private CheckBox checkBoxAAR;
        private TextBox DelaytextBox;
        private Label label5;
        private Label label7;
        private Label label6;
        private Button buttonStores;
    }
}
