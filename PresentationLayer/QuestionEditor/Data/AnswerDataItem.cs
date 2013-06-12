using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.QuestionEditor.Data
{
    public class AnswerDataItem
    {
        public int OrderAnswer { set; get; }
        public string ContentAnswer { set; get; }
        public bool IsAnswer { set; get; }

        public AnswerDataItem()
        {
            
        }

        public static AnswerDataItem TranslateToAnswerDataItem()
        {
            AnswerDataItem answer = new AnswerDataItem();
            return answer;
        }
    }
}
