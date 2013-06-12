﻿using System;
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
                var style = new RowStyle(SizeType.AutoSize);
                questionPanel.RowStyles.Add(style);
                questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
                questionPanel.Controls.Add(itemLayout, 0, idx);
                questionPanel.ResumeLayout();
            }
            
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
