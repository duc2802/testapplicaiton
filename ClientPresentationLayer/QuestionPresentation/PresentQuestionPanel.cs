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
    public partial class PresentQuestionPanel : UserControl
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

        public PresentQuestionPanel()
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

                //AddScroll();

                var questionData = DataItem.ListQuestion[0];
                //CurrentQuestionID = questionData.QuestionID;

                //orderQuestionLabel.Text = (indexQuestionData + 1).ToString();
                textBox1.Text = questionData.QuestionContent;
                var questionItem = new QuestionItem(questionData);
                questionItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Top)));
                questionItem.Location = new Point(0, 0);
                //questionItem.BackColor = Color.Red;
                //AutoScroll = true;
                panel2.Controls.Add(questionItem);
                //indexQuestion = indexQuestionData;
            }
            ResumeLayout();
        }

        private void MyScrollButton_Click(object sender, EventArgs e)
        {
            AutoScrollPosition = new Point(-AutoScrollPosition.X + 64,
                                                     -AutoScrollPosition.Y);
        }

    }
}
