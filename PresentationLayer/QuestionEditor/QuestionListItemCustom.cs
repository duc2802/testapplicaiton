using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private void InitEvent()
        {
            
        }
        private void InitCommonGui() 
        {
            tbListAnswer.SuspendLayout();
            for (int idx = 0; idx < 4; idx++)
            {
                AnswerItem itemLayout = new AnswerItem();
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                tbListAnswer.Controls.Add(itemLayout);
            }
            tbListAnswer.ResumeLayout();
        }

        private void tbListAnswer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
