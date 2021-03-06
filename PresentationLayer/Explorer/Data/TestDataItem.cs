﻿using System;
using BusinessEntities;
using Commons;
using PresentationLayer.QuestionEditor.Data;

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
            DateCreate = DateTime.Parse(testBe.DateCreate);
            Time = int.Parse(testBe.Time);
            if (testBe.ListQuestion != null)
            {
                NumberQuestion = testBe.ListQuestion.Count;
            }
            else
            {
                NumberQuestion = testBe.NumberOfQuestion;
            }
        }

        private QuestionDataController _questions;
        public QuestionDataController QuestionData
        {
            set { this._questions = value; }
            get { return this._questions; }
        }


        public IDataBE TranslateToBE()
        {
            var testBe = new TestBE
                             {
                                 DateCreate = DateCreate.ToString(),
                                 TestID = IdTest,
                                 Information = Name,
                                 FolderId = FolderId,
                                 Time = Time.ToString(),
                                 NumberOfQuestion = NumberQuestion
                             };
            return testBe;
        }
    }
}
