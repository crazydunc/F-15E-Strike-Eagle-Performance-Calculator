﻿namespace F_15E_Strike_Eagle_Performance_Calculator
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
            components = new System.ComponentModel.Container();
            LegIdTextLabel = new Label();
            panel1 = new Panel();
            buttonStores = new Button();
            label7 = new Label();
            AARtextBox = new TextBox();
            FuelRemLabel = new Label();
            label6 = new Label();
            checkBoxAAR = new CheckBox();
            DelaytextBox = new TextBox();
            labelDelay = new Label();
            label4 = new Label();
            label3 = new Label();
            FuelUsedValueLabel = new Label();
            FuelUsedLabel = new Label();
            SpeedTexbox = new TextBox();
            SpdLabel = new Label();
            AltitudeTextbox = new TextBox();
            AltitudeLabelName = new Label();
            LegDistanceValueLabel = new Label();
            DistanceLabelName = new Label();
            WaypointToNameLabel = new Label();
            WaypointToLabel = new Label();
            WaypointFromNameLabel = new Label();
            WaypointFromLabel = new Label();
            LegIdValueLabel = new Label();
            FuelBurnTt = new ToolTip(components);
            AltTt = new ToolTip(components);
            SpeedTt = new ToolTip(components);
            DelayTt = new ToolTip(components);
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
            panel1.Controls.Add(labelDelay);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(FuelUsedValueLabel);
            panel1.Controls.Add(FuelUsedLabel);
            panel1.Controls.Add(SpeedTexbox);
            panel1.Controls.Add(SpdLabel);
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
            panel1.Size = new Size(956, 48);
            panel1.TabIndex = 1;
            // 
            // buttonStores
            // 
            buttonStores.Location = new Point(722, 13);
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
            label7.Location = new Point(613, 26);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 22;
            label7.Text = "Onload:";
            // 
            // AARtextBox
            // 
            AARtextBox.Enabled = false;
            AARtextBox.Location = new Point(668, 23);
            AARtextBox.Name = "AARtextBox";
            AARtextBox.Size = new Size(48, 23);
            AARtextBox.TabIndex = 21;
            AARtextBox.Text = "0";
            AARtextBox.KeyDown += AARtextBox_KeyUp;
            AARtextBox.Leave += AARtextBox_Leave;
            // 
            // FuelRemLabel
            // 
            FuelRemLabel.AutoSize = true;
            FuelRemLabel.Location = new Point(859, 28);
            FuelRemLabel.Name = "FuelRemLabel";
            FuelRemLabel.Size = new Size(37, 15);
            FuelRemLabel.TabIndex = 20;
            FuelRemLabel.Text = "23456";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(802, 27);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 19;
            label6.Text = "Fuel Rem: ";
            // 
            // checkBoxAAR
            // 
            checkBoxAAR.AutoSize = true;
            checkBoxAAR.Location = new Point(613, 5);
            checkBoxAAR.Name = "checkBoxAAR";
            checkBoxAAR.Size = new Size(49, 19);
            checkBoxAAR.TabIndex = 18;
            checkBoxAAR.Text = "AAR";
            checkBoxAAR.UseVisualStyleBackColor = true;
            checkBoxAAR.CheckedChanged += checkBoxAAR_CheckedChanged;
            // 
            // DelaytextBox
            // 
            DelaytextBox.Location = new Point(579, 13);
            DelaytextBox.Name = "DelaytextBox";
            DelaytextBox.Size = new Size(28, 23);
            DelaytextBox.TabIndex = 17;
            DelaytextBox.Text = "0";
            DelaytextBox.KeyUp += DelaytextBox_KeyUp;
            DelaytextBox.Leave += DelaytextBox_Leave;
            // 
            // labelDelay
            // 
            labelDelay.AutoSize = true;
            labelDelay.Location = new Point(507, 17);
            labelDelay.Name = "labelDelay";
            labelDelay.Size = new Size(76, 15);
            labelDelay.TabIndex = 16;
            labelDelay.Text = "Delay (mins):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(907, 27);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 15;
            label4.Text = "23456";
            label4.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(907, 8);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 14;
            label3.Text = "23456";
            label3.Visible = false;
            // 
            // FuelUsedValueLabel
            // 
            FuelUsedValueLabel.AutoSize = true;
            FuelUsedValueLabel.Location = new Point(859, 8);
            FuelUsedValueLabel.Name = "FuelUsedValueLabel";
            FuelUsedValueLabel.Size = new Size(37, 15);
            FuelUsedValueLabel.TabIndex = 13;
            FuelUsedValueLabel.Text = "23456";
            // 
            // FuelUsedLabel
            // 
            FuelUsedLabel.AutoSize = true;
            FuelUsedLabel.Location = new Point(802, 7);
            FuelUsedLabel.Name = "FuelUsedLabel";
            FuelUsedLabel.Size = new Size(63, 15);
            FuelUsedLabel.TabIndex = 12;
            FuelUsedLabel.Text = "Fuel Burn: ";
            // 
            // SpeedTexbox
            // 
            SpeedTexbox.Location = new Point(464, 13);
            SpeedTexbox.Name = "SpeedTexbox";
            SpeedTexbox.Size = new Size(37, 23);
            SpeedTexbox.TabIndex = 11;
            SpeedTexbox.Text = "600";
            SpeedTexbox.KeyUp += SpeedTexbox_KeyUp;
            SpeedTexbox.Leave += SpeedTexbox_Leave;
            // 
            // SpdLabel
            // 
            SpdLabel.AutoSize = true;
            SpdLabel.Location = new Point(425, 17);
            SpdLabel.Name = "SpdLabel";
            SpdLabel.Size = new Size(33, 15);
            SpdLabel.TabIndex = 10;
            SpdLabel.Text = "KTAS";
            // 
            // AltitudeTextbox
            // 
            AltitudeTextbox.Location = new Point(374, 13);
            AltitudeTextbox.Name = "AltitudeTextbox";
            AltitudeTextbox.Size = new Size(45, 23);
            AltitudeTextbox.TabIndex = 9;
            AltitudeTextbox.Text = "40000";
            AltitudeTextbox.KeyUp += AltitudeTextbox_KeyUp;
            AltitudeTextbox.Leave += AltitudeTextbox_Leave;
            // 
            // AltitudeLabelName
            // 
            AltitudeLabelName.AutoSize = true;
            AltitudeLabelName.Location = new Point(344, 17);
            AltitudeLabelName.Name = "AltitudeLabelName";
            AltitudeLabelName.Size = new Size(25, 15);
            AltitudeLabelName.TabIndex = 8;
            AltitudeLabelName.Text = "Alt:";
            // 
            // LegDistanceValueLabel
            // 
            LegDistanceValueLabel.AutoSize = true;
            LegDistanceValueLabel.Location = new Point(305, 17);
            LegDistanceValueLabel.Name = "LegDistanceValueLabel";
            LegDistanceValueLabel.Size = new Size(25, 15);
            LegDistanceValueLabel.TabIndex = 7;
            LegDistanceValueLabel.Text = "464";
            // 
            // DistanceLabelName
            // 
            DistanceLabelName.AutoSize = true;
            DistanceLabelName.Location = new Point(247, 17);
            DistanceLabelName.Name = "DistanceLabelName";
            DistanceLabelName.Size = new Size(61, 15);
            DistanceLabelName.TabIndex = 6;
            DistanceLabelName.Text = "Dist (NM):";
            // 
            // WaypointToNameLabel
            // 
            WaypointToNameLabel.AutoSize = true;
            WaypointToNameLabel.Location = new Point(96, 26);
            WaypointToNameLabel.Name = "WaypointToNameLabel";
            WaypointToNameLabel.Size = new Size(37, 15);
            WaypointToNameLabel.TabIndex = 5;
            WaypointToNameLabel.Text = "WPT1";
            // 
            // WaypointToLabel
            // 
            WaypointToLabel.AutoSize = true;
            WaypointToLabel.Location = new Point(61, 26);
            WaypointToLabel.Name = "WaypointToLabel";
            WaypointToLabel.Size = new Size(22, 15);
            WaypointToLabel.TabIndex = 4;
            WaypointToLabel.Text = "To:";
            // 
            // WaypointFromNameLabel
            // 
            WaypointFromNameLabel.AutoSize = true;
            WaypointFromNameLabel.Location = new Point(96, 7);
            WaypointFromNameLabel.Name = "WaypointFromNameLabel";
            WaypointFromNameLabel.Size = new Size(41, 15);
            WaypointFromNameLabel.TabIndex = 3;
            WaypointFromNameLabel.Text = "Anapa";
            // 
            // WaypointFromLabel
            // 
            WaypointFromLabel.AutoSize = true;
            WaypointFromLabel.Location = new Point(61, 7);
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
            DoubleBuffered = true;
            Name = "MissionLegUserControl";
            Size = new Size(965, 54);
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
        private Label SpdLabel;
        private TextBox AltitudeTextbox;
        private Label FuelUsedValueLabel;
        private Label FuelUsedLabel;
        private Label label3;
        private Label label4;
        private CheckBox checkBoxAAR;
        private TextBox DelaytextBox;
        private Label labelDelay;
        private Label label7;
        private Label label6;
        private Button buttonStores;
        private ToolTip FuelBurnTt;
        private ToolTip AltTt;
        private ToolTip SpeedTt;
        private ToolTip DelayTt;
    }
}
