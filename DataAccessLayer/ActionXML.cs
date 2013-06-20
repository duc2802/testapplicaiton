using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using BusinessEntities;

namespace DataAccessLayer
{
    public class ActionXML
    {
        public static XElement buildQuestionTree(BusinessEntities.TestBE test)
        {


            XElement treeQuestion = new XElement("listquestions",
                                                 from question in test.ListQuestion
                                                 select
                                                     new XElement("question",
                                                     new XAttribute("id", question.QuestionID),
                                                     new XElement(buildAnswerTree(question)),
                                                     new XElement("content",question.QuestionContent),
                                                     new XElement("explain", question.Explain),
                                                     new XElement("level",question.LevelQuestion )));

            return treeQuestion;
        }

        public static XElement buildAnswerTree(BusinessEntities.QuestionBE question)
        {
            XElement treeAnswer = new XElement("listanswers",
                                                 from answer in question.ListAnswers
                                                 select new XElement ("answer",
                                                     new XAttribute ("id",answer.AnswerID),
                                                     new XElement("answerContent", answer.Content),
                                                     new XElement("result", answer.Result)));
            return treeAnswer;
        }


        public static Boolean saveExam(BusinessEntities.TestBE test, String placeToSave, String nameofFile)
        {
            Boolean result = true;
            XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This is content of Exam that you input"),
            new XElement("exam",
                new XAttribute("id", test.TestID),
                new XElement(buildQuestionTree(test)),
                new XElement("infomation", test.Information)));

            String placeSave = placeToSave + "\\" + nameofFile + ".xml";
            doc.Save(@placeToSave);
            return result;
        }

        public static List<BusinessEntities.TestBE> loadExam (String addressXMLFile)
        {
            XDocument testXML = XDocument.Load(@addressXMLFile);

            // Load list answer
            List<BusinessEntities.TestBE> test = (from t in testXML.Descendants("exam")
                                                  select new BusinessEntities.TestBE {
                                                          TestID = t.Attribute("id").Value,
                                                          Information = t.Element("information").Value,
                                                          ListQuestion = (from q in t.Descendants("question")
                                                                      select new BusinessEntities.QuestionBE
                                                                      {
                                                                          LevelQuestion = q.Element("level").Value,
                                                                          QuestionContent =q.Element("content").Value,
                                                                          QuestionID =q.Attribute("id").Value,
                                                                          Explain = q.Attribute("explain").Value,

                                                                          //Load list answer of question

                                                                          ListAnswers = (from r in q.Descendants("answer")
                                                                                           select new BusinessEntities.AnswerBE
                                                                                           {
                                                                                               AnswerID = r.Attribute("id").Value,
                                                                                               Content = r.Element("answerContent").Value,                                                                                               
                                                                                               Result = r.Element("result").Value

                                                                                           }).ToList() 

                                                                      }).ToList()
                                                          }).ToList();
            return test;
        }


        public static Boolean EditQuestion(string addressXMLFile, QuestionBE question, String testId)
        {
            XDocument doc = XDocument.Load(@addressXMLFile);

            foreach (var exam in doc.Descendants("Exam"))
            {
                var xAttribute = exam.Attribute("id");
                if (xAttribute != null)
                {
                    var id = xAttribute.Value;
                    if(id == testId)
                    {
                        foreach (var q in exam.Descendants("question"))
                        {
                            var attribute = q.Attribute("id");
                            if (attribute != null)
                            {
                                var qId = attribute.Value;
                                if(qId == question.QuestionID)
                                {
                                    q.RemoveNodes();
                                    q.ReplaceAll(new XElement("question",
                                                     new XAttribute("id", question.QuestionID),
                                                     new XElement(buildAnswerTree(question)),
                                                     new XElement("content",question.QuestionContent),
                                                     new XElement("level",question.LevelQuestion )));
                                    doc.Save(@addressXMLFile);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
