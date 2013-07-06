using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using Commons.BusinessObjects;
using SingleInstanceObject;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionExplainPanel : UserControl
    {
        private PresentQuestionPanel _questionPresent;

        public QuestionExplainPanel()
        {
            InitializeComponent();
            InitEvent();
            InitGui();
        }

        void InitGui() 
        {
            _questionPresent = new PresentQuestionPanel();
            //_questionPresent.Dock = DockStyle.Fill;
            //_questionPresent.AutoScroll = true;
            _questionPresent.DataItem = Singleton<TestBE>.Instance;
            splitContainer.Panel1.Controls.Add(_questionPresent);
        }

        private void InitEvent()
        {
            
        }

        public void RefreshGui()
        {
            SuspendLayout();
            _questionPresent.DataItem = Singleton<TestBE>.Instance;
            _questionPresent.FillQuestionDataWithQuestionIndex(1);
            ResumeLayout();
        }

        private void EndExamButtonClick(object sender, EventArgs e)
        {
            //OnEndExam();
        }
    }
}
