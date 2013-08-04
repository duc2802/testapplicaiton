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
        public string TimeOfTest { set; get; }
        public string Date { set; get; }

        public TestDataListViewItem(TestBE test)
        {
            Title = test.Information;
            NumOfQuestion = test.ListQuestion != null ? test.ListQuestion.Count : test.NumberOfQuestion;
            Date = test.DateCreate;
            Id = test.TestID;
            TimeOfTest = test.Time;
        }

        public ListViewItem ConvertToListItem()
        {
            var item = new ListViewItem(Title);
            item.Tag = Id;
            item.SubItems.Add(NumOfQuestion.ToString());
            item.SubItems.Add(Date);
            item.SubItems.Add(TimeOfTest);
            return item;
        }
    }
}
