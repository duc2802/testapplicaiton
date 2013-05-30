using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace TestApplication
{
    public class QuestionBLL
    {
        public List<BusinessEntities.QuestionBE> getListQuestionFromTestID(string idTest)
        {
            List<BusinessEntities.QuestionBE> result = new List<BusinessEntities.QuestionBE>();
            QuestionDAL qBLL = new QuestionDAL();
            result = qBLL.getListQuestionFromTestID(idTest);
            if (result == null)
                return null;
            return result;
        }
    }
}
