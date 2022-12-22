using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Auth_Login
{
    public partial class Login : Form
    {
        private static readonly string RESOURCES_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Resources\\";
        private static readonly string PASSWORDS_PATH = RESOURCES_PATH + "passwords.dat";
        private static readonly string USERNAME_PASSWORD = "8NGj1I1$!qN6";
        private static readonly string ROLE_PASSWORD = "Password";
        private static readonly string PASSWORD = "19DMI^sAt1^U";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!File.Exists(PASSWORDS_PATH))
            {
                Directory.CreateDirectory(RESOURCES_PATH);
                File.Create(PASSWORDS_PATH);
            }
            AccessManager.Setup();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                User user = Authentifier.LoginUser(usernameBox.Text, passwordBox.Text);
                user.GetAccess().ForEach(access =>
                {
                    switch (access)
                    {
                        case AccessManager.ACCESS.None:
                            NoAccess noAccessForm = new NoAccess();
                            noAccessForm.ShowDialog();
                            break;
                        case AccessManager.ACCESS.Admin:
                            Admin adminForm = new Admin();
                            adminForm.ShowDialog();
                            break;
                        case AccessManager.ACCESS.Residential:
                            Residential residentialForm = new Residential();
                            residentialForm.ShowDialog();
                            break;
                        case AccessManager.ACCESS.Buisness:
                            Buisness buisnessForm = new Buisness();
                            buisnessForm.ShowDialog();
                            break;
                    }
                });
                Close();
            }
            catch (Exception ex)
            {
                infoLabel.ForeColor = Color.Red;
                infoLabel.Text = ex.Message;
            }
            finally
            {
                usernameBox.Text = "";
                passwordBox.Text = "";
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                Authentifier.RegisterUser(usernameBox.Text, passwordBox.Text);
                infoLabel.ForeColor = Color.Green;
                infoLabel.Text = "User registered!";
            }
            catch (Exception ex)
            {
                infoLabel.ForeColor = Color.Red;
                infoLabel.Text = ex.Message;
            }
            finally
            {
                usernameBox.Text = "";
                passwordBox.Text = "";
            }
        }
    }
}