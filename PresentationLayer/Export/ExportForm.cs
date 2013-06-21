using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using PresentationLayer.QuestionEditor.Data;

namespace PresentationLayer.Export
{
    public partial class ExportForm : Form
    {
        private int _testId;

        public ExportForm()
        {
            InitializeComponent();
            InitGui();
            InitEvent();
        }

        public ExportForm(int testId)
        {
            this._testId = testId;
            InitializeComponent();
            InitGui();
            InitEvent();
        }

        private void InitGui()
        {
            //Temporary Init GUI
            tbTestName.Text = @"De thi " + _testId.ToString() + @" Test";
        }

        private void InitEvent()
        {
           btExport.Click +=BtExportOnClick;
        }

        private void BtExportOnClick(object sender, EventArgs eventArgs)
        {
            String path = "";
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowser.SelectedPath;
            }

            // create MS-Word application 
            Microsoft.Office.Interop.Word.Application msWord = new Microsoft.Office.Interop.Word.Application();            
            Microsoft.Office.Interop.Word.Document doc = null;
            object objMiss = System.Reflection.Missing.Value;

            try
            {                
                // add blank documnet in word application
                doc = msWord.Documents.Add(ref objMiss, ref objMiss, ref objMiss, ref objMiss);
                // create para
                HeaderPara(doc, objMiss);
                InfoPara(doc, objMiss);
                ContentPara(doc, objMiss);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            if (doc != null) 
            doc.SaveAs(path + "\\" + tbTestName.Text + ".doc");
            MessageBox.Show(@"Export Successfully");
            msWord.Quit();
            this.Close();
        }       

        private void HeaderPara(Document doc, object objMiss)
        {

            Microsoft.Office.Interop.Word.Paragraph headerPara;
            headerPara = doc.Content.Paragraphs.Add(ref objMiss);
            object styleHeading1 = "Heading 1";
            headerPara.Range.set_Style(ref styleHeading1);
            headerPara.Range.Text = Indent(50)+tbTestName.Text;
            headerPara.Range.Font.Bold = 1;
            headerPara.Format.SpaceAfter = 10;            
            headerPara.Range.InsertParagraphAfter();
        }

        private void InfoPara(Document doc, object objMiss)
        {
            Microsoft.Office.Interop.Word.Paragraph infoPara;
            infoPara = doc.Content.Paragraphs.Add(ref objMiss);
            object styleHeading2 = "Heading 2";
            infoPara.Range.set_Style(ref styleHeading2);
            String content = "Time : 30 minutes" + "\n";
            content += "Number of Question : 10" + "\n";
            content += "Date : " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            infoPara.Range.Text = content;
            infoPara.Range.Font.Bold = 1;
            infoPara.Format.SpaceAfter = 10;
            infoPara.Format.RightIndent = 5;
            infoPara.Range.InsertParagraphAfter();
        }

        private void ContentPara(Document doc, object objMiss)
        {
            var controller = new QuestionDataController();
            controller.CreateDataForTest();
            List<QuestionDataItem> dataItems = controller.DataItems;


            for (int i = 0; i < dataItems.Count; i++)
            {
                QuestionDataItem item = dataItems[i];
                var paragraph = doc.Content.Paragraphs.Add(ref objMiss);
                String question = (i + 1).ToString() + "/ " + item.ContentQuestion + "\n";
                foreach (AnswerDataItem a in item.AnswerData.AnswerData)
                {
                    
                    if (a.isTrue && ckResult.Checked == true)
                    {
                        question += Indent(5) + a.OrderAnswer + "." + a.ContentAnswer + " \u221A" + "\n";
                    }
                    else
                    {
                        question += Indent(5) + a.OrderAnswer + "." + a.ContentAnswer + "\n";
                    }
                }
                paragraph.Range.Text += question;
                paragraph.Range.Font.Bold = 0;
                paragraph.Range.Font.Size = 12;
                paragraph.Range.InsertParagraphAfter();
            }
        }

        private static string Indent(int count)
        {
            return "".PadLeft(count);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
