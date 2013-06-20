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
    public class AnswerBE
    {
        string answerID;
        string result;
        string content;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public string AnswerID
        {
            get { return answerID; }
            set { answerID = value; }
        }

        public String Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
