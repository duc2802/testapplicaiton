using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SingleInstanceObject;
using PresentationLayer.ActionController;
using PresentationLayer.Explorer;
using PresentationLayer.QuestionEditor;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.ExamEditor;

namespace PresentationLayer.ExamEditor
{
    public partial class NewExam : Form
    {
        public NewExam()
        {
            InitializeComponent();
            InitEvent();
        }
        public void InitEvent() 
        {
            btCancel.Click += CancelNewExamButtonClick;
            btCreateExam.Click += CreateNewExamButtonClick;
        }

        private void CancelNewExamButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CreateNewExamButtonClick(object sender, EventArgs e)
        {
            TestDataItem dataItem = new TestDataItem();
            dataItem.IdTest = 0;
            dataItem.Name = tbNameExam.Text;
            dataItem.Time = Int32.Parse(tbTime.Text);
            dataItem.DateCreate = DateTime.Now;
            Singleton<GuiActionEventController>.Instance.OnAddExamItem(dataItem);
            }
        }
    
}
