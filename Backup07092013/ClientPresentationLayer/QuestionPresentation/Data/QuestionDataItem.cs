using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BusinessEntities;
using PropertyChangedEventHandler = Commons.BusinessObjects.PropertyChangedEventHandler;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class QuestionDataItem
    {
        public int IdQuestion { set; get; }
        public string Explain { set; get; }
        public string ImageName { set; get;}
        public string IsDone { set; get; }
        public string IsTrue { set; get; }

        private int _orderQuestion;
        public int OrderQuestion
        {
            set
            {
                _orderQuestion = value;
                OnPropertyChanged("OrderQuestion");
            }
            get
            {
                return _orderQuestion;
            }
        }

        private string _contentQuestion;
        public string ContentQuestion
        {
            set
            {
                _contentQuestion = value;
                OnPropertyChanged("ContentQuestion");
            }
            get
            {
                return _contentQuestion;
            }
        }

        private AnswerDataController _answers = new AnswerDataController();
        public AnswerDataController AnswerData
        {
            set { this._answers = value; }
            get { return this._answers; }
        }

        public void Translate(QuestionBE questionBe)
        {
            IdQuestion = int.Parse(questionBe.QuestionID);
            ContentQuestion = questionBe.QuestionContent;
            _answers = new AnswerDataController();
            foreach(var choice in questionBe.ListAnswers)
            {
                var answer = new AnswerDataItem();
                answer.ContentAnswer = choice.Content;
                answer.OrderAnswer = int.Parse(choice.AnswerID);
                answer.orderAnswer = int.Parse(choice.AnswerID);
                _answers.Add(answer);
            }
        }

        #region Trigger Event
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

        private PropertyChangedEventHandler _propertyChangedEvent;
        private readonly object _propertyChangedEventLocker = new object();

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler;
            lock (this._propertyChangedEventLocker)
                handler = this._propertyChangedEvent;

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
