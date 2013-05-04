using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Explorer
{
    class TestDataItem
    {
        #region Properties of TestDataItem

        public string Title
        {
            set; 
            get;
        }

        public DateTime DateCreate
        {
            set;
            get;
        }

        public int NumberQuestion
        {
            set;
            get;
        }

        #endregion

        public TestDataItem()
        {
            
        }

        public TestDataItem(string title, DateTime date, int numOfQuestion)
        {
            Title = title;
            DateCreate = date;
            NumberQuestion = numOfQuestion;
        }
    }
}
