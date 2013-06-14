using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
        }

        private void InitGui()
        {
            this._dataController = new QuestionDataController();

            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;
            questionPanel.SuspendLayout();
            questionPanel.RowStyles.Clear();
            questionPanel.AutoSize = true; 
            questionPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;   
            questionPanel.RowCount = 10;
            for (int idx = 0; idx < _dataController.Count; idx++)
            {
                var questionData = _dataController.DataItems[idx];
                var itemLayout = new QuestionListItemCustom(questionData);
                itemLayout.Delete += ItemLayoutDelete;
                itemLayout.Update += ItemLayoutUpdate;

                var style = new RowStyle(SizeType.AutoSize);
                questionPanel.RowStyles.Add(style);
                questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                questionPanel.Controls.Add(itemLayout, 0, idx);
                questionPanel.ResumeLayout(false);
            }
        }

        private void UpdateEditor(int id)
        {
            MessageBox.Show(this, id.ToString(), "Test");
        }

        private void DeleteQuestionItem(int idQuestion)
        {
            questionPanel.SuspendLayout();
            var item = questionPanel.Controls.Find(idQuestion.ToString(), true).First() as QuestionListItemCustom;
            if(item != null)
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
            for(int idx = 0; idx < questionPanel.Controls.Count; idx++)
            {
                var item = questionPanel.Controls[idx] as QuestionListItemCustom;
                if(item != null)
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
