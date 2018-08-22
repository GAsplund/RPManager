namespace GAsplund_s_WynnPack_Manager
{
    partial class ManagerForm
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.fetchPacksButton = new System.Windows.Forms.Button();
            this.packSelectionListBox = new System.Windows.Forms.ListBox();
            this.selectPackLabel = new System.Windows.Forms.Label();
            this.installOrUninstallPackButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.uninstallPackButton = new System.Windows.Forms.Button();
            this.forceUpdatePackButton = new System.Windows.Forms.Button();
            this.packStatusLabel = new System.Windows.Forms.Label();
            this.currentPackLabel = new System.Windows.Forms.Label();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.packDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.packCompatibilityLabel = new System.Windows.Forms.Label();
            this.packVersionLabel = new System.Windows.Forms.Label();
            this.PackEditionLabel = new System.Windows.Forms.Label();
            this.PackEditionComboBox = new System.Windows.Forms.ComboBox();
            this.creatorLabel = new System.Windows.Forms.Label();
            this.ResolutionsLabel = new System.Windows.Forms.Label();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.ImageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.packPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PackSettingsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.ApplySettingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.packPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fetchPacksButton
            // 
            this.fetchPacksButton.AutoSize = true;
            this.fetchPacksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fetchPacksButton.Location = new System.Drawing.Point(416, 37);
            this.fetchPacksButton.Name = "fetchPacksButton";
            this.fetchPacksButton.Size = new System.Drawing.Size(165, 39);
            this.fetchPacksButton.TabIndex = 1;
            this.fetchPacksButton.Text = "Update Options/Skin (DEV)";
            this.fetchPacksButton.UseVisualStyleBackColor = true;
            this.fetchPacksButton.Visible = false;
            this.fetchPacksButton.Click += new System.EventHandler(this.fetchPacksButton_Click);
            // 
            // packSelectionListBox
            // 
            this.packSelectionListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.packSelectionListBox.FormattingEnabled = true;
            this.packSelectionListBox.ItemHeight = 15;
            this.packSelectionListBox.Location = new System.Drawing.Point(13, 24);
            this.packSelectionListBox.MinimumSize = new System.Drawing.Size(120, 10);
            this.packSelectionListBox.Name = "packSelectionListBox";
            this.packSelectionListBox.Size = new System.Drawing.Size(165, 139);
            this.packSelectionListBox.TabIndex = 4;
            this.packSelectionListBox.SelectedIndexChanged += new System.EventHandler(this.packSelectionListBox_SelectedIndexChanged);
            // 
            // selectPackLabel
            // 
            this.selectPackLabel.AutoSize = true;
            this.selectPackLabel.BackColor = System.Drawing.Color.Transparent;
            this.selectPackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectPackLabel.Location = new System.Drawing.Point(10, 6);
            this.selectPackLabel.Name = "selectPackLabel";
            this.selectPackLabel.Size = new System.Drawing.Size(101, 17);
            this.selectPackLabel.TabIndex = 5;
            this.selectPackLabel.Text = "Pack Selection";
            // 
            // installOrUninstallPackButton
            // 
            this.installOrUninstallPackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.installOrUninstallPackButton.Enabled = false;
            this.installOrUninstallPackButton.Location = new System.Drawing.Point(460, 398);
            this.installOrUninstallPackButton.Name = "installOrUninstallPackButton";
            this.installOrUninstallPackButton.Size = new System.Drawing.Size(124, 39);
            this.installOrUninstallPackButton.TabIndex = 6;
            this.installOrUninstallPackButton.Text = "Install Pack";
            this.installOrUninstallPackButton.UseVisualStyleBackColor = true;
            this.installOrUninstallPackButton.Click += new System.EventHandler(this.installOrUninstallPackButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(598, 398);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(74, 39);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // uninstallPackButton
            // 
            this.uninstallPackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uninstallPackButton.Enabled = false;
            this.uninstallPackButton.Location = new System.Drawing.Point(196, 398);
            this.uninstallPackButton.Name = "uninstallPackButton";
            this.uninstallPackButton.Size = new System.Drawing.Size(126, 39);
            this.uninstallPackButton.TabIndex = 8;
            this.uninstallPackButton.Text = "Uninstall Pack";
            this.uninstallPackButton.UseVisualStyleBackColor = true;
            this.uninstallPackButton.Click += new System.EventHandler(this.uninstallPackButton_Click);
            // 
            // forceUpdatePackButton
            // 
            this.forceUpdatePackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.forceUpdatePackButton.Enabled = false;
            this.forceUpdatePackButton.Location = new System.Drawing.Point(329, 398);
            this.forceUpdatePackButton.Name = "forceUpdatePackButton";
            this.forceUpdatePackButton.Size = new System.Drawing.Size(124, 39);
            this.forceUpdatePackButton.TabIndex = 9;
            this.forceUpdatePackButton.Text = "Force Update Pack";
            this.forceUpdatePackButton.UseVisualStyleBackColor = true;
            this.forceUpdatePackButton.Click += new System.EventHandler(this.forceUpdatePackButton_Click);
            // 
            // packStatusLabel
            // 
            this.packStatusLabel.AutoSize = true;
            this.packStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.packStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.packStatusLabel.Location = new System.Drawing.Point(192, 92);
            this.packStatusLabel.Name = "packStatusLabel";
            this.packStatusLabel.Size = new System.Drawing.Size(169, 17);
            this.packStatusLabel.TabIndex = 10;
            this.packStatusLabel.Text = "Pack Status: Not Installed";
            // 
            // currentPackLabel
            // 
            this.currentPackLabel.AutoSize = true;
            this.currentPackLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentPackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.currentPackLabel.Location = new System.Drawing.Point(189, 3);
            this.currentPackLabel.Name = "currentPackLabel";
            this.currentPackLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentPackLabel.Size = new System.Drawing.Size(168, 25);
            this.currentPackLabel.TabIndex = 11;
            this.currentPackLabel.Text = "No Pack Selected";
            this.currentPackLabel.Click += new System.EventHandler(this.currentPackLabel_Click);
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Location = new System.Drawing.Point(393, 6);
            this.statusProgressBar.MarqueeAnimationSpeed = 500;
            this.statusProgressBar.MaximumSize = new System.Drawing.Size(99999, 23);
            this.statusProgressBar.MinimumSize = new System.Drawing.Size(203, 12);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusProgressBar.Size = new System.Drawing.Size(279, 23);
            this.statusProgressBar.TabIndex = 13;
            // 
            // packDescriptionTextBox
            // 
            this.packDescriptionTextBox.Location = new System.Drawing.Point(196, 126);
            this.packDescriptionTextBox.Multiline = true;
            this.packDescriptionTextBox.Name = "packDescriptionTextBox";
            this.packDescriptionTextBox.ReadOnly = true;
            this.packDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.packDescriptionTextBox.Size = new System.Drawing.Size(476, 79);
            this.packDescriptionTextBox.TabIndex = 14;
            this.packDescriptionTextBox.Text = "Pack Description Here";
            // 
            // packCompatibilityLabel
            // 
            this.packCompatibilityLabel.AutoSize = true;
            this.packCompatibilityLabel.BackColor = System.Drawing.Color.Transparent;
            this.packCompatibilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.packCompatibilityLabel.Location = new System.Drawing.Point(192, 59);
            this.packCompatibilityLabel.Name = "packCompatibilityLabel";
            this.packCompatibilityLabel.Size = new System.Drawing.Size(115, 17);
            this.packCompatibilityLabel.TabIndex = 15;
            this.packCompatibilityLabel.Text = "MC Versions: n/a";
            // 
            // packVersionLabel
            // 
            this.packVersionLabel.AutoSize = true;
            this.packVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.packVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.packVersionLabel.Location = new System.Drawing.Point(192, 42);
            this.packVersionLabel.Name = "packVersionLabel";
            this.packVersionLabel.Size = new System.Drawing.Size(127, 17);
            this.packVersionLabel.TabIndex = 16;
            this.packVersionLabel.Text = "Latest Version: n/a";
            // 
            // PackEditionLabel
            // 
            this.PackEditionLabel.AutoSize = true;
            this.PackEditionLabel.BackColor = System.Drawing.Color.Transparent;
            this.PackEditionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PackEditionLabel.Location = new System.Drawing.Point(467, 85);
            this.PackEditionLabel.Name = "PackEditionLabel";
            this.PackEditionLabel.Size = new System.Drawing.Size(67, 13);
            this.PackEditionLabel.TabIndex = 19;
            this.PackEditionLabel.Text = "Pack Edition";
            // 
            // PackEditionComboBox
            // 
            this.PackEditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PackEditionComboBox.Enabled = false;
            this.PackEditionComboBox.FormattingEnabled = true;
            this.PackEditionComboBox.Location = new System.Drawing.Point(470, 99);
            this.PackEditionComboBox.Name = "PackEditionComboBox";
            this.PackEditionComboBox.Size = new System.Drawing.Size(202, 21);
            this.PackEditionComboBox.TabIndex = 20;
            this.PackEditionComboBox.SelectedIndexChanged += new System.EventHandler(this.PackEditionComboBox_SelectedIndexChanged);
            // 
            // creatorLabel
            // 
            this.creatorLabel.AutoSize = true;
            this.creatorLabel.BackColor = System.Drawing.Color.Transparent;
            this.creatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.creatorLabel.Location = new System.Drawing.Point(192, 25);
            this.creatorLabel.Name = "creatorLabel";
            this.creatorLabel.Size = new System.Drawing.Size(101, 17);
            this.creatorLabel.TabIndex = 21;
            this.creatorLabel.Text = "Created by n/a";
            // 
            // ResolutionsLabel
            // 
            this.ResolutionsLabel.AutoSize = true;
            this.ResolutionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResolutionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ResolutionsLabel.Location = new System.Drawing.Point(192, 76);
            this.ResolutionsLabel.Name = "ResolutionsLabel";
            this.ResolutionsLabel.Size = new System.Drawing.Size(120, 17);
            this.ResolutionsLabel.TabIndex = 22;
            this.ResolutionsLabel.Text = "Resolution(s): n/a";
            // 
            // OptionsButton
            // 
            this.OptionsButton.AutoSize = true;
            this.OptionsButton.Location = new System.Drawing.Point(13, 398);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(165, 39);
            this.OptionsButton.TabIndex = 23;
            this.OptionsButton.Text = "Options...";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // packPreviewPictureBox
            // 
            this.packPreviewPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.packPreviewPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.packPreviewPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.packPreviewPictureBox.Image = global::GAspsRPmngr.Properties.Resources.blank;
            this.packPreviewPictureBox.ImageLocation = "";
            this.packPreviewPictureBox.InitialImage = null;
            this.packPreviewPictureBox.Location = new System.Drawing.Point(197, 214);
            this.packPreviewPictureBox.MinimumSize = new System.Drawing.Size(475, 175);
            this.packPreviewPictureBox.Name = "packPreviewPictureBox";
            this.packPreviewPictureBox.Size = new System.Drawing.Size(475, 175);
            this.packPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.packPreviewPictureBox.TabIndex = 12;
            this.packPreviewPictureBox.TabStop = false;
            this.ImageToolTip.SetToolTip(this.packPreviewPictureBox, "Click to open full image in your browser.");
            this.packPreviewPictureBox.Click += new System.EventHandler(this.packPreviewPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(596, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "ver1.0-devbuild";
            // 
            // PackSettingsCheckedListBox
            // 
            this.PackSettingsCheckedListBox.CheckOnClick = true;
            this.PackSettingsCheckedListBox.Enabled = false;
            this.PackSettingsCheckedListBox.FormattingEnabled = true;
            this.PackSettingsCheckedListBox.Location = new System.Drawing.Point(13, 201);
            this.PackSettingsCheckedListBox.Name = "PackSettingsCheckedListBox";
            this.PackSettingsCheckedListBox.Size = new System.Drawing.Size(165, 139);
            this.PackSettingsCheckedListBox.TabIndex = 25;
            this.PackSettingsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.PackSettingsCheckedListBox_SelectedIndexChanged);
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.SettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SettingsLabel.Location = new System.Drawing.Point(10, 182);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(141, 17);
            this.SettingsLabel.TabIndex = 26;
            this.SettingsLabel.Text = "Pack/Edition Settings";
            // 
            // ApplySettingsButton
            // 
            this.ApplySettingsButton.Enabled = false;
            this.ApplySettingsButton.Location = new System.Drawing.Point(13, 350);
            this.ApplySettingsButton.Name = "ApplySettingsButton";
            this.ApplySettingsButton.Size = new System.Drawing.Size(165, 39);
            this.ApplySettingsButton.TabIndex = 27;
            this.ApplySettingsButton.Text = "Apply Pack/Edition Settings";
            this.ApplySettingsButton.UseVisualStyleBackColor = true;
            this.ApplySettingsButton.Click += new System.EventHandler(this.ApplySettingsButton_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(684, 446);
            this.Controls.Add(this.ApplySettingsButton);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.PackSettingsCheckedListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.ResolutionsLabel);
            this.Controls.Add(this.creatorLabel);
            this.Controls.Add(this.PackEditionComboBox);
            this.Controls.Add(this.PackEditionLabel);
            this.Controls.Add(this.packVersionLabel);
            this.Controls.Add(this.packCompatibilityLabel);
            this.Controls.Add(this.packDescriptionTextBox);
            this.Controls.Add(this.statusProgressBar);
            this.Controls.Add(this.packPreviewPictureBox);
            this.Controls.Add(this.currentPackLabel);
            this.Controls.Add(this.packStatusLabel);
            this.Controls.Add(this.forceUpdatePackButton);
            this.Controls.Add(this.uninstallPackButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.installOrUninstallPackButton);
            this.Controls.Add(this.selectPackLabel);
            this.Controls.Add(this.packSelectionListBox);
            this.Controls.Add(this.fetchPacksButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 485);
            this.Name = "ManagerForm";
            this.Text = "GAsplund\'s Resourcepack Manager";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        public System.Windows.Forms.PictureBox packPreviewPictureBox;
        public System.Windows.Forms.ProgressBar statusProgressBar;
        public System.Windows.Forms.TextBox packDescriptionTextBox;
        public System.Windows.Forms.Button fetchPacksButton;
        public System.Windows.Forms.Button installOrUninstallPackButton;
        public System.Windows.Forms.Button uninstallPackButton;
        public System.Windows.Forms.Button forceUpdatePackButton;
        public System.Windows.Forms.Label packStatusLabel;
        public System.Windows.Forms.Label currentPackLabel;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.ToolTip ImageToolTip;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label selectPackLabel;
        public System.Windows.Forms.Label packCompatibilityLabel;
        public System.Windows.Forms.Label packVersionLabel;
        public System.Windows.Forms.Label PackEditionLabel;
        public System.Windows.Forms.Label creatorLabel;
        public System.Windows.Forms.Label ResolutionsLabel;
        public System.Windows.Forms.Label SettingsLabel;
        public System.Windows.Forms.ListBox packSelectionListBox;
        public System.Windows.Forms.CheckedListBox PackSettingsCheckedListBox;
        public System.Windows.Forms.ComboBox PackEditionComboBox;
        public System.Windows.Forms.Button ApplySettingsButton;
    }
}

