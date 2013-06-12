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
            //InitializeComponent();
            InitComponentCustom(question.OrderQuestion * 100);
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
            this.orderNumQuest.Text = this.DataItem.OrderQuestion.ToString();
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
            contentQuestionTextBox.Height = (countNewLine) * contentQuestionTextBox.Font.Height + 3;
            contentQuestionTextBox.Width = width;
            this.contentQuestionTextBox.Location = new System.Drawing.Point(26, 35);
            this.Size = new System.Drawing.Size(506, contentQuestionTextBox.Height);
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

        public void InitComponentCustom(int height)
        {
            this.contentQuestionTextBox = new System.Windows.Forms.TextBox();
            this.answerChoiseContainer = new System.Windows.Forms.Panel();
            this.orderNumQuest = new System.Windows.Forms.Label();
            this.answerChoiseContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentQuestionTextBox
            // 
            this.contentQuestionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentQuestionTextBox.BackColor = System.Drawing.Color.White;
            this.contentQuestionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentQuestionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentQuestionTextBox.Location = new System.Drawing.Point(26, 39);
            this.contentQuestionTextBox.Multiline = true;
            this.contentQuestionTextBox.Name = "contentQuestionTextBox";
            this.contentQuestionTextBox.ReadOnly = true;
            this.contentQuestionTextBox.Size = new System.Drawing.Size(454, 81);
            this.contentQuestionTextBox.TabIndex = 1;
            // 
            // answerChoiseContainer
            // 
            this.answerChoiseContainer.AutoSize = true;
            this.answerChoiseContainer.Controls.Add(this.orderNumQuest);
            this.answerChoiseContainer.Controls.Add(this.contentQuestionTextBox);
            this.answerChoiseContainer.Location = new System.Drawing.Point(0, 0);
            this.answerChoiseContainer.Name = "answerChoiseContainer";
            this.answerChoiseContainer.Size = new System.Drawing.Size(503, 157);
            this.answerChoiseContainer.TabIndex = 1;
            // 
            // orderNumQuest
            // 
            this.orderNumQuest.AutoSize = true;
            this.orderNumQuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderNumQuest.Location = new System.Drawing.Point(26, 17);
            this.orderNumQuest.Name = "orderNumQuest";
            this.orderNumQuest.Size = new System.Drawing.Size(21, 15);
            this.orderNumQuest.TabIndex = 2;
            this.orderNumQuest.Text = "15";
            // 
            // QuestionListItemCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.answerChoiseContainer);
            this.Name = "QuestionListItemCustom";
            this.Size = new System.Drawing.Size(506, height);
            this.answerChoiseContainer.ResumeLayout(false);
            this.answerChoiseContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
