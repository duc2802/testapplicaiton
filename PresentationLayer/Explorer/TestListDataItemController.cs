using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Explorer
{
    public class TestListDataItemController
    {
        #region TeskBook Propertiy
        private Dictionary<string, TestDataItem> _testBook = new Dictionary<string, TestDataItem>();

        public Dictionary<string, TestDataItem> TestBook
        {
            get{ return _testBook; }
            private set { this._testBook = value; }
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
                TestDataItem testDataItem = new TestDataItem(i, string.Format("De thi {0} tieng anh HK 2", i + 1), new DateTime(), 20,30);
                _testBook.Add(i.ToString(), testDataItem);
            }
        }

        public void LoadTestDataItem(string idFolder)
        {
            _testBook.Clear();
            for (int i = 0; i <= 10; i++)
            {
                TestDataItem testDataItem = new TestDataItem(i, string.Format("De thi {0} Test", i + 1), new DateTime(), 20, 60);
                _testBook.Add(i.ToString(), testDataItem);
            }
        }
    }
}
