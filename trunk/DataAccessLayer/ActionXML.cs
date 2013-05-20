using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
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
                                                     new XElement("result", answer.Result),
                                                     new XElement("explain", answer.Explain)));
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

                                                                          //Load list answer of question

                                                                          ListAnswers = (from r in q.Descendants("answer")
                                                                                           select new BusinessEntities.AnswerBE
                                                                                           {
                                                                                               AnswerID = r.Attribute("id").Value,
                                                                                               Content = r.Element("answerContent").Value,
                                                                                               Explain = r.Element("explain").Value,
                                                                                               Result = r.Element("result").Value

                                                                                           }).ToList() 

                                                                      }).ToList()
                                                          }).ToList();
            return test;
        }
       

    }
}
