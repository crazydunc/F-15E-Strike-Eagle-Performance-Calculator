namespace F_15E_Strike_Eagle_Performance_Calculator
{
    partial class FuelPlanner
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
            ImportDtcButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            labelSpeeds = new Label();
            label10 = new Label();
            JokertextBox = new TextBox();
            label9 = new Label();
            AAROnloadLabel = new Label();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            LandingWeightValueLabel = new Label();
            landingWeightLabel = new Label();
            takeoffWeightLabel = new Label();
            label4 = new Label();
            FuelLoadedLabelValue = new Label();
            FuelLoadedLabel = new Label();
            labelFuelBurn = new Label();
            label5 = new Label();
            labelSuggestedFuel = new Label();
            label3 = new Label();
            textBoxBingo = new TextBox();
            label2 = new Label();
            labelTotalDistance = new Label();
            label1 = new Label();
            buttonCombatFlite = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ImportDtcButton
            // 
            ImportDtcButton.BackColor = SystemColors.GrayText;
            ImportDtcButton.ForeColor = SystemColors.ButtonHighlight;
            ImportDtcButton.Location = new Point(8, 3);
            ImportDtcButton.Name = "ImportDtcButton";
            ImportDtcButton.Size = new Size(94, 39);
            ImportDtcButton.TabIndex = 24;
            ImportDtcButton.Text = "Import DTC";
            ImportDtcButton.UseVisualStyleBackColor = false;
            ImportDtcButton.Click += ImportDtcButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(8, 48);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(990, 636);
            flowLayoutPanel1.TabIndex = 25;
            flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelSpeeds);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(JokertextBox);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(AAROnloadLabel);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(LandingWeightValueLabel);
            groupBox1.Controls.Add(landingWeightLabel);
            groupBox1.Controls.Add(takeoffWeightLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(FuelLoadedLabelValue);
            groupBox1.Controls.Add(FuelLoadedLabel);
            groupBox1.Controls.Add(labelFuelBurn);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(labelSuggestedFuel);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxBingo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(labelTotalDistance);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(1060, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(235, 331);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mission Info";
            // 
            // labelSpeeds
            // 
            labelSpeeds.AutoSize = true;
            labelSpeeds.Location = new Point(146, 108);
            labelSpeeds.Name = "labelSpeeds";
            labelSpeeds.Size = new Size(73, 15);
            labelSpeeds.TabIndex = 21;
            labelSpeeds.Text = "---/--- KCAS";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 108);
            label10.Name = "label10";
            label10.Size = new Size(127, 15);
            label10.TabIndex = 20;
            label10.Text = "Landing Spd (DN/UP): ";
            // 
            // JokertextBox
            // 
            JokertextBox.Location = new Point(146, 252);
            JokertextBox.Name = "JokertextBox";
            JokertextBox.Size = new Size(47, 23);
            JokertextBox.TabIndex = 19;
            JokertextBox.Leave += JokertextBox_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 256);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 18;
            label9.Text = "Joker:";
            // 
            // AAROnloadLabel
            // 
            AAROnloadLabel.AutoSize = true;
            AAROnloadLabel.Location = new Point(146, 228);
            AAROnloadLabel.Name = "AAROnloadLabel";
            AAROnloadLabel.Size = new Size(50, 15);
            AAROnloadLabel.TabIndex = 17;
            AAROnloadLabel.Text = "----- lbs";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 228);
            label8.Name = "label8";
            label8.Size = new Size(121, 15);
            label8.TabIndex = 16;
            label8.Text = "Planned AAR Onload:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(146, 156);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 15;
            label6.Text = "2500 lbs";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 156);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 14;
            label7.Text = "Recovery Fuel:";
            // 
            // LandingWeightValueLabel
            // 
            LandingWeightValueLabel.AutoSize = true;
            LandingWeightValueLabel.Location = new Point(146, 84);
            LandingWeightValueLabel.Name = "LandingWeightValueLabel";
            LandingWeightValueLabel.Size = new Size(50, 15);
            LandingWeightValueLabel.TabIndex = 13;
            LandingWeightValueLabel.Text = "----- lbs";
            // 
            // landingWeightLabel
            // 
            landingWeightLabel.AutoSize = true;
            landingWeightLabel.Location = new Point(16, 84);
            landingWeightLabel.Name = "landingWeightLabel";
            landingWeightLabel.Size = new Size(97, 15);
            landingWeightLabel.TabIndex = 12;
            landingWeightLabel.Text = "Landing Weight: ";
            // 
            // takeoffWeightLabel
            // 
            takeoffWeightLabel.AutoSize = true;
            takeoffWeightLabel.Location = new Point(146, 60);
            takeoffWeightLabel.Name = "takeoffWeightLabel";
            takeoffWeightLabel.Size = new Size(50, 15);
            takeoffWeightLabel.TabIndex = 11;
            takeoffWeightLabel.Text = "----- lbs";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 60);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 10;
            label4.Text = "Takeoff Weight: ";
            // 
            // FuelLoadedLabelValue
            // 
            FuelLoadedLabelValue.AutoSize = true;
            FuelLoadedLabelValue.Location = new Point(146, 204);
            FuelLoadedLabelValue.Name = "FuelLoadedLabelValue";
            FuelLoadedLabelValue.Size = new Size(50, 15);
            FuelLoadedLabelValue.TabIndex = 9;
            FuelLoadedLabelValue.Text = "----- lbs";
            // 
            // FuelLoadedLabel
            // 
            FuelLoadedLabel.AutoSize = true;
            FuelLoadedLabel.Location = new Point(16, 204);
            FuelLoadedLabel.Name = "FuelLoadedLabel";
            FuelLoadedLabel.Size = new Size(74, 15);
            FuelLoadedLabel.TabIndex = 8;
            FuelLoadedLabel.Text = "Fuel Loaded:";
            // 
            // labelFuelBurn
            // 
            labelFuelBurn.AutoSize = true;
            labelFuelBurn.Location = new Point(146, 132);
            labelFuelBurn.Name = "labelFuelBurn";
            labelFuelBurn.Size = new Size(50, 15);
            labelFuelBurn.TabIndex = 7;
            labelFuelBurn.Text = "----- lbs";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 132);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 6;
            label5.Text = "Route Fuel Burn: ";
            // 
            // labelSuggestedFuel
            // 
            labelSuggestedFuel.AutoSize = true;
            labelSuggestedFuel.Location = new Point(146, 180);
            labelSuggestedFuel.Name = "labelSuggestedFuel";
            labelSuggestedFuel.Size = new Size(50, 15);
            labelSuggestedFuel.TabIndex = 5;
            labelSuggestedFuel.Text = "----- lbs";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 180);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 4;
            label3.Text = "Est Req Fuel: ";
            // 
            // textBoxBingo
            // 
            textBoxBingo.Location = new Point(146, 284);
            textBoxBingo.Name = "textBoxBingo";
            textBoxBingo.Size = new Size(47, 23);
            textBoxBingo.TabIndex = 3;
            textBoxBingo.Leave += textBoxBingo_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 288);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 2;
            label2.Text = "Bingo: ";
            // 
            // labelTotalDistance
            // 
            labelTotalDistance.AutoSize = true;
            labelTotalDistance.Location = new Point(146, 36);
            labelTotalDistance.Name = "labelTotalDistance";
            labelTotalDistance.Size = new Size(50, 15);
            labelTotalDistance.TabIndex = 1;
            labelTotalDistance.Text = "---- NM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 36);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Total Distance:";
            // 
            // buttonCombatFlite
            // 
            buttonCombatFlite.BackColor = SystemColors.GrayText;
            buttonCombatFlite.ForeColor = SystemColors.ButtonHighlight;
            buttonCombatFlite.Location = new Point(108, 3);
            buttonCombatFlite.Name = "buttonCombatFlite";
            buttonCombatFlite.Size = new Size(94, 39);
            buttonCombatFlite.TabIndex = 27;
            buttonCombatFlite.Text = "Import CF";
            buttonCombatFlite.UseVisualStyleBackColor = false;
            buttonCombatFlite.Click += buttonCombatFlite_Click;
            // 
            // FuelPlanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(buttonCombatFlite);
            Controls.Add(groupBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(ImportDtcButton);
            DoubleBuffered = true;
            Name = "FuelPlanner";
            Size = new Size(1345, 694);
            VisibleChanged += FuelPlanner_VisibleChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button ImportDtcButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private Label label1;
        private Label labelTotalDistance;
        private TextBox textBoxBingo;
        private Label label2;
        private Label labelSuggestedFuel;
        private Label label3;
        private Label labelFuelBurn;
        private Label label5;
        private Label FuelLoadedLabelValue;
        private Label FuelLoadedLabel;
        private Label label6;
        private Label label7;
        private Label LandingWeightValueLabel;
        private Label landingWeightLabel;
        private Label takeoffWeightLabel;
        private Label label4;
        private TextBox JokertextBox;
        private Label label9;
        private Label AAROnloadLabel;
        private Label label8;
        private Label label10;
        private Label labelSpeeds;
        private Button buttonCombatFlite;
    }
}
