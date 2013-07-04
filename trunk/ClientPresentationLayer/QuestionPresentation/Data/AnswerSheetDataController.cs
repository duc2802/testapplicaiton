using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class AnswerSheetDataController
    {
        public string TestId { set; get; }

        public int Score { set; get; }

        //<string, int> --> <questionId, answer index>
        public Dictionary<string, List<int>> AnswerSheet { set; get; }

        public AnswerSheetDataController()
        {
            AnswerSheet = new Dictionary<string, List<int>>();
        }
    }
}
