using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth_Login
{
    public partial class Buisness : Form
    {
        private string username = "";
        private readonly string PATH_TO_FILE = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Resources\\buisness.dat";
        private readonly string BUISNESS_PASSWORD = "ilp%04JfIl7%";

        public Buisness(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Buisness_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = welcomeLabel.Text.Replace("{username}", username);
            if (File.Exists(PATH_TO_FILE))
            {
                foreach (string line in File.ReadLines(PATH_TO_FILE))
                {
                    string[] encryptedData = line.Split(' ');
                    byte[] salt = Convert.FromBase64String(encryptedData[1]);
                    string decryptedLine = Cryptography.DecryptString(encryptedData[0], BUISNESS_PASSWORD, salt);

                    string[] data = decryptedLine.Split(';');
                    clientGridView.Rows.Add(data[0], data[1], data[2]);
                }
            }
        }

        private void Buisness_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword(username);
            form.ShowDialog();
        }
    }
}
