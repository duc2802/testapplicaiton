using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using Commons;
using SingleInstanceObject;

namespace ClientPresentationLayer.QuestionPresentation.Data
{
    public class QuestionDataListViewItem
    {
        public string NumberOrder { set; get; }

        public string Content { set; get; }

        public string TypeQuestion { set; get; }

        public string IdQuestion { set; get; }
        
        public bool Attempted { set; get; }
        
        public bool Marked { set; get; }
        public string Status { set; get; }
        public string Result { set; get; }

        public QuestionDataListViewItem(int index, QuestionBE questionBe)
        {
            NumberOrder = index.ToString();
            Content = HtmlRemove.StripTagsRegex(questionBe.QuestionContent);
            IdQuestion = questionBe.QuestionID;
            TypeQuestion = "Multichoise";
            CheckMarked();
            CheckAttempted();
        }

        private void CheckAttempted()
        {
            Result = "Incorrect";
            Attempted = false;
            var question = Singleton<TestBE>.Instance.ListQuestion.FirstOrDefault(quest => quest.QuestionID == IdQuestion);
            List<int> answerSheet;
            if(Singleton<AnswerSheetDataController>.Instance.AnswerSheet.TryGetValue(IdQuestion, out answerSheet) 
                && question != null)
            {
                foreach (var idx in answerSheet)
                {
                    Attempted = FormatHelper.StringToBoolean(question.ListAnswers[idx].Result);
                    if (Attempted == true)
                    {
                        Result = "Correct";
                    }

                }   
            }
        }

        private void CheckMarked()
        {
            Marked = Singleton<AnswerSheetDataController>.Instance.AnswerSheet.ContainsKey(IdQuestion);
            if (Marked == false)
            {
                Status = "Incompleted";
            }
            else
                Status = "Completed";
        }

        public ListViewItem ConvertToListItem()
        {
            var item = new ListViewItem(Status);
            item.SubItems.Add(NumberOrder);
            item.SubItems.Add(Content);
            item.SubItems.Add(Result);
            item.SubItems.Add(TypeQuestion);
            item.Tag = IdQuestion;
            return item;
        }
    }
}
