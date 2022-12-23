using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth_Login
{
    public partial class Admin : Form
    {
        private static char[] passwordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=".ToCharArray();

        private List<User>? users;

        public Admin()
        {
            InitializeComponent();
            users = Authentifier.GetUsers();
        }

        private string GetRandomPassword(int length = 10)
        {
            byte[] data = new byte[4 * length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                var random = BitConverter.ToUInt32(data, i * 4);
                var index = random % passwordChars.Length;

                password.Append(passwordChars[index]);
            }

            return password.ToString();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            maxForTimeout.Value = Settings.maxTriesTimeout;
            maxForLock.Value = Settings.maxTriesLock;
            minPassLength.Value = Settings.minPassLength;
            requiresNumber.Checked = Settings.passRequiresNum;
            requiresSpecialChar.Checked = Settings.passRequiresSpecialChar;

            if (users != null) 
            {
                foreach (User user in users)
                {
                    userListGridView.Rows.Add(user.GetUsername(), "Modify", "Reset");
                }
            }
        }

        private void userListGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                User? currentUser = users.Find(user => user.GetUsername() == userListGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (currentUser != null)
                {
                    AccessModifier form = new AccessModifier(currentUser);
                    form.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 2)
            {
                User? currentUser = users.Find(user => user.GetUsername() == userListGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (currentUser != null)
                {
                    string randomPassword = GetRandomPassword();
                    try
                    {
                        Authentifier.ChangePassword(currentUser.GetUsername(), randomPassword);
                        string textToDisplay = "User \"" + currentUser.GetUsername() + "\"'s password has been changed to : \"";
                        textToDisplay += randomPassword + "\". The password has been copied to your clipboard.";
                        Clipboard.Clear();
                        Clipboard.SetText(randomPassword);
                        MessageBox.Show(textToDisplay);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.maxTriesTimeout = (int)maxForTimeout.Value;
            Settings.maxTriesLock = (int)maxForLock.Value;
            Settings.minPassLength = (int)minPassLength.Value;
            Settings.passRequiresNum = requiresNumber.Checked;
            Settings.passRequiresSpecialChar = requiresSpecialChar.Checked;

            Settings.Save();
        }
    }
}
