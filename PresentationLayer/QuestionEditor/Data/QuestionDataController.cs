using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using Commons.BusinessObjects;

namespace PresentationLayer.QuestionEditor.Data
{
    public class QuestionDataController
    {
        #region Trigger Event IdTestChange
        public event ActionEventHandler IdTestChange
        {
            add
            {
                lock (__idTestChangeEventLocker)
                {
                    _idTestChangeEvent += value;
                }
            }
            remove
            {
                lock (__idTestChangeEventLocker)
                {
                    _idTestChangeEvent -= value;
                }
            }
        }

        private ActionEventHandler _idTestChangeEvent;
        private readonly object __idTestChangeEventLocker = new object();

        private void OnIdTestChanged()
        {
            ActionEventHandler handler = _idTestChangeEvent;
            if (handler != null)
            {
                try
                {
                    handler(this);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion 

        private string _idTest;
        public string IdTest
        {
            set
            { 
                this._idTest = value;
                //FillDataItem();
                OnIdTestChanged();
            }
            get { return this._idTest; }
        }

        public int Count
        {
            get { return this._questionData.Count; }
        }

        private List<QuestionDataItem> _questionData;
        public List<QuestionDataItem> DataItems
        {
            set { this._questionData = value; }
            get { return this._questionData; }
        } 

        public QuestionDataController()
        {
            Initialize();
            InitEvent();
        }

        public QuestionDataController(TestBE testBe)
        {
            Initialize(testBe);
            InitEvent();
        }

        #region Init Function
        private void Initialize()
        {
            this._questionData = new List<QuestionDataItem>();
            //FillDataItem();
        }

        private void Initialize(TestBE testBe)
        {
            this._questionData = new List<QuestionDataItem>();
            FillDataItem(testBe);
        }

        private void InitEvent()
        {
            
        }

        #endregion

        public void FillDataItem(TestBE testBe)
        {
            CreateData(testBe);
        }

        public void CreateDataForTest()
        {
            _questionData.Clear();
            for (int i = 1; i <= 10; i++)
            {
                var dataItem = new QuestionDataItem();
                dataItem.ContentQuestion = "Which one of the five is least like the other four?";
                dataItem.IdQuestion = i.ToString();
                dataItem.OrderQuestion = i;
                dataItem.imageName = null;
                var answerController = new AnswerDataController(i);
                for (int j = 1; j <= 4; j++)
                {
                    var answer = new AnswerDataItem();
                    answer.ContentAnswer = "Elephant";
                    answer.OrderAnswer = j;
                    answerController.Add(answer);
                }
                dataItem.AnswerData = answerController;
                _questionData.Add(dataItem);
            }
        }

        public void CreateData(TestBE testBe)
        {
            _questionData.Clear();
            if (testBe.ListQuestion == null)
            {
                return;
            }
            for (int i = 0; i < testBe.ListQuestion.Count; i++)
            {
                var questionBE = testBe.ListQuestion[i];
                var dataItem = new QuestionDataItem();
                dataItem.ContentQuestion = questionBE.QuestionContent;
                dataItem.IdQuestion = questionBE.QuestionID;
                dataItem.OrderQuestion = i;
                dataItem.imageName = null;
                var answerController = new AnswerDataController(i);
                for (int j = 0; j <= questionBE.ListAnswers.Count; j++)
                {
                    var answer = new AnswerDataItem();
                    answer.ContentAnswer = questionBE.ListAnswers[i].Content;
                    answer.OrderAnswer = j;
                    answerController.Add(answer);
                }
                dataItem.AnswerData = answerController;
                _questionData.Add(dataItem);
            }
        }
    }
}
