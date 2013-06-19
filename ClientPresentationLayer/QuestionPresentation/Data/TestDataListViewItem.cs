using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class TestDataListViewItem
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public int NumOfQuestion { set; get; }
        public string Date { set; get; }

        public TestDataListViewItem()
        {
            Title = "huynh minh Duc";
            NumOfQuestion = 10;
            Date = "20/06/2013";
        }

        public ListViewItem convertToListItem()
        {
            var item = new ListViewItem(Title);
            item.Tag = Id;
            item.SubItems.Add(NumOfQuestion.ToString());
            item.SubItems.Add(Date);
            return item;
        }
    }
}
