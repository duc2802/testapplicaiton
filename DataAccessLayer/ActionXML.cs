using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
namespace DataAccessLayer
{
    class ActionXML
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
                                                     new XElement("answerContent",answer.Content),
                                                     new XElement("result", answer.Result),
                                                     new XElement("Explain", answer.Explain)));
            return treeAnswer;
        }


        public static Boolean saveExam(BusinessEntities.TestBE test)
        {

            /*
            XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This is content of Exam that you input"),
            new XElement("exam", 
                new XAttribute("id", "1"),
                new XElement ("listquestion",
                    new XElement("question",
                        new XAttribute("id", "1"),
                    new XElement("content", "content of question"),
                    new XElement("listanswers", 
                        new XElement("answer",
                             new XAttribute("id", "1"),
                        new XElement("answerContent", "Content of answer a"),
                        new XElement("result", "0"),
                        new XElement("Explain", "Explain the reson"))),
                    new XElement("level", "level of question"))),
                new XElement("infomation","infomation of exam")
                )
             );
             */
            Boolean result = true;
            XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This is content of Exam that you input"),
            new XElement("exam",
                new XAttribute("id", test.TestID),
                new XElement(buildQuestionTree(test)),
                new XElement("infomation", test.Information)));


            return result;
        }

    }
}
