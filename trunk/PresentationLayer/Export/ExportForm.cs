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

            Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
            var oDoc = oWord.Documents.Add(Missing.Value, Missing.Value);

            //Insert a paragraph at the beginning of the document.
            var paragraphTitle = oDoc.Content.Paragraphs.Add(Missing.Value);                        
            paragraphTitle.Range.Font.Bold = 1;
            paragraphTitle.Range.Font.Size = 20;
            paragraphTitle.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            String content = tbTestName.Text + "\n";            
            content += "Time : 30 minutes" + "\n";
            content += "Number of Question : 10" + "\n";
            content += "Date : " +DateTime.Now.Day +"/"+DateTime.Now.Month+"/"+DateTime.Now.Year + "\n";
            paragraphTitle.Range.Text = content; 
            paragraphTitle.Range.InsertParagraphAfter();

            var controller = new QuestionDataController();
            controller.CreateDataForTest();
            List<QuestionDataItem> dataItems = controller.DataItems;

          
            for (int i = 0; i < dataItems.Count; i++)
            {
                QuestionDataItem item = dataItems[i];
                var paragraph = oDoc.Content.Paragraphs.Add(Missing.Value);
                String question = (i+1).ToString() + "/ " + item.ContentQuestion +"\n";
                foreach (AnswerDataItem a in item.AnswerData.AnswerData)
                {
                    paragraphTitle.Format.LineSpacing = 23;
                    if(a.isTrue && ckResult.Checked == true){
                        question += a.OrderAnswer + "." + a.ContentAnswer +" \u221A"+"\n";
                    }
                    else
                    {
                        question += a.OrderAnswer + "." + a.ContentAnswer + "\n";
                    }
                }
                paragraph.Range.Text += question;
                paragraph.Range.Font.Bold = 0;
                paragraph.Range.Font.Size = 12;
                paragraph.Format.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                paragraph.Range.InsertParagraphAfter();
            }

            oDoc.SaveAs(path + "\\" + tbTestName.Text + ".doc");

            oWord.Quit();
        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
