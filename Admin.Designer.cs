namespace Auth_Login
{
    partial class Admin
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
            this.userListGridView = new System.Windows.Forms.DataGridView();
            this.UsernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PasswordResetColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.maxForTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxForLock = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.minPassLength = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.requiresNumber = new System.Windows.Forms.CheckBox();
            this.requiresSpecialChar = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxForTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxForLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPassLength)).BeginInit();
            this.SuspendLayout();
            // 
            // userListGridView
            // 
            this.userListGridView.AllowUserToAddRows = false;
            this.userListGridView.AllowUserToDeleteRows = false;
            this.userListGridView.AllowUserToResizeColumns = false;
            this.userListGridView.AllowUserToResizeRows = false;
            this.userListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsernameColumn,
            this.AccessColumn,
            this.PasswordResetColumn});
            this.userListGridView.Location = new System.Drawing.Point(12, 12);
            this.userListGridView.Name = "userListGridView";
            this.userListGridView.RowHeadersVisible = false;
            this.userListGridView.RowTemplate.Height = 25;
            this.userListGridView.Size = new System.Drawing.Size(403, 222);
            this.userListGridView.TabIndex = 0;
            this.userListGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userListGridView_CellContentClick);
            // 
            // UsernameColumn
            // 
            this.UsernameColumn.HeaderText = "Username";
            this.UsernameColumn.Name = "UsernameColumn";
            this.UsernameColumn.ReadOnly = true;
            this.UsernameColumn.Width = 200;
            // 
            // AccessColumn
            // 
            this.AccessColumn.HeaderText = "Access";
            this.AccessColumn.Name = "AccessColumn";
            // 
            // PasswordResetColumn
            // 
            this.PasswordResetColumn.HeaderText = "Reset password";
            this.PasswordResetColumn.Name = "PasswordResetColumn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "- Login settings -";
            // 
            // maxForTimeout
            // 
            this.maxForTimeout.Location = new System.Drawing.Point(12, 291);
            this.maxForTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxForTimeout.Name = "maxForTimeout";
            this.maxForTimeout.Size = new System.Drawing.Size(120, 23);
            this.maxForTimeout.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max login tries before timeout :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max login tries before getting locked :";
            // 
            // maxForLock
            // 
            this.maxForLock.Location = new System.Drawing.Point(12, 339);
            this.maxForLock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxForLock.Name = "maxForLock";
            this.maxForLock.Size = new System.Drawing.Size(120, 23);
            this.maxForLock.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "- Password settings -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Minimum length :";
            // 
            // minPassLength
            // 
            this.minPassLength.Location = new System.Drawing.Point(249, 291);
            this.minPassLength.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.minPassLength.Name = "minPassLength";
            this.minPassLength.Size = new System.Drawing.Size(120, 23);
            this.minPassLength.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Requires number :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Requires special char :";
            // 
            // requiresNumber
            // 
            this.requiresNumber.AutoSize = true;
            this.requiresNumber.Location = new System.Drawing.Point(358, 324);
            this.requiresNumber.Name = "requiresNumber";
            this.requiresNumber.Size = new System.Drawing.Size(15, 14);
            this.requiresNumber.TabIndex = 11;
            this.requiresNumber.UseVisualStyleBackColor = true;
            // 
            // requiresSpecialChar
            // 
            this.requiresSpecialChar.AutoSize = true;
            this.requiresSpecialChar.Location = new System.Drawing.Point(378, 348);
            this.requiresSpecialChar.Name = "requiresSpecialChar";
            this.requiresSpecialChar.Size = new System.Drawing.Size(15, 14);
            this.requiresSpecialChar.TabIndex = 12;
            this.requiresSpecialChar.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(168, 368);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 401);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.requiresSpecialChar);
            this.Controls.Add(this.requiresNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.minPassLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxForLock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxForTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userListGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Admin";
            this.Text = "Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_FormClosed);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxForTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxForLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPassLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView userListGridView;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewButtonColumn AccessColumn;
        private DataGridViewButtonColumn PasswordResetColumn;
        private Label label1;
        private NumericUpDown maxForTimeout;
        private Label label2;
        private Label label3;
        private NumericUpDown maxForLock;
        private Label label4;
        private Label label5;
        private NumericUpDown minPassLength;
        private Label label6;
        private Label label7;
        private CheckBox requiresNumber;
        private CheckBox requiresSpecialChar;
        private Button saveButton;
    }
}