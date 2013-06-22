using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Explorer
{
    public class TestDataItem
    {
        #region Properties of TestDataItem
        public string IdTest { set; get; }
        public string Name { set; get; }
        public DateTime DateCreate { set; get; }
        public int NumberQuestion { set; get; }
        public int Time { set; get; }
        public int OrderNumber { set; get; }
        #endregion

        public TestDataItem()
        {
            
        }

        public TestDataItem(string id, string name, DateTime date, int numOfQuestion, int time)
        {
            IdTest = id;
            Name = name;
            DateCreate = date;
            NumberQuestion = numOfQuestion;
            Time = time;
        }
    }
}
