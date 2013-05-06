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
    public class TestBE
    {
        int time;
        List<QuestionBE> listQuestion;
        string information;
        string testID;

        public string TestID
        {
            get { return testID; }
            set { testID = value; }
        }

        public string Information
        {
            get { return information; }
            set { information = value; }
        }
        public List<QuestionBE> ListQuestion
        {
            get { return listQuestion; }
            set { listQuestion = value; }
        }
        public int Time
        {
            get { return time; }
            set { time = value; }
        }

    }
}
