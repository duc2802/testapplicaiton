using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PropertyChangedEventHandler = Commons.BusinessObjects.PropertyChangedEventHandler;


namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class AnswerDataItem
    {
        public int orderAnswer { set; get; }
        private string contentAnswer { set; get; }
        public bool isTrue { set; get; }

        public AnswerDataItem()
        {

        }
        public AnswerDataItem(int oderAnswer, string contentAnswer, bool isTrue)
        {
            this.orderAnswer = orderAnswer;
            this.contentAnswer = contentAnswer;
            this.isTrue = isTrue;
        }

        public static AnswerDataItem TranslateToAnswerDataItem()
        {
            AnswerDataItem answer = new AnswerDataItem();
            return answer;
        }

        public int OrderAnswer
        {
            set
            {
                orderAnswer = value;
                OnPropertyChanged("OrderAnswer");
            }
            get
            {
                return orderAnswer;
            }
        }

        public string ContentAnswer
        {
            set
            {
                contentAnswer = value;
                OnPropertyChanged("ContentAnswer");
            }
            get
            {
                return contentAnswer;
            }
        }

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
    }
}