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
    }
}