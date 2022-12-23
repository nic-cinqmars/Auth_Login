using System.Reflection;

namespace Auth_Login
{
    public partial class Residential : Form
    {
        private string username = "";
        private readonly string PATH_TO_FILE = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Resources\\residential.dat";
        private readonly string RESIDENTIAL_PASSWORD = "C!o33SY&vef8%";

        public Residential(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Residential_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = welcomeLabel.Text.Replace("{username}", username);

            if (File.Exists(PATH_TO_FILE))
            {
                foreach (string line in File.ReadLines(PATH_TO_FILE))
                {
                    string[] encryptedData = line.Split(' ');
                    byte[] salt = Convert.FromBase64String(encryptedData[1]);
                    string decryptedLine = Cryptography.DecryptString(encryptedData[0], RESIDENTIAL_PASSWORD, salt);

                    string[] data = decryptedLine.Split(';');
                    clientGridView.Rows.Add(data[0], data[1], data[2]);
                }
            }
        }

        private void Residential_FormClosed(object sender, FormClosedEventArgs e)
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
