using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessEntities;
using Commons.BusinessObjects;
using PresentationLayer.ActionController;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.ThreadManager.DataThread;
using SingleInstanceObject;
using ThreadQueueManager;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListPanel : UserControl
    {
        private QuestionDataController _dataController;
        private Point _originalPoint = Point.Empty;
        private object _displayLocker = new object();

        public QuestionListPanel()
        {
            InitializeComponent();
            InitGui();
            InitEvent();
        }

        private void InitEvent()
        {
            Singleton<GuiActionEventController>.Instance.ChangeTestId += ChangeTestId;
            Singleton<GuiActionEventController>.Instance.AddQuestionItem += OnAddQuestionItem;
            Singleton<GuiActionEventController>.Instance.ClearAllQuestionItem += ClearAllQuestionItem;
            Singleton<GuiActionEventController>.Instance.ChangeQuestion += ChangeQuestion;

            questionPanel.DragDrop += QuestionPanelDragDrop;
            questionPanel.DragOver += QuestionPanelDragOver;
            questionPanel.DragEnter += QuestionPanelDragEnter;
        }

        private void InitGui()
        {
            _dataController = new QuestionDataController();
            FillQuestionItem();
        }

        private void FillQuestionItem()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;
            questionPanel.RowStyles.Clear();
            questionPanel.AutoSize = true;
            questionPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (Singleton<TestBE>.Instance != null)
            {
                _dataController = new QuestionDataController(Singleton<TestBE>.Instance);
            }
            for (var idx = 0; idx < _dataController.Count; idx++)
            {
                AddQuestionItem(_dataController.DataItems[idx], idx + 1);
            }
        }

        private void UpdateEditor(string idTest)
        {
            if (idTest != null)
            {
                _dataController.DataItems.Clear();
                _dataController.IdTest = idTest;
                questionPanel.Controls.Clear();
                FillQuestionItem();
            }
        }

        private QuestionListItemCustom CreateQuestionItem(QuestionDataItem questionData)
        {
            var itemLayout = new QuestionListItemCustom(questionData);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Update += ItemLayoutUpdate;
            itemLayout.MouseDown += ItemLayoutMouseDown;
            itemLayout.Edit += ItemLayoutEdit;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return itemLayout;
        }

        private void AddQuestionItem(QuestionDataItem questionData, int idx)
        {
            QuestionListItemCustom questionItem = CreateQuestionItem(questionData);
            questionItem.DataItem.OrderQuestion = idx;
            var style = new RowStyle(SizeType.AutoSize);
            questionPanel.RowStyles.Add(style);
            questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
            questionPanel.Controls.Add(questionItem, 0, idx);
        }

        private void DeleteQuestionItem(string idQuestion)
        {
            questionPanel.SuspendLayout();
            var item = questionPanel.Controls.Find(idQuestion, true).First() as QuestionListItemCustom;
            if (item != null)
            {
                int idx = questionPanel.Controls.IndexOf(item);
                questionPanel.Controls.Remove(item);
                questionPanel.RowStyles.RemoveAt(idx);
                questionPanel.Refresh();

                var test =
                    Singleton<TestBE>.Instance.ListQuestion.FirstOrDefault(ques => ques.QuestionID.Equals(idQuestion));
                Singleton<TestBE>.Instance.ListQuestion.Remove(test);
                Singleton<GuiActionEventController>.Instance.OnDeleteQuestionItem();
                ICommand command = new SaveTestCmd(ExecuteMethod.Async, Singleton<TestBE>.Instance);
                Singleton<DataQueueThreadController>.Instance.PutCmd(command);
            }
            else
            {
                MessageBox.Show(this, "Delete Error", "Error", MessageBoxButtons.OK);
            }
            UpdateAllDataItem();
            questionPanel.ResumeLayout();
            Refresh();
        }

        private void UpdateQueationItem(string idQuestion)
        {
            var item = questionPanel.Controls.Find(idQuestion.ToString(), true).First() as QuestionListItemCustom;
            if (item != null)
            {
                item.Refresh();
                questionPanel.Refresh();
            }
            else
            {
                MessageBox.Show(this, "Update Error", "Error", MessageBoxButtons.OK);
            }
        }

        private void UpdateAllDataItem()
        {
            for (int idx = 0; idx < questionPanel.Controls.Count; idx++)
            {
                var item = questionPanel.Controls[idx] as QuestionListItemCustom;
                if (item != null)
                {
                    item.DataItem.OrderQuestion = idx + 1;
                    item.orderNumQuest.Text = item.DataItem.OrderQuestion.ToString();
                }
            }
            questionPanel.Refresh();
        }

        private void ItemLayoutMouseDown(object sender, MouseEventArgs e)
        {
            _originalPoint = new Point(e.X, e.Y);
            questionPanel.AllowDrop = true;
            ((Control) sender).DoDragDrop(sender, DragDropEffects.All);
        }

        private void QuestionPanelDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof (Button)))
                e.Effect = DragDropEffects.All;
        }

        private void QuestionPanelDragOver(object sender, DragEventArgs e)
        {
            ((Control) e.Data.GetData(typeof (Button))).Location =
                PointToClient(new Point(e.X - _originalPoint.X, e.Y - _originalPoint.Y));
            ((Control) e.Data.GetData(typeof (Button))).BringToFront();
        }

        private void QuestionPanelDragDrop(object sender, DragEventArgs e)
        {
            ((Button) e.Data.GetData(typeof (Button))).BringToFront();
        }

        #region Implement registed event

        private void ChangeTestId(object sender, string parameter)
        {
            Invoke((MethodInvoker) (() => UpdateEditor(parameter)));
        }

        private void OnAddQuestionItem(object sender, QuestionDataItem parameter)
        {
            int idx = questionPanel.Controls.Count;
            questionPanel.SuspendLayout();
            _dataController.DataItems.Add(parameter);
            AddQuestionItem(parameter, idx + 1);
            questionPanel.ResumeLayout(true);
        }

        private void ItemLayoutDelete(object sender, string parameter)
        {
            DeleteQuestionItem(parameter);
        }

        private void ItemLayoutUpdate(object sender, string parameter)
        {
            UpdateQueationItem(parameter);
        }

        private void ClearAllQuestionItem(object sender)
        {
            questionPanel.SuspendLayout();
            _dataController.DataItems.Clear();
            questionPanel.Controls.Clear();
            Singleton<GuiActionEventController>.Instance.TestId = null;
            questionPanel.ResumeLayout(true);
        }

        private void ItemLayoutEdit(object sender, QuestionDataItem parameter)
        {
            ChangeDataQuestion(parameter);
        }

        private void ChangeQuestion(object sender, QuestionDataItem parameter)
        {
            ChangeDataQuestion(parameter);
        }

        private void ChangeDataQuestion(QuestionDataItem parameter)
        {
            questionPanel.SuspendLayout();
            var dataItem =
            _dataController.DataItems.FirstOrDefault(d => d.IdQuestion == parameter.IdQuestion);
            if (dataItem != null)
            {
                dataItem.ExplainContent = parameter.ExplainContent;
                dataItem.ContentQuestion = parameter.ContentQuestion;
                dataItem.AnswerData = parameter.AnswerData;

                var item = questionPanel.Controls.Find(dataItem.IdQuestion, true).First() as QuestionListItemCustom;
                item.DataItem = dataItem;
                item.Refresh();
            }
            questionPanel.ResumeLayout(true);

            var question = parameter.getQuestionBE();
            var ques =
                Singleton<TestBE>.Instance.ListQuestion.FirstOrDefault(q => q.QuestionID == question.QuestionID);
            ques.QuestionContent = question.QuestionContent;
            ques.Explain = question.Explain;
            ques.ListAnswers = question.ListAnswers;

            ICommand command = new SaveTestCmd(ExecuteMethod.Async, Singleton<TestBE>.Instance);
            Singleton<DataQueueThreadController>.Instance.PutCmd(command);
        }

        #endregion
    }
}