using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class AnswerDL
    {
        public Boolean addAnswer (BusinessEntities.AnswerBE addAnswer)
        {
            Boolean result = true;
            // Write answer to file XML ...
            return result;
        }

        public BusinessEntities.AnswerBE getAnswerContent()
        {
            BusinessEntities.AnswerBE result = new BusinessEntities.AnswerBE();
            // Read answer to file XML ...
            return result;
        }


    }
}
