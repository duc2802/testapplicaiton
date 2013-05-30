using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListItemCustom : UserControl
    {
        public QuestionListItemCustom()
        {
            InitializeComponent();
            InitEvent();
            InitCommonGui();
        }
        public QuestionListItemCustom(QuestionBE qs)
        {
            InitializeComponent();
            InitEvent();
            InitCommonGui();
        }

        private void InitEvent()
        {
            
        }
        private void InitCommonGui() 
        {
            //For test
            this.numberQuestionLabel.Text = "B";
            this.tbQuestionContent.Text = " Nội dung câu hỏi";
            //Load for answer content
            tbListAnswer.SuspendLayout();
            for (int idx = 0; idx < 4; idx++)
            {
                AnswerItem itemLayout = new AnswerItem("Test","test","test");
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                tbListAnswer.Controls.Add(itemLayout);
            }
            tbListAnswer.ResumeLayout();
        }

        private void InitCommonGui(QuestionBE qs)
        {
            if(qs != null)
            {
                //Load question infomation
                this.numberQuestionLabel.Text = qs.QuestionID;
                this.tbQuestionContent.Text = qs.QuestionContent;
                //Load answer of question
                if(qs.ListAnswers!=null)
                {
                    tbListAnswer.SuspendLayout();
                    for (int idx = 0; idx <qs.ListAnswers.Count; idx++)
                    {
                        AnswerItem itemLayout = new AnswerItem(qs.ListAnswers[idx].AnswerID, qs.ListAnswers[idx].Result, qs.ListAnswers[idx].Content);
                        itemLayout.Location = new Point(0, idx * itemLayout.Height);
                        itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                        itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                        tbListAnswer.Controls.Add(itemLayout);
                    }
                    tbListAnswer.ResumeLayout();
                }
            }
        }

        private void tbListAnswer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
