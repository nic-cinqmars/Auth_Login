using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth_Login
{
    public partial class ChangePassword : Form
    {
        private string username;

        public ChangePassword(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (newPasswordBox.Text != newPasswordCheckBox.Text) 
            {
                infoLabel.ForeColor = Color.Red;
                infoLabel.Text = "Passwords don't match!";
            }

            try
            {
                Authentifier.ChangePassword(username, oldPasswordBox.Text, newPasswordBox.Text);
                infoLabel.ForeColor = Color.Green;
                infoLabel.Text = "Successfully changed password!";
                oldPasswordBox.Text = "";
                newPasswordBox.Text = "";
                newPasswordCheckBox.Text = "";
            } 
            catch (Exception ex)
            {
                infoLabel.ForeColor = Color.Red;
                infoLabel.Text = ex.Message;
            }
        }
    }
}
