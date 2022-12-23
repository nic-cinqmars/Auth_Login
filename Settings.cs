using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Auth_Login
{
    internal class SettingsSerialize
    {
        public int maxTriesTimeout { get; set; }
        public int maxTriesLock { get; set; }
        public int minPassLength { get; set; }
        public bool passRequiresNum { get; set; }
        public bool passRequiresSpecialChar { get; set; }
    }

    internal static class Settings
    {
        private static readonly string SETTINGS_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) 
            + "\\Resources\\settings.cfg";

        public static int maxTriesTimeout = 0;
        public static int maxTriesLock = 0;
        public static int minPassLength = 0;
        public static bool passRequiresNum = false;
        public static bool passRequiresSpecialChar = false;

        public static void Load()
        {
            if (File.Exists(SETTINGS_PATH))
            {
                string json = File.ReadAllText(SETTINGS_PATH);
                SettingsSerialize? settings = JsonSerializer.Deserialize<SettingsSerialize>(json);
                if (settings != null)
                {
                    maxTriesTimeout = settings.maxTriesTimeout;
                    maxTriesLock = settings.maxTriesLock;
                    minPassLength = settings.minPassLength;
                    passRequiresNum = settings.passRequiresNum;
                    passRequiresSpecialChar = settings.passRequiresSpecialChar;
                }
            }
        }

        public static void Save()
        {
            SettingsSerialize settings = new SettingsSerialize();
            settings.maxTriesTimeout = maxTriesTimeout;
            settings.maxTriesLock = maxTriesLock;
            settings.minPassLength = minPassLength;
            settings.passRequiresNum = passRequiresNum;
            settings.passRequiresSpecialChar = passRequiresSpecialChar;
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(SETTINGS_PATH, json);
        }
    }
}
