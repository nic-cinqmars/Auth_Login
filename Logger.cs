using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Login
{
    internal static class Logger
    {
        private static readonly string PATH_TO_FILE = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Resources\\logs.log";
        
        public static void LogLoginAttempt(string username)
        { 
            DateTime now = DateTime.Now;
            string log = "[" + now.ToString("MM/dd/yyyy HH:mm:ss") + "] ";
            log += " Attempted login for username '" + username + "'.";
            using (StreamWriter stream = File.AppendText(PATH_TO_FILE))
            {
                stream.WriteLine(log);
            }
        }

        public static void LogLogin(string username)
        {
            DateTime now = DateTime.Now;
            string log = "[" + now.ToString("MM/dd/yyyy HH:mm:ss") + "] ";
            log += " Successful login for username '" + username + "'.";
            using (StreamWriter stream = File.AppendText(PATH_TO_FILE))
            {
                stream.WriteLine(log);
            }
        }

        public static void LogRegisterAttempt(string username)
        {
            DateTime now = DateTime.Now;
            string log = "[" + now.ToString("MM/dd/yyyy HH:mm:ss") + "] ";
            log += " Attempted register for username '" + username + "'.";
            using (StreamWriter stream = File.AppendText(PATH_TO_FILE))
            {
                stream.WriteLine(log);
            }
        }

        public static void LogRegister(string username)
        {
            DateTime now = DateTime.Now;
            string log = "[" + now.ToString("MM/dd/yyyy HH:mm:ss") + "] ";
            log += " Successful register for username '" + username + "'.";
            using (StreamWriter stream = File.AppendText(PATH_TO_FILE))
            {
                stream.WriteLine(log);
            }
        }

        public static void LogPasswordChangeAttempt(string username)
        {
            DateTime now = DateTime.Now;
            string log = "[" + now.ToString("MM/dd/yyyy HH:mm:ss") + "] ";
            log += " '" + username + "' tried to change their password.";
            using (StreamWriter stream = File.AppendText(PATH_TO_FILE))
            {
                stream.WriteLine(log);
            }
        }

        public static void LogPasswordChanged(string username)
        {
            DateTime now = DateTime.Now;
            string log = "[" + now.ToString("MM/dd/yyyy HH:mm:ss") + "] ";
            log += " '" + username + "' changed their password.";
            using (StreamWriter stream = File.AppendText(PATH_TO_FILE))
            {
                stream.WriteLine(log);
            }
        }
    }
}
