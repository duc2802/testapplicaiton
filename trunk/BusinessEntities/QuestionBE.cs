using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**-----------------------------------------------------------
* Program : TestApplication
* Written by : tiendv 
* Email : tiendo.vn@gmail.com
•	Created date: 4/4/2013 
* Modified by: Nguyen Van B
•	Modified date:
•	Version: 1.0	
•	Description: 
----------------------------------------------------------*/ 

namespace BusinessEntities
{
    public class QuestionBE
    {
        private string _questionId;
        private string _questionContent;
        private List<AnswerBE> _listAnswers;
        private string _levelQuestion;

        public string QuestionID
        {
            get { return _questionId; }
            set { _questionId = value; }
        }

        public String QuestionContent
        {
            get { return _questionContent; }
            set { _questionContent = value; }
        }

        public List<AnswerBE> ListAnswers
        {
            get { return _listAnswers; }
            set { _listAnswers = value; }
        }

        public String LevelQuestion
        {
            get { return _levelQuestion; }
            set { _levelQuestion = value; }
        }


    }
}
