namespace Auth_Login
{
    partial class NoAccess
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
            this.noAccessTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // noAccessTextBox
            // 
            this.noAccessTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.noAccessTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noAccessTextBox.Enabled = false;
            this.noAccessTextBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noAccessTextBox.Location = new System.Drawing.Point(12, 21);
            this.noAccessTextBox.Multiline = true;
            this.noAccessTextBox.Name = "noAccessTextBox";
            this.noAccessTextBox.Size = new System.Drawing.Size(265, 228);
            this.noAccessTextBox.TabIndex = 2;
            this.noAccessTextBox.Text = "Welcome {username}!\r\nYou currently do not have access to any resources.\r\n\r\n\r\nCont" +
    "act your administrator to get access to new resources.\r\n";
            this.noAccessTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NoAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 271);
            this.Controls.Add(this.noAccessTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NoAccess";
            this.Text = "No Access";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NoAccess_FormClosed);
            this.Load += new System.EventHandler(this.NoAccess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox noAccessTextBox;
    }
}