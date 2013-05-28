using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Setting
{
    public class SettingManager
    {
        public string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        protected const string TestEasyFolder = "TestEasy";

        protected const string LogFolder = "Logs";
        protected const string SettingFolder = "Setting";
        protected const string DataFolder = "Data";

        public SettingManager()
        {
            
        }

        public string GetTestEasyFolder()
        {
            return Path.Combine(AppDataPath, TestEasyFolder);
        }

        public string GetDataFolder()
        {
            return Path.Combine(AppDataPath, string.Format("{0}\\{1}", TestEasyFolder, DataFolder));
        }
    }
}
