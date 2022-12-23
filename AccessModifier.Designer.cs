namespace Auth_Login
{
    partial class AccessModifier
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
            this.accessGridView = new System.Windows.Forms.DataGridView();
            this.AccessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasAccessColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.topLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.accessGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // accessGridView
            // 
            this.accessGridView.AllowUserToAddRows = false;
            this.accessGridView.AllowUserToDeleteRows = false;
            this.accessGridView.AllowUserToResizeColumns = false;
            this.accessGridView.AllowUserToResizeRows = false;
            this.accessGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accessGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccessColumn,
            this.HasAccessColumn});
            this.accessGridView.Location = new System.Drawing.Point(55, 57);
            this.accessGridView.Name = "accessGridView";
            this.accessGridView.RowHeadersVisible = false;
            this.accessGridView.RowTemplate.Height = 25;
            this.accessGridView.Size = new System.Drawing.Size(303, 147);
            this.accessGridView.TabIndex = 0;
            this.accessGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accessGridView_CellContentClick);
            // 
            // AccessColumn
            // 
            this.AccessColumn.HeaderText = "Access type";
            this.AccessColumn.Name = "AccessColumn";
            this.AccessColumn.Width = 200;
            // 
            // HasAccessColumn
            // 
            this.HasAccessColumn.HeaderText = "Has access?";
            this.HasAccessColumn.Name = "HasAccessColumn";
            // 
            // topLabel
            // 
            this.topLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.topLabel.Location = new System.Drawing.Point(12, 9);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(389, 45);
            this.topLabel.TabIndex = 1;
            this.topLabel.Text = "Modifying access for {username} :";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Close this form to save changes.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccessModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 238);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.accessGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AccessModifier";
            this.Text = "Modify Access";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccessModifier_FormClosed);
            this.Load += new System.EventHandler(this.AccessModifier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accessGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView accessGridView;
        private Label topLabel;
        private Label label2;
        private DataGridViewTextBoxColumn AccessColumn;
        private DataGridViewCheckBoxColumn HasAccessColumn;
    }
}