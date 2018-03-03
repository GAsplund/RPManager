namespace GAspsRPmngr
{
    partial class ErrorForm
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
            this.ExceptionThrownLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExceptionInfoTextBox = new System.Windows.Forms.TextBox();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExceptionThrownLabel
            // 
            this.ExceptionThrownLabel.AutoSize = true;
            this.ExceptionThrownLabel.Location = new System.Drawing.Point(10, 13);
            this.ExceptionThrownLabel.Name = "ExceptionThrownLabel";
            this.ExceptionThrownLabel.Size = new System.Drawing.Size(129, 13);
            this.ExceptionThrownLabel.TabIndex = 0;
            this.ExceptionThrownLabel.Text = "An exception was thrown:";
            this.ExceptionThrownLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "More info:";
            // 
            // ExceptionInfoTextBox
            // 
            this.ExceptionInfoTextBox.Location = new System.Drawing.Point(12, 73);
            this.ExceptionInfoTextBox.Multiline = true;
            this.ExceptionInfoTextBox.Name = "ExceptionInfoTextBox";
            this.ExceptionInfoTextBox.ReadOnly = true;
            this.ExceptionInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ExceptionInfoTextBox.Size = new System.Drawing.Size(372, 95);
            this.ExceptionInfoTextBox.TabIndex = 15;
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.AutoSize = true;
            this.ExceptionLabel.Location = new System.Drawing.Point(10, 29);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(88, 13);
            this.ExceptionLabel.TabIndex = 16;
            this.ExceptionLabel.Text = "(exception name)";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(290, 174);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(94, 30);
            this.QuitButton.TabIndex = 17;
            this.QuitButton.Text = "Quit Application";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(209, 174);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(75, 30);
            this.ContinueButton.TabIndex = 18;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "GAsplund\'s Resourcepack Manager";
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 216);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.ExceptionInfoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExceptionThrownLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(412, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(412, 255);
            this.Name = "ErrorForm";
            this.ShowIcon = false;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ExceptionThrownLabel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox ExceptionInfoTextBox;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Label label1;
    }
}