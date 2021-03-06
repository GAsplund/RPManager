﻿namespace GAsplund_s_WynnPack_Manager
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
            this.CleanCacheButton = new System.Windows.Forms.Button();
            this.CacheSizeLabel = new System.Windows.Forms.Label();
            this.EnableDebugCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            this.ApplyButton.Location = new System.Drawing.Point(207, 250);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 21;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(126, 250);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 22;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(45, 250);
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
            this.label1.Location = new System.Drawing.Point(12, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Copyright © 2018 GAsplund. All Rights Reserved.";
            // 
            // ThemeChooserComboBox
            // 
            this.ThemeChooserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ThemeChooserComboBox.FormattingEnabled = true;
            this.ThemeChooserComboBox.Items.AddRange(new object[] {
            "None (White Background)",
            "WynnPack Background",
            "Dirt Background"});
            this.ThemeChooserComboBox.Location = new System.Drawing.Point(10, 149);
            this.ThemeChooserComboBox.Name = "ThemeChooserComboBox";
            this.ThemeChooserComboBox.Size = new System.Drawing.Size(149, 21);
            this.ThemeChooserComboBox.TabIndex = 25;
            this.ThemeChooserComboBox.SelectedIndexChanged += new System.EventHandler(this.ThemeChooserComboBox_SelectedIndexChanged);
            // 
            // ThemeLabel
            // 
            this.ThemeLabel.AutoSize = true;
            this.ThemeLabel.Location = new System.Drawing.Point(9, 133);
            this.ThemeLabel.Name = "ThemeLabel";
            this.ThemeLabel.Size = new System.Drawing.Size(28, 13);
            this.ThemeLabel.TabIndex = 26;
            this.ThemeLabel.Text = "Skin";
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
            // CleanCacheButton
            // 
            this.CleanCacheButton.Location = new System.Drawing.Point(10, 178);
            this.CleanCacheButton.Name = "CleanCacheButton";
            this.CleanCacheButton.Size = new System.Drawing.Size(88, 33);
            this.CleanCacheButton.TabIndex = 31;
            this.CleanCacheButton.Text = "Delete Cache";
            this.CleanCacheButton.UseVisualStyleBackColor = true;
            this.CleanCacheButton.Click += new System.EventHandler(this.CleanCacheButton_Click);
            // 
            // CacheSizeLabel
            // 
            this.CacheSizeLabel.AutoSize = true;
            this.CacheSizeLabel.Location = new System.Drawing.Point(9, 211);
            this.CacheSizeLabel.Name = "CacheSizeLabel";
            this.CacheSizeLabel.Size = new System.Drawing.Size(98, 13);
            this.CacheSizeLabel.TabIndex = 32;
            this.CacheSizeLabel.Text = "Size: Determining...";
            // 
            // EnableDebugCheckBox
            // 
            this.EnableDebugCheckBox.AutoSize = true;
            this.EnableDebugCheckBox.Location = new System.Drawing.Point(192, 9);
            this.EnableDebugCheckBox.Name = "EnableDebugCheckBox";
            this.EnableDebugCheckBox.Size = new System.Drawing.Size(94, 17);
            this.EnableDebugCheckBox.TabIndex = 33;
            this.EnableDebugCheckBox.Text = "Enable Debug";
            this.EnableDebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 284);
            this.ControlBox = false;
            this.Controls.Add(this.EnableDebugCheckBox);
            this.Controls.Add(this.CacheSizeLabel);
            this.Controls.Add(this.CleanCacheButton);
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
            this.Controls.Add(this.customSourceTextBox);
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button CleanCacheButton;
        private System.Windows.Forms.Label CacheSizeLabel;
        private System.Windows.Forms.CheckBox EnableDebugCheckBox;
    }
}