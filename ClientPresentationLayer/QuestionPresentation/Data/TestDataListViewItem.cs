using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class TestDataListViewItem
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public int NumOfQuestion { set; get; }
        public string Date { set; get; }

        public TestDataListViewItem(TestBE test)
        {
            Title = test.Information;
            NumOfQuestion = test.ListQuestion.Count;
            Date = test.DateCreate;
            Id = test.TestID;
        }

        public ListViewItem ConvertToListItem()
        {
            var item = new ListViewItem(Title);
            item.Tag = Id;
            item.SubItems.Add(NumOfQuestion.ToString());
            item.SubItems.Add(Date);
            return item;
        }
    }
}
