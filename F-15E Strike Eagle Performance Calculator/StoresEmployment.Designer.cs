namespace F_15E_Strike_Eagle_Performance_Calculator
{
    partial class StoresEmployment
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCancel = new Button();
            buttonConfirm = new Button();
            checkBoxSta2 = new CheckBox();
            label1 = new Label();
            checkBoxLcft = new CheckBox();
            checkBoxSta5 = new CheckBox();
            checkBoxRcft = new CheckBox();
            checkBoxSta8 = new CheckBox();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(91, 115);
            buttonCancel.Margin = new Padding(3, 4, 3, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 31);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(288, 115);
            buttonConfirm.Margin = new Padding(3, 4, 3, 4);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(86, 31);
            buttonConfirm.TabIndex = 1;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // checkBoxSta2
            // 
            checkBoxSta2.AutoSize = true;
            checkBoxSta2.Location = new Point(403, 81);
            checkBoxSta2.Margin = new Padding(3, 4, 3, 4);
            checkBoxSta2.Name = "checkBoxSta2";
            checkBoxSta2.Size = new Size(64, 24);
            checkBoxSta2.TabIndex = 2;
            checkBoxSta2.Text = "STA2";
            checkBoxSta2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 12);
            label1.Name = "label1";
            label1.Size = new Size(308, 60);
            label1.TabIndex = 3;
            label1.Text = "Stores employed on ths leg. \r\nPlease check the stations that are applicable. \r\nThis only applies to Air to Ground stores";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBoxLcft
            // 
            checkBoxLcft.AutoSize = true;
            checkBoxLcft.Location = new Point(305, 81);
            checkBoxLcft.Margin = new Padding(3, 4, 3, 4);
            checkBoxLcft.Name = "checkBoxLcft";
            checkBoxLcft.Size = new Size(61, 24);
            checkBoxLcft.TabIndex = 4;
            checkBoxLcft.Text = "LCFT";
            checkBoxLcft.UseVisualStyleBackColor = true;
            // 
            // checkBoxSta5
            // 
            checkBoxSta5.AutoSize = true;
            checkBoxSta5.Location = new Point(208, 81);
            checkBoxSta5.Margin = new Padding(3, 4, 3, 4);
            checkBoxSta5.Name = "checkBoxSta5";
            checkBoxSta5.Size = new Size(64, 24);
            checkBoxSta5.TabIndex = 5;
            checkBoxSta5.Text = "STA5";
            checkBoxSta5.UseVisualStyleBackColor = true;
            // 
            // checkBoxRcft
            // 
            checkBoxRcft.AutoSize = true;
            checkBoxRcft.Location = new Point(109, 81);
            checkBoxRcft.Margin = new Padding(3, 4, 3, 4);
            checkBoxRcft.Name = "checkBoxRcft";
            checkBoxRcft.Size = new Size(64, 24);
            checkBoxRcft.TabIndex = 6;
            checkBoxRcft.Text = "RCFT";
            checkBoxRcft.UseVisualStyleBackColor = true;
            // 
            // checkBoxSta8
            // 
            checkBoxSta8.AutoSize = true;
            checkBoxSta8.Location = new Point(11, 81);
            checkBoxSta8.Margin = new Padding(3, 4, 3, 4);
            checkBoxSta8.Name = "checkBoxSta8";
            checkBoxSta8.Size = new Size(64, 24);
            checkBoxSta8.TabIndex = 7;
            checkBoxSta8.Text = "STA8";
            checkBoxSta8.UseVisualStyleBackColor = true;
            // 
            // StoresEmployment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(472, 161);
            ControlBox = false;
            Controls.Add(checkBoxSta8);
            Controls.Add(checkBoxRcft);
            Controls.Add(checkBoxSta5);
            Controls.Add(checkBoxLcft);
            Controls.Add(label1);
            Controls.Add(checkBoxSta2);
            Controls.Add(buttonConfirm);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StoresEmployment";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Stores Employment";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonConfirm;
        private CheckBox checkBoxSta2;
        private Label label1;
        private CheckBox checkBoxLcft;
        private CheckBox checkBoxSta5;
        private CheckBox checkBoxRcft;
        private CheckBox checkBoxSta8;
    }
}