using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using Commons;
using Commons.BusinessObjects;
using Commons.CommonGui;
using LiveSwitch.TextControl;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer;
using PresentationLayer.ActionController;
using PresentationLayer.ThreadManager.GuiThread;
using SingleInstanceObject;
using ThreadQueueManager;
using TextEditor = LiveSwitch.TextControl.Editor;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListItemCustom : UserControl
    {
        #region Trigger Event

        public event ActionEventHandler<QuestionDataItem> Edit
        {
            add
            {
                lock (_editEventLocker)
                {
                    _editEvent += value;
                }
            }
            remove
            {
                lock (_editEventLocker)
                {
                    _editEvent -= value;
                }
            }
        }

        private ActionEventHandler<QuestionDataItem> _editEvent;
        private readonly object _editEventLocker = new object();

        private void OnEdit(QuestionDataItem idQuestion)
        {
            ActionEventHandler<QuestionDataItem> handler = _editEvent;
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

        public event ActionEventHandler<string> Delete
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

        private ActionEventHandler<string> _deleteEvent;
        private readonly object _deleteEventLocker = new object();

        private void OnDelete(string idQuestion)
        {
            ActionEventHandler<string> handler = _deleteEvent;
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

        public event ActionEventHandler<string> Update
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

        private ActionEventHandler<string> _updateEvent;
        private readonly object _updateEventLocker = new object();

        private void OnUpdate(string idQuestion)
        {
            ActionEventHandler<string> handler = _updateEvent;
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

        //private TextEditor _contentQuestionTextEditor;
        private TextEditor _contentQuestionTextEditor;
        
        public QuestionListItemCustom()
        {
            InitializeComponent();
            InitEvent();
        }

        public QuestionListItemCustom(QuestionDataItem question)
        {
            InitializeComponent();
            InitCustomComponent();
            InitCommonGui(question);
            InitEvent();
        }

        public void InitCustomComponent()
        {
            SuspendLayout();
            //Init contentQuestionTextEditor
            _contentQuestionTextEditor = new TextEditor(false);
            //_contentQuestionTextEditor.Dock = DockStyle.Fill;
            //_contentQuestionTextEditor.BorderStyle = BorderStyle.None;
            _contentQuestionTextEditor.Parent = this;
            //_contentQuestionTextEditor.BackColor = SystemColors.Control;
            _contentQuestionTextEditor.BodyBackgroundColor = Color.White;
            _contentQuestionTextEditor.Dock = DockStyle.Fill;
            _contentQuestionTextEditor.EditorBackColor = Color.FromArgb(((((255)))), ((((255)))), ((((255)))));
            _contentQuestionTextEditor.EditorForeColor = Color.FromArgb(((((0)))), ((((0)))), ((((0)))));
            _contentQuestionTextEditor.FontSize = FontSize.Three;
            _contentQuestionTextEditor.Html = null;
            _contentQuestionTextEditor.Name = "_contentQuestionTextEditor";
            //_contentQuestionTextEditor.Size = new Size(632, 124);
            //_contentQuestionTextEditor.TabIndex = 1;
            contentQuestionPanel.Controls.Add(_contentQuestionTextEditor);
            contentQuestionPanel.BorderStyle = BorderStyle.FixedSingle;
            ResumeLayout(true);
            PerformLayout();
        }

        public QuestionDataItem DataItem
        {
            set
            {
                _dataItem = value;
                if (_dataItem.IdQuestion != null)
                {
                    Name = _dataItem.IdQuestion.ToString();
                }
                OnDataItemChanged();
            }
            get { return _dataItem; }
        }

        private void InitEvent()
        {
            //Component Events.
            //contentQuestionPanel.TextChanged += ContentQuestionPanelChanged;
            answerChoiseContainer.Click += AnswerChoiseContainerClick;
            deleteButton.Click += DeleteButtonClick;

            //Container Events.

            Leave += QuestionListItemCustomLeave;
            Click += QuestionListItemCustomClick;
            GotFocus += QuestionListItemCustomClick;
            //Data Event
            
        }

        void DataItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionEventHandler<PropertyChangedEventArgs>(DataItemPropertyChanged), sender, e);
                return;
            }
            if (e.PropertyName.Equals("OrderAnswer"))
            {
                orderNumQuest.Text = DataItem.OrderQuestion.ToString();
            }
        }
        public string ConvertLabelQuestion(int number)
        {
            string result = null;
            switch (number)
            {
                case 1:
                    result = "a";
                    break;
                case 2:
                    result = "b";
                    break;
                case 3:
                    result = "c";
                    break;
                case 4:
                    result = "d";
                    break;
                case 5:
                    result = "e";
                    break;
                case 6:
                    result = "f";
                    break;
            }

            return result;
        }
        
        private void InitCommonGui(QuestionDataItem questionData)
        {
            DataItem = questionData;
            DataItem.PropertyChanged += new Commons.BusinessObjects.PropertyChangedEventHandler(DataItem_PropertyChanged);

            _contentQuestionTextEditor.Html = DataItem.ContentQuestion;
            orderNumQuest.Text = DataItem.OrderQuestion.ToString();
            AddAnswerOptions();
            CalculatePanelSize();
            //DataItem.PropertyChanged += DataItemPropertyChanged;
        }

        private void OnDataItemChanged()
        {
            _contentQuestionTextEditor.Html = DataItem.ContentQuestion;
            orderNumQuest.Text = DataItem.OrderQuestion.ToString();
            AddAnswerOptions();
            CalculatePanelSize();
        }

        public void CalculatePanelSize()
        {
            answerChoiseContainer.Height = contentQuestionPanel.Location.Y + contentQuestionPanel.Height + 10 +
                                           (DataItem.AnswerData.AnswerData.Count*20);
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void AddAnswerOptions()
        {
            answerChoiseContainer.SuspendLayout();
            int i = 1;
            foreach (AnswerDataItem answerItem in DataItem.AnswerData.AnswerData)
            {
                var item =
                    answerChoiseContainer.Controls.Find(answerItem.orderAnswer.ToString(), true).FirstOrDefault() as
                    HTMLAnswerItem;
                if (item != null)
                {
                    item.Name =  answerItem.orderAnswer.ToString();
                    item.DataItem = answerItem;
                }
                else
                {
                    AddNewLine(answerItem, i);
                    i++;
                }
            }
            answerChoiseContainer.ResumeLayout();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerString"></param>
        /// <param name="orderNumber"></param>
        private void AddNewLine(AnswerDataItem answerItem, int orderNumber)
        {
            var point = new Point();
            point.Y = contentQuestionPanel.Location.Y + contentQuestionPanel.Height +10+ ((orderNumber - 1) * 74);
            point.X = contentQuestionPanel.Location.X;
            var answerCheckBox = new HTMLAnswerItem(answerItem, false);
            answerCheckBox.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            answerCheckBox.Name = ConvertLabelQuestion(answerItem.orderAnswer);
            answerCheckBox.AutoSize = true;
            answerCheckBox.Location = point;
            answerChoiseContainer.Controls.Add(answerCheckBox);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshContentQuestionTexBox()
        {
            SuspendLayout();
            string contentWrap = WrapText(contentQuestionPanel.Text, contentQuestionPanel.Width,
                                          contentQuestionPanel.Font);
            int countNewLine = contentWrap.Split('\n').Count();
            contentQuestionPanel.Height = (countNewLine)*contentQuestionPanel.Font.Height + (3);
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

        private void ContentQuestionPanelChanged(object sender, EventArgs e)
        {
            RefreshContentQuestionTexBox();
        }

        private void QuestionListItemCustomClick(object sender, EventArgs e)
        {
            Focus();
            string testId = _dataItem.IdQuestion; //get from item click.
            ICommand command = new LoadQuestionCmd(ExecuteMethod.Async, testId);
            Singleton<GuiQueueThreadController>.Instance.PutCmd(command);
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
            Singleton<GuiActionEventController>.Instance.LeaveQuestion = 1;
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
            HTMLQuestionEditor test = new HTMLQuestionEditor(_dataItem);

            if (DialogResult.OK == test.ShowDialog())
            {
                OnEdit(test.DataItem);
            }

            //MultipleChoiceEditor test = new MultipleChoiceEditor(_dataItem);
            //if(DialogResult.OK == test.ShowDialog())
            //{
            //    OnEdit(test.DataItem);
            //}
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void answerChoiseContainer_Paint(object sender, PaintEventArgs e)
        {
          //  Singleton<GuiActionEventController>.Instance.QuestionId = 1;

        }

        private void answerChoiseContainer_MouseClick(object sender, MouseEventArgs e)
        {
            Singleton<GuiActionEventController>.Instance.QuestionId = 1;
        }
    }
}