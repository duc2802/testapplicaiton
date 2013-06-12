using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.QuestionEditor.Data
{
    public class QuestionDataItem
    {
        public int IdQuestion { set; get; }
        public int OrderQuestion { set; get; }
        public string ContentQuestion { set; get; }

        private AnswerDataController _answers;
        public AnswerDataController  AnswerData
        {
            set { this._answers = value; }
            get { return this._answers; }
        }
    }
}
