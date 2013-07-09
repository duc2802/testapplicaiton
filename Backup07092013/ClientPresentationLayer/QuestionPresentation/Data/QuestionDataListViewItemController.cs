using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using SingleInstanceObject;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class QuestionDataListViewItemController
    {
        public int NumOfAttempted { set; get; }

        public int NumOfMarked { set; get; }

        public List<QuestionDataListViewItem> DataItems = new List<QuestionDataListViewItem>();

        public List<ListViewItem> DisplayItems
        {
            get { return TranslateDisplayItem(); }
        }

        public QuestionDataListViewItemController()
        {
            if (Singleton<TestBE>.Instance.ListQuestion != null)
            {
                int idx = 1;
                foreach (var question in Singleton<TestBE>.Instance.ListQuestion)
                {
                    var item = new QuestionDataListViewItem(idx, question);
                    DataItems.Add(item);
                    idx++;
                }
            }
        }

        public void FillQuestioinDataListViewItem()
        {
            if (Singleton<TestBE>.Instance.ListQuestion != null)
            {
                DataItems.Clear();
                int idx = 1;
                foreach (var question in Singleton<TestBE>.Instance.ListQuestion)
                {
                    var item = new QuestionDataListViewItem(idx, question);
                    DataItems.Add(item);
                    idx++;
                }
                CountAttempted();
                CountMarked();
            }
        }

        private void CountAttempted()
        {
            NumOfAttempted = DataItems.Count(item => item.Attempted);
        }

        private void CountMarked()
        {
            NumOfMarked = DataItems.Count(item => item.Marked);
        }
        
        private List<ListViewItem> TranslateDisplayItem()
        {
            var itemList = DataItems.Select(dataItem => dataItem.ConvertToListItem()).ToList();
            return itemList;
        }
    }
}
