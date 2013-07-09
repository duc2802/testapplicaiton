using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BusinessEntities;
using PropertyChangedEventHandler = Commons.BusinessObjects.PropertyChangedEventHandler;

namespace PresentationLayer.QuestionEditor.Data
{
    public class QuestionDataItem
    {
        public int Height { set; get; }
        public string IdQuestion { set; get; }
        public string ExplainContent { set; get; }
        public string imageName { set; get; }

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
        public AnswerDataController  AnswerData
        {
            set { this._answers = value; }
            get { return this._answers; }
        }

        public QuestionBE getQuestionBE()
        {
            QuestionBE qBe = new QuestionBE();
            qBe.QuestionID = this.IdQuestion.ToString();
            qBe.QuestionContent = this.ContentQuestion;
            qBe.Explain = this.ExplainContent;
            qBe.ListAnswers = new List<AnswerBE>();
            foreach (var answer in this.AnswerData.AnswerData)
            {
                AnswerBE answerBe = new AnswerBE();
                answerBe.AnswerID = answer.orderAnswer.ToString();
                answerBe.Content = answer.ContentAnswer;
                if(answer.isTrue)
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
