using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PropertyChangedEventHandler = Commons.BusinessObjects.PropertyChangedEventHandler;

namespace PresentationLayer.QuestionEditor.Data
{
    public class QuestionDataItem
    {
        public int Height { set; get; }
        public int IdQuestion { set; get; }
        public string explain { set; get; }
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

        private AnswerDataController _answers;
        public AnswerDataController  AnswerData
        {
            set { this._answers = value; }
            get { return this._answers; }
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
