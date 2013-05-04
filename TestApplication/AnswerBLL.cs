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
            DataAccessLayer.AnswerDAL addAnswerDL = new DataAccessLayer.AnswerDAL();
            result = addAnswerDL.addAnswer(answer);
            return result;
        }
    }
}
