using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using PresentationLayer.QuestionEditor.Data;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListItemCustom : UserControl
    {
        private QuestionDataItem _dataItem;

        public QuestionDataItem DataItem
        {
            set
            {
                this._dataItem = value;
                OnDataItemChanged();
            }
            get { return this._dataItem; }
        }

        public QuestionListItemCustom()
        {
            InitializeComponent();
            InitCommonGui();
            InitEvent();
        }

        public QuestionListItemCustom(QuestionDataItem question)
        {
            InitializeComponent();
            InitEvent();
            InitCommonGui(question);
        }

        private void InitEvent()
        {
            this.contentQuestionTextBox.TextChanged += ContentQuestionTextBoxChanged;
        }

        private void InitCommonGui()
        {
            //this._dataItem = new QuestionDataItem();
            ////For test
            //this.numberQuestionLabel.Text = "B";
            //this.contentQuestionTextBox.Text = " Nội dung câu hỏi";
            ////Load for answer content
            //tbListAnswer.SuspendLayout();
            //for (int idx = 0; idx < 6; idx++)
            //{
            //    AnswerItem itemLayout = new AnswerItem("Test", "test", "test");
            //    itemLayout.Location = new Point(10, idx*itemLayout.Height);
            //    itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
            //    itemLayout.Anchor = ((AnchorStyles) ((AnchorStyles.Left | AnchorStyles.Right)));
            //    tbListAnswer.Controls.Add(itemLayout);
            //}
            answerChoiseContainer.ResumeLayout();
        }

        private void InitCommonGui(QuestionDataItem questionData)
        {
            this.DataItem = questionData;
        }

        private void OnDataItemChanged()
        {
            contentQuestionTextBox.Text = this.DataItem.ContentQuestion;
        }
        
        private void ContentQuestionTextBoxChanged(object sender, EventArgs e)
        {
            RefreshContentQuestionTexBox(this.Width);
        }

        public void RefreshContentQuestionTexBox(int width)
        {
            this.SuspendLayout();
            string contentWrap = WrapText(contentQuestionTextBox.Text, width,
                                          contentQuestionTextBox.Font);
            int countNewLine = contentWrap.Split('\n').Count();
            //contentQuestionTextBox.Height = (countNewLine) * contentQuestionTextBox.Font.Height + 3;
            //contentQuestionTextBox.Width = width;
            //this.contentQuestionTextBox.Location = new System.Drawing.Point(26, 35);
            //this.Size = new System.Drawing.Size(506, contentQuestionTextBox.Height);
            this.contentQuestionTextBox.Refresh();
            this.ResumeLayout(true);
            this.PerformLayout();
        }

        public string WrapText(string text, float maxLineWidth, Font font)
        {
            Graphics gfx = this.CreateGraphics();
            string[] words = text.Split(' ');
            var sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = gfx.MeasureString(" ", font).Width;

            foreach (string word in words)
            {
                SizeF size = gfx.MeasureString(word, font);

                if (lineWidth + size.Width < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.Width + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.Width + spaceWidth;
                }
            }
            return sb.ToString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //RefreshContentQuestionTexBox(this.Width);
        }
    }
}
