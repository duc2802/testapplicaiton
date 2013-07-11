using System;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Commons;
using Editor;
using LiveSwitch.TextControl;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.ThreadManager.GuiThread;
using SingleInstanceObject;
using ThreadQueueManager;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SystemColors = System.Drawing.SystemColors;
using TextEditor = LiveSwitch.TextControl.Editor;

namespace PresentationLayer.QuestionEditor
{
    public partial class HTMLQuestionEditor : Form
    {
        private TextEditor _contentQuestionTextEditor;
        private TextEditor _explainQuestionTextEditor;
        private readonly String _action = "";
        private int _maxShowItem = 6;

        private string _pathForderImage = Singleton<SettingManager>.Instance.GetImageFolder();

        private QuestionDataItem _dataItem;
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

        public HTMLQuestionEditor()
        {
            _action = "create";
            InitializeComponent();
            InitCustomComponent();
            InitData();
            InitDefaultGui();
            InitEvent();
        }

        private void InitData()
        {
            _dataItem = new QuestionDataItem();
        }

        public void InitEvent()
        {
            moreAnswerButton.Click += MoreAnswerButtonClick;
            createButton.Click += CreateButtonClick;
            insertEquaButton.Click += new EventHandler(InsertEquaButtonClick);
        }

        private void InsertEquaButtonClick(object sender, EventArgs e)
        {
            var openEquaForm = new OpenMathEditor(ExecuteMethod.Async);
            Singleton<GuiQueueThreadController>.Instance.PutCmd(openEquaForm);
        }

        private void InitCustomComponent()
        {
            createButton.Text = @"Create";

            SuspendLayout();
            //Init contentQuestionTextEditor
            _contentQuestionTextEditor = new TextEditor();
            _contentQuestionTextEditor.BackColor = SystemColors.Control;
            _contentQuestionTextEditor.BodyBackgroundColor = Color.White;
            _contentQuestionTextEditor.Parent = this;
            _contentQuestionTextEditor.BodyHtml = null;
            _contentQuestionTextEditor.BodyText = null;
            _contentQuestionTextEditor.Dock = DockStyle.Fill;
            _contentQuestionTextEditor.EditorBackColor = Color.FromArgb(((((255)))), ((((255)))), ((((255)))));
            _contentQuestionTextEditor.EditorForeColor = Color.FromArgb(((((0)))), ((((0)))), ((((0)))));
            _contentQuestionTextEditor.FontSize = FontSize.Three;
            _contentQuestionTextEditor.Html = null;
            _contentQuestionTextEditor.Name = "_contentQuestionTextEditor";
            _contentQuestionTextEditor.Size = new Size(632, 124);
            _contentQuestionTextEditor.TabIndex = 1;
            contentQuestionPanel.Controls.Add(_contentQuestionTextEditor);

            //Init explainQuestionTextEditor
            _explainQuestionTextEditor = new TextEditor();
            _explainQuestionTextEditor.Dock = DockStyle.Fill;
            _explainQuestionTextEditor.Parent = this;
            _explainQuestionTextEditor.BackColor = SystemColors.Control;
            _explainQuestionTextEditor.BodyBackgroundColor = Color.White;
            _explainQuestionTextEditor.BodyHtml = null;
            _explainQuestionTextEditor.BodyText = null;
            _explainQuestionTextEditor.Dock = DockStyle.Fill;
            _explainQuestionTextEditor.EditorBackColor = Color.FromArgb(((((255)))), ((((255)))), ((((255)))));
            _explainQuestionTextEditor.EditorForeColor = Color.FromArgb(((((0)))), ((((0)))), ((((0)))));
            _explainQuestionTextEditor.FontSize = FontSize.Three;
            _explainQuestionTextEditor.Html = null;
            _explainQuestionTextEditor.Location = new Point(0, 24);
            _explainQuestionTextEditor.Name = "_explainQuestionTextEditor";
            _explainQuestionTextEditor.Size = new Size(632, 124);
            _explainQuestionTextEditor.TabIndex = 1;
            explainQuestionPanel.Controls.Add(_explainQuestionTextEditor);
            ResumeLayout(false);
        }

        private void OnDataItemChanged()
        {
            //tbQuestionContent.Text = DataItem.ContentQuestion;
            //Text = "Question " + DataItem.OrderQuestion.ToString();
            //if (DataItem.imageName != null && DataItem.imageName != "")
            //{
            //    // Dislay Image;
            //    pictureBox.Image = new Bitmap(PATH_FORDER_IMAGE + DataItem.imageName);
            //    pictureBox.Show();
            //    lbDislayImage.Visible = false;
            //}
            //else
            //{
            //    pictureBox.Visible = false;
            //    lbDislayImage.Visible = true;
            //}
            //AddAnswerOptions();
        }

