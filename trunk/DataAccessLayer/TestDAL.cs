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

        public static List<TestBE> ScanClientTestExamFile(string folder)
        {
            string pathFolder = Singleton<SettingManager>.Instance.GetClientDataFolder();
            var directory = new DirectoryInfo(pathFolder);
            var fileList = directory.GetFiles("*.exam");
            var testBeList = fileList.Select(fileInfo => XmlHelper.ReadExamFile(fileInfo.FullName)).ToList();
            var resultList = new List<TestBE>();
            foreach (var testBe in testBeList)
            {
                var test = new TestBE();
                test.TestID = testBe.TestID;
                test.Time = testBe.Time;
                test.Information = testBe.Information;
                test.DateCreate = testBe.DateCreate;
                test.NumberOfQuestion = testBe.ListQuestion.Count;
                resultList.Add(test);
            }
            return resultList;
        }

        public static bool DeleteTestExamFile(string testId, string forder)
        {
            try
            {
                string path = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + forder + "\\" + testId
                             + ".exam";
                var fileInfo = new FileInfo(path);
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

        public static bool DeleteTestExamFileClient(string testId)
        {
            try
            {
                string path = Singleton<SettingManager>.Instance.GetClientDataFolder() + "\\" + testId
                              + ".exam";
                var fileInfo = new FileInfo(path);
                fileInfo.Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static TestBE LoadTestBEClient(string testId)
        {
            string path = Singleton<SettingManager>.Instance.GetClientDataFolder() + "\\" + testId
                              + ".exam";
            var testBE = XmlHelper.ReadExamFile(path);
            return testBE;
        }
    }
}
