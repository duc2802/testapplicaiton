using System;
using BusinessEntities;
using Commons;

namespace PresentationLayer.Explorer.Data
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
        public string FolderId { set; get; }

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

        public void ConvertFrom(TestBE testBe)
        {
            IdTest = testBe.TestID;
            Name = testBe.Information;
            FolderId = testBe.FolderId;
            //Time = new DateTime()      
        }

        public IDataBE TranslateToBE()
        {
            var testBe = new TestBE
                             {
                                 DateCreate = Time.ToString(),
                                 TestID = IdTest,
                                 Information = Name,
                                 FolderId = FolderId
                             };
            return testBe;
        }
    }
}
