using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

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

        public List<AnswerBE> getListAnswerFromQuestionID(string idQuestion)
        {
            List<AnswerBE> result = new List<AnswerBE>();
            AnswerDAL asDAL = new AnswerDAL();
            result= asDAL.getListAnswerFromQuestionID(idQuestion);
            if (result == null)
                return null;
            return result;
        }
        
    }
}
