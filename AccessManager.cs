using System.Reflection;

namespace Auth_Login
{
    public enum ACCESS
    {
        None = -1,
        Admin = 0,
        Residential = 1,
        Buisness = 2
    }

    internal static class AccessManager
    {
        private static readonly string ACCESS_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Resources\\access.dat";
        private static readonly string ACCESS_PASSWORD = "Password";
        
        private static List<string> _accessList = new List<string>();

        public static void Setup()
        {
            _accessList.Clear();
            if (File.Exists(ACCESS_PATH))
            {
                if (new FileInfo(ACCESS_PATH).Length > 0)
                {
                    string[] encryptedText = File.ReadAllText(ACCESS_PATH).Split(' ');
                    byte[] salt = Convert.FromBase64String(encryptedText[1]);
                    string decryptedList = Cryptography.DecryptString(encryptedText[0], ACCESS_PASSWORD, salt);
                    foreach (string userAccess in decryptedList.Split(';'))
                    {
                        if (userAccess != "")
                        {
                            _accessList.Add(userAccess);
                        }
                    }
                }
            }
            else
            {
                File.Create(ACCESS_PATH);
            }
        }

        public static List<ACCESS> GetUserAccess(User user)
        {
            List<ACCESS> userAccessList = new List<ACCESS>();
            string? access = _accessList.FirstOrDefault(s => s.Contains(user.GetUsername()));
            if (access != null)
            {
                access = access.Substring(access.IndexOf(':') + 1);
                foreach (string accessKey in access.Split(',')) 
                {
                    int accessValue = Convert.ToInt32(accessKey);
                    userAccessList.Add((ACCESS)accessValue);
                }
                return userAccessList;
            }
            else
            {
                string newAccess = CreateAccess(user);
                newAccess = newAccess.Substring(newAccess.IndexOf(':') + 1);
                foreach (string accessKey in newAccess.Split(','))
                {
                    int accessValue = Convert.ToInt32(accessKey);
                    userAccessList.Add((ACCESS)accessValue);
                }
                return userAccessList;
            }
        }

        public static string CreateAccess(User user)
        {
            string access = user.GetUsername();
            access += ":-1";
            _accessList.Add(access);
            SaveList();
            return access;
        }

        public static void SaveUserAccess(User user)
        {
            List<ACCESS> userAccess = user.GetAccess();
            string newAccessEntry = user.GetUsername();
            newAccessEntry += ":";
            foreach (ACCESS access in userAccess)
            {
                newAccessEntry += (int)access;
                newAccessEntry += ",";
            }
            newAccessEntry = newAccessEntry.Remove(newAccessEntry.Length - 1);

            int oldAccessEntry = _accessList.FindIndex(accessEntry => accessEntry.Contains(user.GetUsername()));
            if (oldAccessEntry != -1)
            {
                _accessList[oldAccessEntry] = newAccessEntry;
            }
            SaveList();
        }

        private static void SaveList()
        {
            byte[] salt = Cryptography.GetRandomBytes();
            string saltString = Convert.ToBase64String(salt);
            string list = "";
            foreach (string key in _accessList)
            {
                list += key;
                list += ";";
            }

            list = Cryptography.EncryptString(list, ACCESS_PASSWORD, salt);
            File.WriteAllText(ACCESS_PATH, list + " " + saltString);
        }
    }
}
