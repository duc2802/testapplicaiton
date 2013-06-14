using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PresentationLayer.ActionController;
using PresentationLayer.QuestionEditor.Data;
using SingleInstanceObject;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListPanel : UserControl
    {
        private QuestionDataController _dataController;

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
            for (int idx = 0; idx < _dataController.Count; idx++)
            {
                AddQuestionItem(_dataController.DataItems[idx], idx + 1);
            }
        }

        private void UpdateEditor(int id)
        {
            MessageBox.Show(this, id.ToString(), "Test");
        }

        private QuestionListItemCustom CreateQuestionItem(QuestionDataItem questionData)
        {
            var itemLayout = new QuestionListItemCustom(questionData);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Update += ItemLayoutUpdate;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return itemLayout;
        }

        private void AddQuestionItem(QuestionDataItem questionData, int idx)
        {
            questionPanel.SuspendLayout();
            QuestionListItemCustom questionItem = CreateQuestionItem(questionData);
            questionItem.DataItem.OrderQuestion = idx;
            var style = new RowStyle(SizeType.AutoSize);
            questionPanel.RowStyles.Add(style);
            questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
            questionPanel.Controls.Add(questionItem, 0, idx);
            questionPanel.ResumeLayout(false);
        }

        private void DeleteQuestionItem(int idQuestion)
        {
            questionPanel.SuspendLayout();
            var item = questionPanel.Controls.Find(idQuestion.ToString(), true).First() as QuestionListItemCustom;
            if (item != null)
            {
                int idx = questionPanel.Controls.IndexOf(item);
                questionPanel.Controls.Remove(item);
                questionPanel.RowStyles.RemoveAt(idx);
                questionPanel.Refresh();
            }
            else
            {
                MessageBox.Show(this, "Delete Error", "Error", MessageBoxButtons.OK);
            }
            UpdateAllDataItem();
            questionPanel.ResumeLayout();
            Refresh();
        }

        private void UpdateQueationItem(int idQuestion)
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
                }
            }
            questionPanel.Refresh();
        }

        #region Implement registed event

        private void ChangeTestId(object sender, int parameter)
        {
            UpdateEditor(parameter);
        }

        private void OnAddQuestionItem(object sender, QuestionDataItem parameter)
        {
            int idx = questionPanel.Controls.Count;
            questionPanel.SuspendLayout();
            _dataController.DataItems.Add(parameter);
            AddQuestionItem(parameter, idx + 1);
            questionPanel.ResumeLayout(true);
        }

        private void ItemLayoutDelete(object sender, int parameter)
        {
            DeleteQuestionItem(parameter);
        }

        private void ItemLayoutUpdate(object sender, int parameter)
        {
            UpdateQueationItem(parameter);
        }

        #endregion
    }
}