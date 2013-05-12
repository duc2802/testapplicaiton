using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Explorer
{
    public class TestListDataItemController
    {
        #region TeskBook Propertiy
        private Dictionary<int, TestDataItem> _testBook = new Dictionary<int, TestDataItem>();

        public Dictionary<int, TestDataItem> TestBook
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
            for(int i = 0; i <= 20; i++)
            {
                TestDataItem testDataItem = new TestDataItem(i, string.Format("De thi {0} tieng anh HK 2", i + 1), new DateTime(), 20);
                _testBook.Add(i, testDataItem);
            }
        }
    }
}
