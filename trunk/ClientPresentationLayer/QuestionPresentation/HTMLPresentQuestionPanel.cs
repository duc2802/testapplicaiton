using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class HTMLPresentQuestionPanel : UserControl
    {

        private TestBE _dataItem;
        public TestBE DataItem
        {
            set
            {
                _dataItem = value;
            }
            get { return _dataItem; }
        }

        public HTMLPresentQuestionPanel()
        {
            InitializeComponent();
            FillQuestionDataWithQuestionIndex(1);
        }

        private void AddScroll()
        {
            var scrollBar = new VScrollBar();
            scrollBar.Click += MyScrollButton_Click;
            scrollBar.Dock = DockStyle.Right;
            scrollBar.Scroll += (sender, e) => { HorizontalScroll.Value = scrollBar.Value; };
            Controls.Add(scrollBar);
        }

        public void FillQuestionDataWithQuestionIndex(int indexQuestionData)
        {
            SuspendLayout();
            if (DataItem != null && DataItem.TestID != null)
            {
                // Clear panel
                var list = new ArrayList(panel2.Controls);
                foreach (Control c in list)
                {
                    panel2.Controls.Remove(c);
                }

                var questionData = DataItem.ListQuestion[indexQuestionData];
                textBox1.Text = questionData.QuestionContent;
                var questionItem = new HTMLQuestionItem(questionData, true);
                questionItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Top)));
                questionItem.Location = new Point(0, 0);
                panel2.Controls.Add(questionItem);
            }
            ResumeLayout();
        }

        public void TurnOnAnswer(QuestionItem question)
        {
            
        }

        private void MyScrollButton_Click(object sender, EventArgs e)
        {
            AutoScrollPosition = new Point(-AutoScrollPosition.X + 64,
                                                     -AutoScrollPosition.Y);
        }

    }
}
