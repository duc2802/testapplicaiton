using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;
using Commons.BusinessObjects;
using PresentationLayer.QuestionEditor.Data;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListItemCustom : UserControl
    {
        #region Trigger Event
        public event ActionEventHandler<int> Delete
        {
            add
            {
                lock (_deleteEventLocker)
                {
                    _deleteEvent += value;
                }
            }
            remove
            {
                lock (_deleteEventLocker)
                {
                    _deleteEvent -= value;
                }
            }
        }

        private ActionEventHandler<int> _deleteEvent;
        private readonly object _deleteEventLocker = new object();

        private void OnDelete(int idQuestion)
        {
            ActionEventHandler<int> handler = _deleteEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idQuestion);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        public event ActionEventHandler<int> Update
        {
            add
            {
                lock (_updateEventLocker)
                {
                    _updateEvent += value;
                }
            }
            remove
            {
                lock (_updateEventLocker)
                {
                    _updateEvent -= value;
                }
            }
        }

        private ActionEventHandler<int> _updateEvent;
        private readonly object _updateEventLocker = new object();

        private void OnUpdate(int idQuestion)
        {
            ActionEventHandler<int> handler = _updateEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idQuestion);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion 

        private QuestionDataItem _dataItem;

        public QuestionListItemCustom()
        {
            InitializeComponent();
            InitEvent();
        }

        public QuestionListItemCustom(QuestionDataItem question)
        {
            InitializeComponent();
            InitEvent();
            InitCommonGui(question);
        }

        public QuestionDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.IdQuestion.ToString();
                OnDataItemChanged();
            }
            get { return _dataItem; }
        }

        private void InitEvent()
        {
            //Component Events.
            contentQuestionTextBox.TextChanged += ContentQuestionTextBoxChanged;
            answerChoiseContainer.Click += AnswerChoiseContainerClick;
            deleteButton.Click += DeleteButtonClick;

            //Container Events.
            Leave += QuestionListItemCustomLeave;
            Click += QuestionListItemCustomClick;
            GotFocus += QuestionListItemCustomClick;

            //Data Event
            
        }

        private void InitCommonGui(QuestionDataItem questionData)
        {
            DataItem = questionData;
            DataItem.PropertyChanged += DataItemPropertyChanged;
        }

        private void OnDataItemChanged()
        {
            contentQuestionTextBox.Text = DataItem.ContentQuestion;
            orderNumQuest.Text = DataItem.OrderQuestion.ToString();
            AddAnswerOptions();
            CalculatePanelSize();
        }

        public void CalculatePanelSize()
        {
            answerChoiseContainer.Height = contentQuestionTextBox.Location.Y + contentQuestionTextBox.Height + 10 +
                                           (DataItem.AnswerData.AnswerData.Count*20);
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void AddAnswerOptions()
        {
            int i = 1;
            foreach (AnswerDataItem answerItem in DataItem.AnswerData.AnswerData)
            {
                AddNewLine(answerItem.ContentAnswer, i);
                i++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerString"></param>
        /// <param name="orderNumber"></param>
        private void AddNewLine(string answerString, int orderNumber)
        {
            var point = new Point();
            point.Y = contentQuestionTextBox.Location.Y + contentQuestionTextBox.Height + 10 + ((orderNumber - 1)*20);
            point.X = contentQuestionTextBox.Location.X;
            var answerCheckBox = new CheckBox();
            answerCheckBox.AutoSize = true;
            answerCheckBox.Location = point;
            answerCheckBox.Name = "answerCheckBox";
            answerCheckBox.Text = answerString;
            answerChoiseContainer.Controls.Add(answerCheckBox);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshContentQuestionTexBox()
        {
            SuspendLayout();
            string contentWrap = WrapText(contentQuestionTextBox.Text, contentQuestionTextBox.Width,
                                          contentQuestionTextBox.Font);
            int countNewLine = contentWrap.Split('\n').Count();
            contentQuestionTextBox.Height = (countNewLine)*contentQuestionTextBox.Font.Height + (3);
            ResumeLayout(true);
            PerformLayout();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLineWidth"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public string WrapText(string text, float maxLineWidth, Font font)
        {
            Graphics gfx = CreateGraphics();
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

        #region Implement all of events

        private void ContentQuestionTextBoxChanged(object sender, EventArgs e)
        {
            RefreshContentQuestionTexBox();
        }

        private void QuestionListItemCustomClick(object sender, EventArgs e)
        {
            Focus();
        }

        private void AnswerChoiseContainerClick(object sender, EventArgs e)
        {
            Focus();
            answerChoiseContainer.BorderStyle = BorderStyle.FixedSingle;
            answerChoiseContainer.Focus();
        }

        private void QuestionListItemCustomLeave(object sender, EventArgs e)
        {
            answerChoiseContainer.BorderStyle = BorderStyle.None;
            Refresh();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Do you want to delete this question?", "Delete question.",
                                         MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                OnDelete(this.DataItem.IdQuestion);
            }
        }

        private void DataItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionEventHandler<PropertyChangedEventArgs>(DataItemPropertyChanged), sender, e);
                return;
            }
            if (e.PropertyName.Equals("OrderQuestion"))
            {
                orderNumQuest.Text = DataItem.OrderQuestion.ToString();
            }
            else if(true)
            {
                
            }
            OnUpdate(DataItem.IdQuestion);
        }
        #endregion

        private void editButton_Click(object sender, EventArgs e)
        {
            MultipleChoiceEditor test = new MultipleChoiceEditor(_dataItem);
            test.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}