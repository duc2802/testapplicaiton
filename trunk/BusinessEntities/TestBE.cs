using System.Collections.Generic;

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
    public class TestBE : IDataBE
    {
        public string TestID { get; set; }

        public string Information { get; set; }

        public string DateCreate { get; set; }

        public List<QuestionBE> ListQuestion { get; set; }

        public string Time { get; set; }
    }
}