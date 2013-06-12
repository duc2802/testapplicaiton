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
            for (int idx = 0; idx < _dataController.Count; idx++)
            {
                var questionData = _dataController.DataItems[idx];
                var itemLayout = new QuestionListItemCustom(questionData);
                itemLayout.SuspendLayout();
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                itemLayout.ResumeLayout();
                questionPanel.Controls.Add(itemLayout);
            }
            questionPanel.ResumeLayout();
        }

        private void UpdateEditor(int id)
        {
            MessageBox.Show(this, id.ToString(), "Test");
        }

        #region Implement registed event

        private void ChangeTestId(object sender, int parameter)
        {
            UpdateEditor(parameter);
        }

        #endregion
    }
}
