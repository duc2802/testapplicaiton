using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class QuestionDAL
    {
        private String folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private String path = "\\TestEasy\\data\\";
        private String fileData = "Exam.xml";

        public List<BusinessEntities.QuestionBE> getListQuestionFromTestID(string idTest)
        {
            List<BusinessEntities.QuestionBE> result = new List<BusinessEntities.QuestionBE>();
            // Code load Test with id using xml reader
            return result;
        }

        public Boolean EditQuestion(BusinessEntities.QuestionBE question,String testId)
        {
            Boolean result = false;
            result = XmlHelper.EditQuestion(folder + path + fileData, question, testId);
            return result;
        }

        public bool AddQuestion(BusinessEntities.QuestionBE question, string testId)
        {
            Boolean result = false;
            result = XmlHelper.AddQuestion(folder + path + fileData, question, testId);
            return result;
        }
    }
}