        private void InitDefaultGui()
        {
            answerListTableLayoutPanel.SuspendLayout();
            for (int idx = 0; idx < 4; idx++)
            {
                var newItem = new AnswerDataItem(idx + 1, "", false);
                DataItem.AnswerData.AnswerData.Add(newItem);
                var itemLayout = new HTMLAnswerItem(idx + 1);
                itemLayout.DataItem.orderAnswer = idx + 1;
                itemLayout.Delete += ItemLayoutDelete;
                itemLayout.Anchor = (AnchorStyles.Left  | AnchorStyles.Top);
                var style = new RowStyle(SizeType.Percent);
                answerListTableLayoutPanel.RowStyles.Add(style);
                answerListTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                answerListTableLayoutPanel.Controls.Add(itemLayout, 0, idx);
            }
            answerListTableLayoutPanel.ResumeLayout();
        }

        private void ItemLayoutDelete(object sender, int parameter)
        {
            DeleteAnswerItem(parameter);
        }

        private void MoreAnswerButtonClick(object sender, EventArgs e)
        {
            // set at 6 item, if more than 6, scrollable
            if (answerListTableLayoutPanel.Controls.Count == _maxShowItem)
            {
                MessageBox.Show(this, @"Can not add more than 6 answers", @"Error", MessageBoxButtons.OK);
                return;
            }
            answerListTableLayoutPanel.SuspendLayout();
            var newItem = new AnswerDataItem(5, "", false);
            DataItem.AnswerData.AnswerData.Add(newItem);
            var itemLayout = new HTMLAnswerItem(5);
            itemLayout.DataItem.orderAnswer = 5;
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            var style = new RowStyle(SizeType.Percent);
            answerListTableLayoutPanel.RowStyles.Add(style);
            answerListTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
            answerListTableLayoutPanel.Controls.Add(itemLayout, 0, 4);
            answerListTableLayoutPanel.ResumeLayout();
        }

        private void DeleteAnswerItem(int orderAnswer)
        {
            answerListTableLayoutPanel.SuspendLayout();
            answerListTableLayoutPanel.Controls.RemoveAt(orderAnswer - 1);
            _dataItem.AnswerData.AnswerData.RemoveAt(orderAnswer - 1);
            UpdateAllDataItem();
            //UpdateEditor();
            answerListTableLayoutPanel.ResumeLayout();
            Refresh();
        }

        private void UpdateAllDataItem()
        {
            for (int idx = 0; idx < answerListTableLayoutPanel.Controls.Count; idx++)
            {
                var item = answerListTableLayoutPanel.Controls[idx] as HTMLAnswerItem;
                if (item != null)
                {
                    item.DataItem.OrderAnswer = idx + 1;
                    item.Size = new Size(answerListTableLayoutPanel.Width - 10, item.Height);
                }
            }
            answerListTableLayoutPanel.Refresh();
        }

        private void CreateButtonClick(object sender, EventArgs e)
        {
            //Valiate Question Content.
            if (string.IsNullOrWhiteSpace(_contentQuestionTextEditor.DocumentText))
            {
                MessageBox.Show(string.Format("{0} cannot be empty", "Question content"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_action == "create")
            {
                DataItem.IdQuestion = string.Format("{0:ddmmyyyyHHmmss}", DateTime.Now);
                DataItem.ContentQuestion = _contentQuestionTextEditor.DocumentText;
                DataItem.ExplainContent = _explainQuestionTextEditor.DocumentText;
                DataItem.AnswerData.AnswerData.Clear();
                for (int idx = 0; idx < answerListTableLayoutPanel.Controls.Count; idx++)
                {
                    var item = answerListTableLayoutPanel.Controls[idx] as HTMLAnswerItem;
                    if (item != null && item.DataItem.ContentAnswer != "")
                    {
                        var answer = new AnswerDataItem();
                        answer.ContentAnswer = item.DataItem.ContentAnswer;
                        answer.OrderAnswer = idx;
                        answer.isTrue = item.DataItem.isTrue;
                        DataItem.AnswerData.AnswerData.Add(answer);
                    }
                }
            }
            else
            {
                //DataItem.ContentQuestion = tbQuestionContent.Text;
                //DataItem.ExplainContent = tbQuestionContent.Text;
                //// Update Answer.
                //DataItem.AnswerData.AnswerData.Clear();
                //for (int idx = 0; idx < tbListAnswer.Controls.Count; idx++)
                //{
                //    var item = tbListAnswer.Controls[idx] as Item;
                //    if (item != null && item.DataItem.ContentAnswer != "")
                //    {
                //        var answer = new AnswerDataItem();
                //        answer.ContentAnswer = item.DataItem.ContentAnswer;
                //        answer.OrderAnswer = idx;
                //        answer.isTrue = item.DataItem.isTrue;
                //        DataItem.AnswerData.AnswerData.Add(answer);
                //    }
                //}
            }

        }
    }
}