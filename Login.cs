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

        private int attemptsCount = 0;
        private TimeSpan timeoutTime = TimeSpan.FromSeconds(30);
        private DateTime startTime;
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
            startTime = DateTime.MinValue;
            Settings.Load();
            AccessManager.Setup();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool isTimeout = true;
            if (DateTime.Now - startTime > timeoutTime)
            {
                isTimeout = false;
            }
            if (!isTimeout)
            {
                string username = usernameBox.Text;
                attemptsCount++;
                try
                {
                    User user = Authentifier.LoginUser(username, passwordBox.Text);
                    user.GetAccess().ForEach(access =>
                    {
                        switch (access)
                        {
                            case ACCESS.None:
                                NoAccess noAccessForm = new NoAccess();
                                noAccessForm.Show();
                                break;
                            case ACCESS.Admin:
                                Admin adminForm = new Admin();
                                adminForm.Show();
                                break;
                            case ACCESS.Residential:
                                Residential residentialForm = new Residential(user.GetUsername());
                                residentialForm.Show();
                                break;
                            case ACCESS.Buisness:
                                Buisness buisnessForm = new Buisness(user.GetUsername());
                                buisnessForm.Show();
                                break;
                        }
                    });
                    Hide();
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

                if (attemptsCount % Settings.maxTriesTimeout == 0)
                {
                    infoLabel.ForeColor = Color.Red;
                    infoLabel.Text = "Too many attempts, try again in 30 seconds.";
                    startTime = DateTime.Now;

                }

                if (attemptsCount % Settings.maxTriesLock == 0)
                {
                    Authentifier.BlockUser(username);
                    infoLabel.ForeColor = Color.Red;
                    infoLabel.Text = "Too many attempts, this account is now locked!";
                    attemptsCount = 0;
                }
            }
            else
            {
                infoLabel.ForeColor = Color.Red;
                infoLabel.Text = "Too many attempts, try again in " + (timeoutTime - (DateTime.Now - startTime)).Seconds + " seconds.";
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you have forgotten your password, please contact your administrator to get a new one.");
        }
    }
}