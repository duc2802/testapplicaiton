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
    public partial class QuestionListPanel : UserControl
    {
        public QuestionListPanel()
        {
            InitializeComponent();
            InitGui();
        }

        private void InitGui()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            //Init list from dataItemController.
            questionPanel.SuspendLayout();
            //int[] keys = _dataItemController.TestBook.Keys.ToArray();
            for (int idx = 0; idx < 20; idx++)
            {
                QuestionListItemCustom itemLayout = new QuestionListItemCustom();
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(questionPanel.Width - 20, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                questionPanel.Controls.Add(itemLayout);
            }
            questionPanel.ResumeLayout();
        }
    }
}
