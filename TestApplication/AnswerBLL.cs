using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
    public class AnswerBLL
    {
        public Boolean addAnswer(BusinessEntities.AnswerBE answer)
        {
            Boolean result;
            DataAccessLayer.AnswerDL addAnswerDL = new DataAccessLayer.AnswerDL();
            result = addAnswerDL.addAnswer(answer);
            return result;
        }
    }
}
