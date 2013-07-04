using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class QuestionDataListViewItem
    {
        public string NumberOrder { set; get; }

        public string Content { set; get; }

        public bool Attenpted { set; get; }

        public string TypeQuestion { set; get; }

        public string IdQuestion { set; get; }

        public QuestionDataListViewItem(int index, QuestionBE questionBe)
        {
            NumberOrder = index.ToString();
            Content = questionBe.QuestionContent;
            Attenpted = true;
            IdQuestion = questionBe.QuestionID;
            TypeQuestion = "Multichoise";
        }

        public ListViewItem ConvertToListItem()
        {
            var item = new ListViewItem("true");
            item.Tag = IdQuestion;
            item.SubItems.Add(NumberOrder);
            item.SubItems.Add(Content);
            item.SubItems.Add("true");
            item.SubItems.Add(TypeQuestion);
            return item;
        }
    }
}
