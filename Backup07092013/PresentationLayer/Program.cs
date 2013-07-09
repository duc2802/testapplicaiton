using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PresentationLayer.MainForm());
           
            /*
             * 
             * tiendv test save xml using linq to xml
            List<BusinessEntities.AnswerBE> la = new List<BusinessEntities.AnswerBE>();
            List<BusinessEntities.QuestionBE> lq = new List<BusinessEntities.QuestionBE>();

            BusinessEntities.AnswerBE ans = new BusinessEntities.AnswerBE();
            ans.AnswerID = 2;
            ans.Content = "content ans";
            ans.Explain = "Explain";
            ans.Result = true;
            la.Add(ans);
            BusinessEntities.QuestionBE qs = new BusinessEntities.QuestionBE();
            qs.ListAnswers = la;
            qs.LevelQuestion = "c";
            qs.QuestionContent = "content question";
            qs.QuestionID = 5;
            lq.Add(qs);
            BusinessEntities.TestBE t = new BusinessEntities.TestBE();
            t.ListQuestion = lq;
            t.TestID = "4";


            bool test = DataAccessLayer.ActionXML.saveExam(t);

             */
        }
    }
}
