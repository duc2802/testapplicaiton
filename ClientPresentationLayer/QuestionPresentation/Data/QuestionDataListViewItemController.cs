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
            
        }

        private List<ListViewItem> TranslateDisplayItem()
        {
            return DataItems.Select(dataItem => dataItem.ConvertToListItem()).ToList();
        }
    }
}
