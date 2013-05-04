using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
    public class AnswerBLL
    {
        public Boolean AddAnswer(BusinessEntities.AnswerBE answer)
        {
            Boolean result;
            DataAccessLayer.AnswerDAL addAnswerDL = new DataAccessLayer.AnswerDAL();
            result = addAnswerDL.AddAnswer(answer);
            return result;
        }
    }
}
