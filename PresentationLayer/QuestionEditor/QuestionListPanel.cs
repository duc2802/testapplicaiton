using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.ActionController;
using SingleInstanceObject;

namespace PresentationLayer.QuestionEditor
{
    public partial class QuestionListPanel : UserControl
    {
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
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            //Init list from dataItemController.
            questionPanel.SuspendLayout();
            //int[] keys = _dataItemController.TestBook.Keys.ToArray();
            for (int idx = 0; idx < 1; idx++)
            {

                QuestionListItemCustom itemLayout = new QuestionListItemCustom();
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(questionPanel.Width - 20, itemLayout.Height);
                itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
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
