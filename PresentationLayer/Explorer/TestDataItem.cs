using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Explorer
{
    public class TestDataItem
    {
        #region Properties of TestDataItem
        public int IdTest { set; get; }
        public string Title { set; get; }
        public DateTime DateCreate { set; get; }
        public int NumberQuestion { set; get; }
        #endregion

        public TestDataItem()
        {
            
        }

        public TestDataItem(int id, string title, DateTime date, int numOfQuestion)
        {
            IdTest = id;
            Title = title;
            DateCreate = date;
            NumberQuestion = numOfQuestion;
        }
    }
}
