using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BusinessEntities;
using Commons;
using SingleInstanceObject;

namespace DataAccessLayer
{
    public class TestDAL
    {
        public static List<TestBE> ScanTestExamFile(string folder)
        {
            string pathFolder = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + folder;
            var directory = new DirectoryInfo(pathFolder);
            var fileList = directory.GetFiles("*.exam");
            var testBeList = fileList.Select(fileInfo => XmlHelper.ReadExamFile(fileInfo.FullName)).ToList();
            return testBeList;
        }

        public static bool DeleteTestExamFile(string fileName, string folder)
        {
            try
            {
                string pathFile = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + folder + "\\" + fileName +
                                  ".exam";
                var fileInfo = new FileInfo(pathFile);
                fileInfo.Delete();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static TestBE LoadTestBE(string testId, string folder)
        {
            string path = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + folder + "\\" + testId
                              + ".exam";
            var testBE = XmlHelper.ReadExamFile(path);
            return testBE;
        }
    }
}
