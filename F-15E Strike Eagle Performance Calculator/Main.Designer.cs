namespace F_15E_Strike_Eagle_Performance_Calculator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            NavPanel = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            labelCopy = new Label();
            buttonFuel = new Button();
            buttonHome = new Button();
            UiPanel = new Panel();
            loadout1 = new Loadout();
            fuelPlanner1 = new FuelPlanner();
            NavPanel.SuspendLayout();
            panel1.SuspendLayout();
            UiPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.Controls.Add(panel1);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Margin = new Padding(3, 4, 3, 4);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(1539, 72);
            NavPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelCopy);
            panel1.Controls.Add(buttonFuel);
            panel1.Controls.Add(buttonHome);
            panel1.Location = new Point(3, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1536, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("AmarilloUSAF", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(463, 8);
            label1.Name = "label1";
            label1.Size = new Size(686, 35);
            label1.TabIndex = 20;
            label1.Text = "Strike Eagle Performance Calculator";
            // 
            // labelCopy
            // 
            labelCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCopy.AutoSize = true;
            labelCopy.ForeColor = SystemColors.Control;
            labelCopy.Location = new Point(1280, 8);
            labelCopy.Name = "labelCopy";
            labelCopy.Size = new Size(244, 20);
            labelCopy.TabIndex = 19;
            labelCopy.Text = "© Duncan MacKellar 2024 - v1.0.0.5";
            // 
            // buttonFuel
            // 
            buttonFuel.BackColor = Color.Transparent;
            buttonFuel.Dock = DockStyle.Left;
            buttonFuel.FlatAppearance.BorderColor = Color.Gray;
            buttonFuel.FlatAppearance.BorderSize = 0;
            buttonFuel.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 88, 120, 167);
            buttonFuel.FlatStyle = FlatStyle.Flat;
            buttonFuel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFuel.ForeColor = Color.White;
            buttonFuel.Image = Properties.Resources.icons8_jet_engine_48;
            buttonFuel.ImageAlign = ContentAlignment.MiddleLeft;
            buttonFuel.Location = new Point(200, 0);
            buttonFuel.Margin = new Padding(3, 13, 3, 13);
            buttonFuel.Name = "buttonFuel";
            buttonFuel.Padding = new Padding(10, 0, 0, 0);
            buttonFuel.Size = new Size(200, 60);
            buttonFuel.TabIndex = 4;
            buttonFuel.Text = "             Fuel";
            buttonFuel.TextAlign = ContentAlignment.MiddleLeft;
            buttonFuel.UseVisualStyleBackColor = false;
            buttonFuel.Click += buttonFuel_Click;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.Transparent;
            buttonHome.Dock = DockStyle.Left;
            buttonHome.FlatAppearance.BorderColor = Color.Gray;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 88, 120, 167);
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonHome.ForeColor = Color.White;
            buttonHome.Image = Properties.Resources.icons8_fighter_jet_48;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(0, 0);
            buttonHome.Margin = new Padding(3, 4, 3, 4);
            buttonHome.Name = "buttonHome";
            buttonHome.Padding = new Padding(10, 0, 0, 0);
            buttonHome.Size = new Size(200, 60);
            buttonHome.TabIndex = 3;
            buttonHome.Text = "             Loadout";
            buttonHome.TextAlign = ContentAlignment.MiddleLeft;
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click;
            // 
            // UiPanel
            // 
            UiPanel.Controls.Add(loadout1);
            UiPanel.Controls.Add(fuelPlanner1);
            UiPanel.Dock = DockStyle.Fill;
            UiPanel.Location = new Point(0, 72);
            UiPanel.Margin = new Padding(3, 4, 3, 4);
            UiPanel.Name = "UiPanel";
            UiPanel.Size = new Size(1539, 932);
            UiPanel.TabIndex = 1;
            // 
            // loadout1
            // 
            loadout1.BackColor = SystemColors.WindowFrame;
            loadout1.Location = new Point(0, 0);
            loadout1.Margin = new Padding(3, 5, 3, 5);
            loadout1.Name = "loadout1";
            loadout1.Size = new Size(1537, 925);
            loadout1.TabIndex = 0;
            // 
            // fuelPlanner1
            // 
            fuelPlanner1.BackColor = SystemColors.WindowFrame;
            fuelPlanner1.Location = new Point(0, 0);
            fuelPlanner1.Margin = new Padding(3, 5, 3, 5);
            fuelPlanner1.Name = "fuelPlanner1";
            fuelPlanner1.Size = new Size(1537, 925);
            fuelPlanner1.TabIndex = 1;
            fuelPlanner1.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1539, 1004);
            Controls.Add(UiPanel);
            Controls.Add(NavPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Main";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Strike Eagle Performance Calculator";
            Load += Main_Load;
            NavPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            UiPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel NavPanel;
        private Panel UiPanel;
        private Panel panel1;
        private Button buttonFuel;
        private Button buttonHome;
        private Label labelCopy;
        private FuelPlanner fuelPlanner1;
        private Label label1;
        private Loadout loadout1;
    }
}