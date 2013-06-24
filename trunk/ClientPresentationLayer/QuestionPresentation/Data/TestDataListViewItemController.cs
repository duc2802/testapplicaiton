using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using SingleInstanceObject;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class TestDataListViewItemController
    {
        public List<TestDataListViewItem> DataItems = new List<TestDataListViewItem>();

        public List<ListViewItem> DisplayItems
        {
            get { return TranslatDisplayItem(); }
        }

        public TestDataListViewItemController()
        {
            foreach (var test in Singleton<List<TestBE>>.Instance)
            {
                var item = new TestDataListViewItem(test);
                DataItems.Add(item);
            }
        }

        private List<ListViewItem> TranslatDisplayItem()
        {
            return DataItems.Select(dataItem => dataItem.ConvertToListItem()).ToList();
        }
    }
}
