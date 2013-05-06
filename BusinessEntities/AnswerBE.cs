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
    public class AnswerBE
    {
        int answerID;
        Boolean result;
        String content;
        String explain;

        public String Explain
        {
            get { return explain; }
            set { explain = value; }
        }

        public Boolean Result
        {
            get { return result; }
            set { result = value; }
        }

        
   
        public String Content
        {
            get { return content; }
            set { content = value; }
        }
        public int AnswerID
        {
            get { return answerID; }
            set { answerID = value; }
        }


    }
}
