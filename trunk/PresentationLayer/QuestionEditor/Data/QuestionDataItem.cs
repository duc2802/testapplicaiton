using System;
using System.Collections.Generic;
using System.ComponentModel;
using BusinessEntities;
using PropertyChangedEventHandler = Commons.BusinessObjects.PropertyChangedEventHandler;

namespace PresentationLayer.QuestionEditor.Data
{
    public class QuestionDataItem
    {
        private AnswerDataController _answers = new AnswerDataController();
        private string _contentQuestion;
        private int _orderQuestion;
        public int Height { set; get; }
        public string IdQuestion { set; get; }
        public string ExplainContent { set; get; }
        public string imageName { set; get; }

        public int OrderQuestion
        {
            set
            {
                _orderQuestion = value;
                OnPropertyChanged("OrderQuestion");
            }
            get { return _orderQuestion; }
        }

        public string ContentQuestion
        {
            set
            {
                _contentQuestion = value;
                OnPropertyChanged("ContentQuestion");
            }
            get { return _contentQuestion; }
        }

        public AnswerDataController AnswerData
        {
            set { _answers = value; }
            get { return _answers; }
        }

        public QuestionBE getQuestionBE()
        {
            var qBe = new QuestionBE();
            qBe.QuestionID = IdQuestion;
            qBe.QuestionContent = ContentQuestion;
            qBe.Explain = ExplainContent;
            qBe.ListAnswers = new List<AnswerBE>();
            foreach (AnswerDataItem answer in AnswerData.AnswerData)
            {
                var answerBe = new AnswerBE();
                answerBe.AnswerID = answer.orderAnswer.ToString();
                answerBe.Content = answer.ContentAnswer;
                if (answer.isTrue)
                {
                    answerBe.Result = "1";
                }
                else
                {
                    answerBe.Result = "0";
                }
                qBe.ListAnswers.Add(answerBe);
            }

            return qBe;
        }

        #region Trigger Event

        private readonly object _propertyChangedEventLocker = new object();
        private PropertyChangedEventHandler _propertyChangedEvent;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                lock (_propertyChangedEventLocker)
                {
                    _propertyChangedEvent += value;
                }
            }
            remove
            {
                lock (_propertyChangedEventLocker)
                {
                    _propertyChangedEvent -= value;
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler;
            lock (_propertyChangedEventLocker)
                handler = _propertyChangedEvent;

            if (handler == null)
            {
                return;
            }
            try
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                //Log here
            }
        }

        #endregion
    }
}