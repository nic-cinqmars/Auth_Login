using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            string userLine = GetLineFromUsername(username);
            if (userLine != "")
            {
                string[] data = userLine.Split(' ');
                byte[] salt = Convert.FromBase64String(data[2]);
                string hashedPassword = Cryptography.HashString(password, salt);
                if (hashedPassword == data[1])
                {
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
            if (GetLineFromUsername(username) != "")
            {
                throw new Exception("Username already exists!");
            }

            if (password.Length < 8)
            {
                throw new Exception("Password must be a least 8 characters long!");
            }
            else if (password.Length > 64)
            {
                throw new Exception("Password must be at maximum 64 characters long!");
            }

            if (!Regex.Match(password, "(?=.*[0-9])").Success)
            {
                throw new Exception("Password must contain at least one digit!");
            }
            if (!Regex.Match(password, "(?=.*[a-z])").Success)
            {
                throw new Exception("Password must contain at least one lowercase letter!");
            }
            if (!Regex.Match(password, "(?=.*[A-Z])").Success)
            {
                throw new Exception("Password must contain at least one uppercase letter!");
            }
            if (!Regex.Match(password, "(?=.*\\W)").Success)
            {
                throw new Exception("Password must contain at least one special character!");
            }

            byte[] salt = Cryptography.GetRandomBytes();

            string encryptedUsername = Cryptography.EncryptString(username, USERNAME_PASSWORD, salt);
            string hashedPassword = Cryptography.HashString(password, salt);
            string saltString = Convert.ToBase64String(salt);

            if (new FileInfo(PASSWORDS_PATH).Length > 0)
            {
                File.AppendAllTextAsync(PASSWORDS_PATH, "\n");
            }

            string userInfo = encryptedUsername + " " + hashedPassword + " " + saltString;
            Console.WriteLine(userInfo);
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
