using System.Reflection;
using System.Text.RegularExpressions;

namespace Auth_Login
{
    internal static class Authentifier
    {
        private static readonly string RESOURCES_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Resources\\";
        private static readonly string PASSWORDS_PATH = RESOURCES_PATH + "passwords.dat";
        private static readonly string USERNAME_PASSWORD = "8NGj1I1$!qN6";

        private static User? currentUser = null;

        public static User LoginUser(string username, string password)
        {
            Logger.LogLoginAttempt(username);
            string userLine = GetLineFromUsername(username);
            if (userLine != "")
            {
                string[] data = userLine.Split(' ');
                if (username != "Admin" && data[3] == "1")
                {
                    throw new Exception("This user is now blocked from logging in. Please contact your administrator.");
                }
                byte[] salt = Convert.FromBase64String(data[2]);
                string hashedPassword = Cryptography.HashString(password, salt);
                if (hashedPassword == data[1])
                {
                    Logger.LogLogin(username);
                    currentUser = new User(username, salt);
                    return currentUser;
                }
                else
                {
                    throw new Exception("Invalid password!");
                }
            }
            else
            {
                throw new Exception("Username does not exist!");
            }
        }

        public static void RegisterUser(string username, string password)
        {
            Logger.LogRegisterAttempt(username);
            if (GetLineFromUsername(username) != "")
            {
                throw new Exception("Username already exists!");
            }

            if (!Regex.Match(username, "^[0-9]*[a-zA-Z]+[a-zA-Z0-9]*$").Success)
            {
                throw new Exception("Username must contain at least one letter and can only contain letters and numbers!");
            }

            try
            {
                CheckIfValidPassword(password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            byte[] salt = Cryptography.GetRandomBytes();

            string encryptedUsername = Cryptography.EncryptString(username, USERNAME_PASSWORD, salt);
            string hashedPassword = Cryptography.HashString(password, salt);
            string saltString = Convert.ToBase64String(salt);

            if (new FileInfo(PASSWORDS_PATH).Length > 0)
            {
                File.AppendAllTextAsync(PASSWORDS_PATH, "\n");
            }

            string userInfo = encryptedUsername + " " + hashedPassword + " " + saltString + " 0";
            Logger.LogRegister(username);
            File.AppendAllTextAsync(PASSWORDS_PATH, userInfo);
        }

        private static string GetLineFromUsername(string username)
        {
            if (!File.Exists(PASSWORDS_PATH))
            {
                return "";
            }
            foreach (string line in File.ReadLines(PASSWORDS_PATH))
            {
                string[] data = line.Split(' ');
                byte[] salt = Convert.FromBase64String(data[2]);
                string currentUsername = Cryptography.DecryptString(data[0], USERNAME_PASSWORD, salt);
                if (currentUsername == username)
                {
                    return line;
                }
            }
            return "";
        }

        public static void ChangePassword(string username, string oldPassword, string newPassword)
        {
            Logger.LogPasswordChangeAttempt(username);
            string userLine = GetLineFromUsername(username);
            if (userLine != "")
            {
                string[] data = userLine.Split(' ');
                byte[] salt = Convert.FromBase64String(data[2]);
                if (Cryptography.HashString(oldPassword, salt) == data[1])
                {
                    try
                    {
                        CheckIfValidPassword(newPassword);
                    } 
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    string hashedPassword = Cryptography.HashString(newPassword, salt);
                    string[] userLines = File.ReadAllLines(PASSWORDS_PATH);
                    for (int i = 0; i < userLines.Length; i++)
                    {
                        string line = userLines[i];
                        if (line.Split(' ')[0] == data[0])
                        {
                            userLines[i] = data[0] + " " + hashedPassword + " " + data[2] + " " + data[3];
                            break;
                        }
                    }
                    File.WriteAllLines(PASSWORDS_PATH, userLines);
                    Logger.LogPasswordChanged(username);
                }
                else
                {
                    throw new Exception("Invalid old password!");
                }
            } 
            else
            {
                throw new Exception("Could not find the username specified!");
            }
        }

        public static void ChangePassword(string username, string newPassword)
        {
            string userLine = GetLineFromUsername(username);
            if (userLine != "")
            {
                string[] data = userLine.Split(' ');
                byte[] salt = Convert.FromBase64String(data[2]);
                string hashedPassword = Cryptography.HashString(newPassword, salt);
                string[] userLines = File.ReadAllLines(PASSWORDS_PATH);
                for (int i = 0; i < userLines.Length; i++)
                {
                    string line = userLines[i];
                    if (line.Split(' ')[0] == data[0])
                    {
                        userLines[i] = data[0] + " " + hashedPassword + " " + data[2] + " " + 0;
                        break;
                    }
                }
                File.WriteAllLines(PASSWORDS_PATH, userLines);
                Logger.LogPasswordChanged(username);
            }
            else
            {
                throw new Exception("Could not find the username specified!");
            }
        }

        public static void BlockUser(string username)
        {
            string userLine = GetLineFromUsername(username);
            if (userLine != "")
            {
                string[] data = userLine.Split(' ');
                string[] userLines = File.ReadAllLines(PASSWORDS_PATH);
                for (int i = 0; i < userLines.Length; i++)
                {
                    string line = userLines[i];
                    if (line.Split(' ')[0] == data[0])
                    {
                        userLines[i] = data[0] + " " + data[1] + " " + data[2] + " " + 1;
                        break;
                    }
                }
                File.WriteAllLines(PASSWORDS_PATH, userLines);
            }
        }

        private static void CheckIfValidPassword(string password)
        {
            if (password.Length < Settings.minPassLength)
            {
                throw new Exception("Password must be a least " + Settings.minPassLength + " characters long!");
            }
            else if (password.Length > 64)
            {
                throw new Exception("Password must be at maximum 64 characters long!");
            }
            else if (Settings.passRequiresNum && !Regex.Match(password, "(?=.*[0-9])").Success)
            {
                throw new Exception("Password must contain at least one digit!");
            }
            else if (!Regex.Match(password, "(?=.*[a-z])").Success)
            {
                throw new Exception("Password must contain at least one lowercase letter!");
            }
            else if (!Regex.Match(password, "(?=.*[A-Z])").Success)
            {
                throw new Exception("Password must contain at least one uppercase letter!");
            }
            else if (Settings.passRequiresSpecialChar && !Regex.Match(password, "(?=.*\\W)").Success)
            {
                throw new Exception("Password must contain at least one special character!");
            }
            // If no exception is thrown, password is valid.
        }

        public static List<User>? GetUsers()
        {
            var users = new List<User>();

            if (!File.Exists(PASSWORDS_PATH))
            {
                return null;
            }

            foreach (string line in File.ReadLines(PASSWORDS_PATH))
            {
                string[] data = line.Split(' ');
                byte[] salt = Convert.FromBase64String(data[2]);
                string currentUsername = Cryptography.DecryptString(data[0], USERNAME_PASSWORD, salt);
                User currentUser = new User(currentUsername, salt);
                users.Add(currentUser);
            }

            return users;
        }

        public static string GetCurrentUsername()
        {
            if (currentUser != null)
            {
                return currentUser.GetUsername();
            }
            return "";
        }

    }
}
