using System.Collections.Generic;
using BusinessEntities;
using DataAccessLayer;

namespace TestApplication
{
    public class TestBLL
    {
        public bool ExportTestExamFile(TestBE testData, string name, string place)
        {
            return XmlHelper.WriteExamFile(testData, name, place);
        }

        public List<TestBE> ScanTestExamFile(string testId)
        {
            var testBEList = TestDAL.ScanTestExamFile(testId);
            return testBEList;
        }

        public List<TestBE> ScanClientTestExamFile(string testId)
        {
            var testBEList = TestDAL.ScanClientTestExamFile(testId);
            return testBEList;
        }

        public bool DeleteTestExamFile(string name, string foder)
        {
            return TestDAL.DeleteTestExamFile(name, foder);
        }
    }
}