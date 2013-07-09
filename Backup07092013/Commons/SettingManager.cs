using System;
using System.IO;

namespace Commons
{
    public class SettingManager
    {
        public string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        protected const string TestEasyFolder = "TestEasy";
        protected const string LogFolder = "Logs";
        protected const string SettingFolder = "Setting";
        protected const string DataFolder = "Data";
        protected const string ClientDataFolder = "ClientData";
        protected const string DataImageFolder = "Images";
        protected const string Commands = "commands";


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

        public string GetImageFolder()
        {
            return Path.Combine(AppDataPath, string.Format("{0}\\{1}\\{2}", TestEasyFolder,DataFolder, DataImageFolder));
        }

        public string GetImageEditorFolder()
        {
            return Path.Combine(AppDataPath, string.Format("{0}\\{1}\\{2}\\{3}", TestEasyFolder, DataFolder, DataImageFolder,Commands));
        }

        public string GetClientDataFolder()
        {
            return Path.Combine(AppDataPath, string.Format("{0}\\{1}", TestEasyFolder, ClientDataFolder));
        }
    }
}
