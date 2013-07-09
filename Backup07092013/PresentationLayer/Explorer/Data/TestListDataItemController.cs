using System;
using System.Collections.Generic;
using BusinessEntities;
using PresentationLayer.Explorer.Data;
using SingleInstanceObject;
using TestApplication;
using System.Linq;

namespace PresentationLayer.Explorer
{
    public class TestListDataItemController
    {
        #region TeskBook Propertiy

        private Dictionary<string, TestDataItem> _testBook = new Dictionary<string, TestDataItem>();

        public Dictionary<string, TestDataItem> TestBook
        {
            get { return _testBook; }
            private set { _testBook = value; }
        }

        #endregion End TestBook Property.

        public TestListDataItemController()
        {
            Init();
        }

        private void Init()
        {
            for (int i = 0; i <= 20; i++)
            {
                var testDataItem = new TestDataItem(i.ToString(), string.Format("De thi {0} tieng anh HK 2", i + 1),
                                                    new DateTime(), 20, 30);
                _testBook.Add(i.ToString(), testDataItem);
            }
        }

        public void LoadTestDataItem(string idFolder)
        {
            _testBook.Clear();
            var listTestBE = (from test in Singleton<List<TestBE>>.Instance
                                 where test.FolderId.Equals(idFolder)
                                 select test);
            foreach (var test in listTestBE)
            {
                var testDataItem = new TestDataItem();
                testDataItem.ConvertFrom(test);
                _testBook.Add(testDataItem.IdTest, testDataItem);
            }
        }
         
        
    }
}