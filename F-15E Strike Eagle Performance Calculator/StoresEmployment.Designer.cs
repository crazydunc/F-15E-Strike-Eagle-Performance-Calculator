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
            buttonCancel.Location = new Point(80, 86);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(252, 86);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(75, 23);
            buttonConfirm.TabIndex = 1;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // checkBoxSta2
            // 
            checkBoxSta2.AutoSize = true;
            checkBoxSta2.Location = new Point(353, 61);
            checkBoxSta2.Name = "checkBoxSta2";
            checkBoxSta2.Size = new Size(51, 19);
            checkBoxSta2.TabIndex = 2;
            checkBoxSta2.Text = "STA2";
            checkBoxSta2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 9);
            label1.Name = "label1";
            label1.Size = new Size(244, 45);
            label1.TabIndex = 3;
            label1.Text = "Stores employed on ths leg. \r\nPlease check the stations that are applicable. \r\nThis only applies to Air to Ground stores";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBoxLcft
            // 
            checkBoxLcft.AutoSize = true;
            checkBoxLcft.Location = new Point(267, 61);
            checkBoxLcft.Name = "checkBoxLcft";
            checkBoxLcft.Size = new Size(52, 19);
            checkBoxLcft.TabIndex = 4;
            checkBoxLcft.Text = "LCFT";
            checkBoxLcft.UseVisualStyleBackColor = true;
            // 
            // checkBoxSta5
            // 
            checkBoxSta5.AutoSize = true;
            checkBoxSta5.Location = new Point(182, 61);
            checkBoxSta5.Name = "checkBoxSta5";
            checkBoxSta5.Size = new Size(51, 19);
            checkBoxSta5.TabIndex = 5;
            checkBoxSta5.Text = "STA5";
            checkBoxSta5.UseVisualStyleBackColor = true;
            // 
            // checkBoxRcft
            // 
            checkBoxRcft.AutoSize = true;
            checkBoxRcft.Location = new Point(95, 61);
            checkBoxRcft.Name = "checkBoxRcft";
            checkBoxRcft.Size = new Size(53, 19);
            checkBoxRcft.TabIndex = 6;
            checkBoxRcft.Text = "RCFT";
            checkBoxRcft.UseVisualStyleBackColor = true;
            // 
            // checkBoxSta8
            // 
            checkBoxSta8.AutoSize = true;
            checkBoxSta8.Location = new Point(10, 61);
            checkBoxSta8.Name = "checkBoxSta8";
            checkBoxSta8.Size = new Size(51, 19);
            checkBoxSta8.TabIndex = 7;
            checkBoxSta8.Text = "STA8";
            checkBoxSta8.UseVisualStyleBackColor = true;
            // 
            // StoresEmployment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(413, 121);
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