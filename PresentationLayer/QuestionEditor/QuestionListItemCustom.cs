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
            
        }

        private void InitCommonGui(QuestionDataItem questionData)
        {
            this.DataItem = questionData;
        }

        private void OnDataItemChanged()
        {
            contentQuestionTextBox.Text = this.DataItem.ContentQuestion;
            this.orderNumQuest.Text = this.DataItem.OrderQuestion.ToString();
            AddAnswerOptions();
            CalculatePanelSize();
        }
        public void CalculatePanelSize()
        {
            this.answerChoiseContainer.Height = this.contentQuestionTextBox.Location.Y + this.contentQuestionTextBox.Height + 10 + (this.DataItem.AnswerData.AnswerData.Count * 20);
        }
        private void ContentQuestionTextBoxChanged(object sender, EventArgs e)
        {
            RefreshContentQuestionTexBox();
        }

        private void AddAnswerOptions()
        {
            int i = 1;
            foreach(AnswerDataItem answerItem in DataItem.AnswerData.AnswerData)
            {
                AddNewLine(answerItem.ContentAnswer, i);
                i++;
            }
        }

        private void AddNewLine(string answerString, int orderNumber)
        {
            Point point = new Point();
            point.Y = this.contentQuestionTextBox.Location.Y + this.contentQuestionTextBox.Height + 10 + ((orderNumber - 1) * 20);
            point.X = this.contentQuestionTextBox.Location.X; 
            CheckBox answerCheckBox = new CheckBox();
            answerCheckBox.AutoSize = true;
            answerCheckBox.Location = point;
            answerCheckBox.Name = "answerCheckBox";
            answerCheckBox.Text = answerString;
            this.answerChoiseContainer.Controls.Add(answerCheckBox);
        }

        public void RefreshContentQuestionTexBox()
        {
            this.SuspendLayout();
            string contentWrap = WrapText(contentQuestionTextBox.Text, contentQuestionTextBox.Width,
                                          contentQuestionTextBox.Font);
            int countNewLine = contentWrap.Split('\n').Count();
            this.contentQuestionTextBox.Height = (countNewLine) * contentQuestionTextBox.Font.Height + (3);
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
    }
}
