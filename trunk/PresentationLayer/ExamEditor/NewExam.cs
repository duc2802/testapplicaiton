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
            InitGui();
            InitEvent();
        }


        public void InitGui()
        {
            tbNumberQuestion.Focus();
            btCreateExam.Hide();
        }

        public void InitEvent() 
        {
            btCancel.Click += CancelNewExamButtonClick;
            btCreateExam.Click += CreateNewExamButtonClick;
            tbNumberQuestion.KeyPress += tb_KeyPress;
        }

        private void CancelNewExamButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CreateNewExamButtonClick(object sender, EventArgs e)
        {
            TestDataItem dataItem = new TestDataItem();
            dataItem.IdTest = 0;
            dataItem.NumberQuestion = Int32.Parse(tbNumberQuestion.Text);
            dataItem.Name = tbNameExam.Text;
            dataItem.Time = Int32.Parse(tbTime.Text);
            dataItem.DateCreate = DateTime.Now;
            Singleton<GuiActionEventController>.Instance.OnAddTestItem(dataItem);
            }

        private void tbNameExam_TextChanged(object sender, EventArgs e)
        {
            btCreateExam.Show();

        }
    }
  
}
