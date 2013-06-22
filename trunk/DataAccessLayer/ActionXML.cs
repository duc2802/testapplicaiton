using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessEntities;

namespace DataAccessLayer
{
    public class ActionXML
    {
        public static XElement buildQuestionTree(TestBE test)
        {
            var treeQuestion = new XElement("listquestions",
                                            from question in test.ListQuestion
                                            select
                                                new XElement("question",
                                                             new XAttribute("id", question.QuestionID),
                                                             new XElement("content", question.QuestionContent),
                                                             new XElement(buildAnswerTree(question)),
                                                             new XElement("explain", question.Explain),
                                                             new XElement("level", question.LevelQuestion)));

            return treeQuestion;
        }

        public static XElement buildQuestion(QuestionBE q, String id)
        {
            var question = new XElement("question",
                                        new XAttribute("id", id),
                                        new XElement(buildAnswerTree(q)),
                                        new XElement("content", q.QuestionContent),
                                        new XElement("explain", q.Explain),
                                        new XElement("level", q.LevelQuestion));

            return question;
        }

        public static XElement buildAnswerTree(QuestionBE question)
        {
            var treeAnswer = new XElement("listanswers",
                                          from answer in question.ListAnswers
                                          select new XElement("answer",
                                                              new XAttribute("id", answer.AnswerID),
                                                              new XElement("answerContent", answer.Content),
                                                              new XElement("result", answer.Result)));
            return treeAnswer;
        }


        public static Boolean SaveExam(TestBE test, String placeToSave, String nameofFile)
        {
            var result = true;
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("This is content of Exam that you input"),
                new XElement("exam",
                             new XAttribute("id", test.TestID),
                             new XElement(buildQuestionTree(test)),
                             new XElement("infomation", test.Information)));

            string placeSave = placeToSave + "\\" + nameofFile + ".xml";
            doc.Save(@placeToSave);
            return result;
        }

        public static List<TestBE> loadExam(String addressXMLFile)
        {
            XDocument testXML = XDocument.Load(@addressXMLFile);

            // Load list answer
            List<TestBE> test = (from t in testXML.Descendants("exam")
                                 select new TestBE
                                            {
                                                TestID = t.Attribute("id").Value,
                                                Information = t.Element("information").Value,
                                                ListQuestion = (from q in t.Descendants("question")
                                                                select new QuestionBE
                                                                           {
                                                                               LevelQuestion = q.Element("level").Value,
                                                                               QuestionContent =
                                                                                   q.Element("content").Value,
                                                                               QuestionID = q.Attribute("id").Value,
                                                                               Explain = q.Attribute("explain").Value,

                                                                               //Load list answer of question

                                                                               ListAnswers =
                                                                                   (from r in q.Descendants("answer")
                                                                                    select new AnswerBE
                                                                                               {
                                                                                                   AnswerID =
                                                                                                       r.Attribute("id")
                                                                                                       .Value,
                                                                                                   Content =
                                                                                                       r.Element(
                                                                                                           "answerContent")
                                                                                                       .Value,
                                                                                                   Result =
                                                                                                       r.Element(
                                                                                                           "result").
                                                                                                       Value
                                                                                               }).ToList()
                                                                           }).ToList()
                                            }).ToList();
            return test;
        }


        public static Boolean EditQuestion(string addressXMLFile, QuestionBE question, String testId)
        {
            XDocument doc = XDocument.Load(@addressXMLFile);

            XElement testXML =
                (from t in doc.Descendants("exam") where t.Attribute("id").Value == testId select t).First();
            if (testXML == null) return false;
            XElement questionXML =
                (from q in doc.Descendants("question") where q.Attribute("id").Value == question.QuestionID select q).
                    First();
            if (questionXML == null) return false;
            questionXML.SetElementValue("content", question.QuestionContent);
            questionXML.Element("listanswers").RemoveNodes();
            questionXML.Element("listanswers").Add(buildAnswerTree(question));
            questionXML.SetElementValue("explain", question.Explain);
            doc.Save(@addressXMLFile);
            return true;
        }

        public static Boolean AddQuestion(string addressXMLFile, QuestionBE question, String testId)
        {
            XDocument doc = XDocument.Load(@addressXMLFile);

            XElement testXML =
                (from t in doc.Descendants("exam") where t.Attribute("id").Value == testId select t).First();
            if (testXML == null) return false;

            String id = autoCreateID();
            testXML.Element("listquestions").Add(buildQuestion(question, id));

            doc.Save(@addressXMLFile);
            return true;
        }

        // Create ID with DateTime : Day/month/year/hours/minutes/second
        private static string autoCreateID()
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +
                   DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        }
    }
}