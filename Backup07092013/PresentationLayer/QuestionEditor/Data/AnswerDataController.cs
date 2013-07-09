using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.QuestionEditor.Data
{
    public class AnswerDataController
    {
        public int IdQuestion{ set; get; }

        private List<AnswerDataItem> _answerData;
        public List<AnswerDataItem> AnswerData
        {
            set { this._answerData = value; }
            get { return this._answerData; }
        }

        public AnswerDataController(int idQuestion)
        {
            Initialize(idQuestion);
            InitEvent();
        }

        public AnswerDataController()
        {
            _answerData = new List<AnswerDataItem>();
        }

        private void Initialize(int IdAnswer)
        {
            this.IdQuestion = IdAnswer;
            this._answerData = new List<AnswerDataItem>();
        }

        private void InitEvent()
        {
            
        }

        public void Add(AnswerDataItem item)
        {
            this._answerData.Add(item);
        }

        public void Remove(AnswerDataItem item)
        {
            this._answerData.Remove(item);
        }
    }
}
