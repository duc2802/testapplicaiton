﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace DataAccessLayer
{
    public class AnswerDAL
    {
        public Boolean AddAnswer (BusinessEntities.AnswerBE addAnswer)
        {
            Boolean result = true;
            // Write answer to file XML ...
            return result;
        }

        public BusinessEntities.AnswerBE GetAnswerContent()
        {
            BusinessEntities.AnswerBE result = new BusinessEntities.AnswerBE();
            // Read answer to file XML ...
            return result;
        }

        public List<AnswerBE> getListAnswerFromQuestionID(string idquestion)
        {
            List<AnswerBE> result = new List<AnswerBE>();
            //Read question return list answer.
            return result;
        }


    }
}
