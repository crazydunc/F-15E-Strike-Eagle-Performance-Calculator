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
            components = new System.ComponentModel.Container();
            ImportDtcButton = new Button();
            routeFlowPanel = new FlowLayoutPanel();
            missionInfoGroupBox = new GroupBox();
            checkBoxCombat = new CheckBox();
            fuelLabelNet = new Label();
            labelFuelNet = new Label();
            labelSpeeds = new Label();
            label10 = new Label();
            JokertextBox = new TextBox();
            JokerLabel = new Label();
            AAROnloadLabel = new Label();
            label8 = new Label();
            RecoveryFuelLabel = new Label();
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
            BingoLabel = new Label();
            labelTotalDistance = new Label();
            label1 = new Label();
            buttonCombatFlite = new Button();
            groupBox2 = new GroupBox();
            textBoxLog = new TextBox();
            DistTt = new ToolTip(components);
            TowTt = new ToolTip(components);
            fuelNetTt = new ToolTip(components);
            LawTt = new ToolTip(components);
            LandingSpdTt = new ToolTip(components);
            FuelBurnTt = new ToolTip(components);
            RecFuelTt = new ToolTip(components);
            ReqFuelTt = new ToolTip(components);
            FuelLoadedTt = new ToolTip(components);
            AarOnloadTt = new ToolTip(components);
            JokerTt = new ToolTip(components);
            BingoTt = new ToolTip(components);
            toolTipCmbt = new ToolTip(components);
            buttonTw = new Button();
            dtcTt = new ToolTip(components);
            CfTt = new ToolTip(components);
            TwTt = new ToolTip(components);
            missionInfoGroupBox.SuspendLayout();
            groupBox2.SuspendLayout();
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
            // routeFlowPanel
            // 
            routeFlowPanel.AutoScroll = true;
            routeFlowPanel.Location = new Point(8, 48);
            routeFlowPanel.Name = "routeFlowPanel";
            routeFlowPanel.Size = new Size(990, 503);
            routeFlowPanel.TabIndex = 25;
            routeFlowPanel.ControlAdded += RouteFlowPanelControlAdded;
            // 
            // missionInfoGroupBox
            // 
            missionInfoGroupBox.Controls.Add(checkBoxCombat);
            missionInfoGroupBox.Controls.Add(fuelLabelNet);
            missionInfoGroupBox.Controls.Add(labelFuelNet);
            missionInfoGroupBox.Controls.Add(labelSpeeds);
            missionInfoGroupBox.Controls.Add(label10);
            missionInfoGroupBox.Controls.Add(JokertextBox);
            missionInfoGroupBox.Controls.Add(JokerLabel);
            missionInfoGroupBox.Controls.Add(AAROnloadLabel);
            missionInfoGroupBox.Controls.Add(label8);
            missionInfoGroupBox.Controls.Add(RecoveryFuelLabel);
            missionInfoGroupBox.Controls.Add(label7);
            missionInfoGroupBox.Controls.Add(LandingWeightValueLabel);
            missionInfoGroupBox.Controls.Add(landingWeightLabel);
            missionInfoGroupBox.Controls.Add(takeoffWeightLabel);
            missionInfoGroupBox.Controls.Add(label4);
            missionInfoGroupBox.Controls.Add(FuelLoadedLabelValue);
            missionInfoGroupBox.Controls.Add(FuelLoadedLabel);
            missionInfoGroupBox.Controls.Add(labelFuelBurn);
            missionInfoGroupBox.Controls.Add(label5);
            missionInfoGroupBox.Controls.Add(labelSuggestedFuel);
            missionInfoGroupBox.Controls.Add(label3);
            missionInfoGroupBox.Controls.Add(textBoxBingo);
            missionInfoGroupBox.Controls.Add(BingoLabel);
            missionInfoGroupBox.Controls.Add(labelTotalDistance);
            missionInfoGroupBox.Controls.Add(label1);
            missionInfoGroupBox.ForeColor = SystemColors.ButtonHighlight;
            missionInfoGroupBox.Location = new Point(1060, 48);
            missionInfoGroupBox.Name = "missionInfoGroupBox";
            missionInfoGroupBox.Size = new Size(235, 368);
            missionInfoGroupBox.TabIndex = 26;
            missionInfoGroupBox.TabStop = false;
            missionInfoGroupBox.Text = "Mission Info";
            // 
            // checkBoxCombat
            // 
            checkBoxCombat.AutoSize = true;
            checkBoxCombat.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxCombat.Location = new Point(16, 180);
            checkBoxCombat.Name = "checkBoxCombat";
            checkBoxCombat.Size = new Size(148, 19);
            checkBoxCombat.TabIndex = 24;
            checkBoxCombat.Text = "Combat Reserve            ";
            checkBoxCombat.UseVisualStyleBackColor = true;
            checkBoxCombat.CheckedChanged += checkBoxCombat_CheckedChanged;
            // 
            // fuelLabelNet
            // 
            fuelLabelNet.AutoSize = true;
            fuelLabelNet.Location = new Point(146, 277);
            fuelLabelNet.Name = "fuelLabelNet";
            fuelLabelNet.Size = new Size(50, 15);
            fuelLabelNet.TabIndex = 23;
            fuelLabelNet.Text = "----- lbs";
            // 
            // labelFuelNet
            // 
            labelFuelNet.AutoSize = true;
            labelFuelNet.Location = new Point(16, 277);
            labelFuelNet.Name = "labelFuelNet";
            labelFuelNet.Size = new Size(50, 15);
            labelFuelNet.TabIndex = 22;
            labelFuelNet.Text = "Fuel +/-";
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
            JokertextBox.Location = new Point(146, 302);
            JokertextBox.Name = "JokertextBox";
            JokertextBox.Size = new Size(47, 23);
            JokertextBox.TabIndex = 19;
            JokertextBox.Leave += JokertextBox_Leave;
            // 
            // JokerLabel
            // 
            JokerLabel.AutoSize = true;
            JokerLabel.Location = new Point(16, 306);
            JokerLabel.Name = "JokerLabel";
            JokerLabel.Size = new Size(37, 15);
            JokerLabel.TabIndex = 18;
            JokerLabel.Text = "Joker:";
            // 
            // AAROnloadLabel
            // 
            AAROnloadLabel.AutoSize = true;
            AAROnloadLabel.Location = new Point(146, 252);
            AAROnloadLabel.Name = "AAROnloadLabel";
            AAROnloadLabel.Size = new Size(50, 15);
            AAROnloadLabel.TabIndex = 17;
            AAROnloadLabel.Text = "----- lbs";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 252);
            label8.Name = "label8";
            label8.Size = new Size(121, 15);
            label8.TabIndex = 16;
            label8.Text = "Planned AAR Onload:";
            // 
            // RecoveryFuelLabel
            // 
            RecoveryFuelLabel.AutoSize = true;
            RecoveryFuelLabel.Location = new Point(146, 156);
            RecoveryFuelLabel.Name = "RecoveryFuelLabel";
            RecoveryFuelLabel.Size = new Size(49, 15);
            RecoveryFuelLabel.TabIndex = 15;
            RecoveryFuelLabel.Text = "2500 lbs";
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
            FuelLoadedLabelValue.Location = new Point(146, 228);
            FuelLoadedLabelValue.Name = "FuelLoadedLabelValue";
            FuelLoadedLabelValue.Size = new Size(50, 15);
            FuelLoadedLabelValue.TabIndex = 9;
            FuelLoadedLabelValue.Text = "----- lbs";
            // 
            // FuelLoadedLabel
            // 
            FuelLoadedLabel.AutoSize = true;
            FuelLoadedLabel.Location = new Point(16, 228);
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
            labelSuggestedFuel.Location = new Point(146, 204);
            labelSuggestedFuel.Name = "labelSuggestedFuel";
            labelSuggestedFuel.Size = new Size(50, 15);
            labelSuggestedFuel.TabIndex = 5;
            labelSuggestedFuel.Text = "----- lbs";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 204);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 4;
            label3.Text = "Est Req Fuel: ";
            // 
            // textBoxBingo
            // 
            textBoxBingo.Location = new Point(146, 334);
            textBoxBingo.Name = "textBoxBingo";
            textBoxBingo.Size = new Size(47, 23);
            textBoxBingo.TabIndex = 3;
            textBoxBingo.Leave += textBoxBingo_Leave;
            // 
            // BingoLabel
            // 
            BingoLabel.AutoSize = true;
            BingoLabel.Location = new Point(16, 338);
            BingoLabel.Name = "BingoLabel";
            BingoLabel.Size = new Size(44, 15);
            BingoLabel.TabIndex = 2;
            BingoLabel.Text = "Bingo: ";
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
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxLog);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(11, 557);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(987, 134);
            groupBox2.TabIndex = 28;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log";
            // 
            // textBoxLog
            // 
            textBoxLog.BackColor = SystemColors.WindowFrame;
            textBoxLog.BorderStyle = BorderStyle.FixedSingle;
            textBoxLog.ForeColor = SystemColors.ButtonHighlight;
            textBoxLog.Location = new Point(6, 22);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ReadOnly = true;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(975, 106);
            textBoxLog.TabIndex = 0;
            // 
            // buttonTw
            // 
            buttonTw.BackColor = SystemColors.GrayText;
            buttonTw.ForeColor = SystemColors.ButtonHighlight;
            buttonTw.Location = new Point(208, 3);
            buttonTw.Name = "buttonTw";
            buttonTw.Size = new Size(94, 39);
            buttonTw.TabIndex = 29;
            buttonTw.Text = "Import TW";
            buttonTw.UseVisualStyleBackColor = false;
            buttonTw.Click += buttonTw_Click;
            // 
            // FuelPlanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(buttonTw);
            Controls.Add(groupBox2);
            Controls.Add(buttonCombatFlite);
            Controls.Add(missionInfoGroupBox);
            Controls.Add(routeFlowPanel);
            Controls.Add(ImportDtcButton);
            DoubleBuffered = true;
            Name = "FuelPlanner";
            Size = new Size(1345, 694);
            VisibleChanged += FuelPlanner_VisibleChanged;
            missionInfoGroupBox.ResumeLayout(false);
            missionInfoGroupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button ImportDtcButton;
        private FlowLayoutPanel routeFlowPanel;
        private GroupBox missionInfoGroupBox;
        private Label label1;
        private Label labelTotalDistance;
        private TextBox textBoxBingo;
        private Label BingoLabel;
        private Label labelSuggestedFuel;
        private Label label3;
        private Label labelFuelBurn;
        private Label label5;
        private Label FuelLoadedLabelValue;
        private Label FuelLoadedLabel;
        private Label RecoveryFuelLabel;
        private Label label7;
        private Label LandingWeightValueLabel;
        private Label landingWeightLabel;
        private Label takeoffWeightLabel;
        private Label label4;
        private TextBox JokertextBox;
        private Label JokerLabel;
        private Label AAROnloadLabel;
        private Label label8;
        private Label label10;
        private Label labelSpeeds;
        private Button buttonCombatFlite;
        private GroupBox groupBox2;
        private TextBox textBoxLog;
        private ToolTip DistTt;
        private ToolTip TowTt;
        private ToolTip fuelNetTt;
        private ToolTip LawTt;
        private ToolTip LandingSpdTt;
        private ToolTip FuelBurnTt;
        private ToolTip RecFuelTt;
        private ToolTip ReqFuelTt;
        private ToolTip FuelLoadedTt;
        private ToolTip AarOnloadTt;
        private ToolTip JokerTt;
        private ToolTip BingoTt;
        private Label fuelLabelNet;
        private Label labelFuelNet;
        private CheckBox checkBoxCombat;
        private ToolTip toolTipCmbt;
        private Button buttonTw;
        private ToolTip dtcTt;
        private ToolTip CfTt;
        private ToolTip TwTt;
    }
}
