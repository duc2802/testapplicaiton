using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer.QuestionEditor
{
    public partial class MultipleChoiceEditor : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MultipleChoiceEditor()
        {
            InitializeComponent();
            InitCommonGui();
        }
        private void InitCommonGui()
        {
            //Load for answer content
            tbListAnswer.SuspendLayout();
            for (int idx = 0; idx < 5; idx++)
            {
                AnswerItem itemLayout = new AnswerItem("Test", "test", "test");
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                tbListAnswer.Controls.Add(itemLayout);
            }
            tbListAnswer.ResumeLayout();
        }

        private void tbQuestionContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
