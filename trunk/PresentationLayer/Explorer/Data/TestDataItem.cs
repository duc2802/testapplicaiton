using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using Commons;

namespace PresentationLayer.Explorer
{
    public class TestDataItem : IDataItem
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

        public IDataBE TranslateToBE()
        {
            var testBe = new TestBE
                             {
                                 DateCreate = Time.ToString(),
                                 TestID = IdTest,
                                 Information = Name
                             };
            return testBe;
        }
    }
}
