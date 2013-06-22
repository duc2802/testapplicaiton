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
    }
}
