﻿using System;
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
        string questionID;
        string questionContent;
        List<AnswerBE> listAnswers;
        string levelQuestion;

        public string QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }

        public String QuestionContent
        {
            get { return questionContent; }
            set { questionContent = value; }
        }

        public List<AnswerBE> ListAnswers
        {
            get { return listAnswers; }
            set { listAnswers = value; }
        }

        public String LevelQuestion
        {
            get { return levelQuestion; }
            set { levelQuestion = value; }
        }


    }
}