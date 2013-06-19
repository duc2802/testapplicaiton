using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            for(int idx = 0; idx < 20; idx++)
            {
                var item = new TestDataListViewItem();
                DataItems.Add(item);
            }
        }

        private List<ListViewItem> TranslatDisplayItem()
        {
            return DataItems.Select(dataItem => dataItem.convertToListItem()).ToList();
        }
    }
}
