namespace GAsplund_s_WynnPack_Manager
{
    partial class OptionsForm
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
            this.useCustomSourceCheckBox = new System.Windows.Forms.CheckBox();
            this.customSourceTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ThemeChooserComboBox = new System.Windows.Forms.ComboBox();
            this.ThemeLabel = new System.Windows.Forms.Label();
            this.OfficialVanillaRadioButton = new System.Windows.Forms.RadioButton();
            this.OfficialWynnRadioButton = new System.Windows.Forms.RadioButton();
            this.CustomSourceRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // useCustomSourceCheckBox
            // 
            this.useCustomSourceCheckBox.AutoSize = true;
            this.useCustomSourceCheckBox.Location = new System.Drawing.Point(162, 174);
            this.useCustomSourceCheckBox.Name = "useCustomSourceCheckBox";
            this.useCustomSourceCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useCustomSourceCheckBox.Size = new System.Drawing.Size(120, 17);
            this.useCustomSourceCheckBox.TabIndex = 20;
            this.useCustomSourceCheckBox.Text = "Use Custom Source";
            this.useCustomSourceCheckBox.UseVisualStyleBackColor = true;
            this.useCustomSourceCheckBox.CheckedChanged += new System.EventHandler(this.useCustomSourceCheckBox_CheckedChanged);
            // 
            // customSourceTextBox
            // 
            this.customSourceTextBox.Enabled = false;
            this.customSourceTextBox.Location = new System.Drawing.Point(10, 97);
            this.customSourceTextBox.Name = "customSourceTextBox";
            this.customSourceTextBox.Size = new System.Drawing.Size(270, 20);
            this.customSourceTextBox.TabIndex = 19;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(207, 226);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 21;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(126, 226);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 22;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(45, 226);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 23;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(12, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Copyright © 2018 GAsplund. All Rights Reserved.";
            // 
            // ThemeChooserComboBox
            // 
            this.ThemeChooserComboBox.Enabled = false;
            this.ThemeChooserComboBox.FormattingEnabled = true;
            this.ThemeChooserComboBox.Items.AddRange(new object[] {
            "None",
            "WynnPack Background"});
            this.ThemeChooserComboBox.Location = new System.Drawing.Point(10, 149);
            this.ThemeChooserComboBox.Name = "ThemeChooserComboBox";
            this.ThemeChooserComboBox.Size = new System.Drawing.Size(133, 21);
            this.ThemeChooserComboBox.TabIndex = 25;
            // 
            // ThemeLabel
            // 
            this.ThemeLabel.AutoSize = true;
            this.ThemeLabel.Location = new System.Drawing.Point(9, 133);
            this.ThemeLabel.Name = "ThemeLabel";
            this.ThemeLabel.Size = new System.Drawing.Size(126, 13);
            this.ThemeLabel.TabIndex = 26;
            this.ThemeLabel.Text = "Theme (COMING SOON)";
            // 
            // OfficialVanillaRadioButton
            // 
            this.OfficialVanillaRadioButton.AutoSize = true;
            this.OfficialVanillaRadioButton.Location = new System.Drawing.Point(12, 28);
            this.OfficialVanillaRadioButton.Name = "OfficialVanillaRadioButton";
            this.OfficialVanillaRadioButton.Size = new System.Drawing.Size(131, 17);
            this.OfficialVanillaRadioButton.TabIndex = 27;
            this.OfficialVanillaRadioButton.TabStop = true;
            this.OfficialVanillaRadioButton.Text = "Official Source: Vanilla";
            this.OfficialVanillaRadioButton.UseVisualStyleBackColor = true;
            this.OfficialVanillaRadioButton.CheckedChanged += new System.EventHandler(this.OfficialVanillaRadioButton_CheckedChanged);
            // 
            // OfficialWynnRadioButton
            // 
            this.OfficialWynnRadioButton.AutoSize = true;
            this.OfficialWynnRadioButton.Location = new System.Drawing.Point(12, 51);
            this.OfficialWynnRadioButton.Name = "OfficialWynnRadioButton";
            this.OfficialWynnRadioButton.Size = new System.Drawing.Size(128, 17);
            this.OfficialWynnRadioButton.TabIndex = 28;
            this.OfficialWynnRadioButton.TabStop = true;
            this.OfficialWynnRadioButton.Text = "Official Source: Wynn";
            this.OfficialWynnRadioButton.UseVisualStyleBackColor = true;
            this.OfficialWynnRadioButton.CheckedChanged += new System.EventHandler(this.OfficialWynnRadioButton_CheckedChanged);
            // 
            // CustomSourceRadioButton
            // 
            this.CustomSourceRadioButton.AutoSize = true;
            this.CustomSourceRadioButton.Location = new System.Drawing.Point(12, 74);
            this.CustomSourceRadioButton.Name = "CustomSourceRadioButton";
            this.CustomSourceRadioButton.Size = new System.Drawing.Size(100, 17);
            this.CustomSourceRadioButton.TabIndex = 29;
            this.CustomSourceRadioButton.TabStop = true;
            this.CustomSourceRadioButton.Text = "Custom Source:";
            this.CustomSourceRadioButton.UseVisualStyleBackColor = true;
            this.CustomSourceRadioButton.CheckedChanged += new System.EventHandler(this.CustomSourceRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Source Selection:";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomSourceRadioButton);
            this.Controls.Add(this.OfficialWynnRadioButton);
            this.Controls.Add(this.OfficialVanillaRadioButton);
            this.Controls.Add(this.ThemeLabel);
            this.Controls.Add(this.ThemeChooserComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.useCustomSourceCheckBox);
            this.Controls.Add(this.customSourceTextBox);
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox useCustomSourceCheckBox;
        public System.Windows.Forms.TextBox customSourceTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ThemeChooserComboBox;
        private System.Windows.Forms.Label ThemeLabel;
        private System.Windows.Forms.RadioButton OfficialVanillaRadioButton;
        private System.Windows.Forms.RadioButton OfficialWynnRadioButton;
        private System.Windows.Forms.RadioButton CustomSourceRadioButton;
        private System.Windows.Forms.Label label2;
    }
}