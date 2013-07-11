using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.BusinessObjects;
using Commons.CommonGui;
using LiveSwitch.TextControl;
using PresentationLayer.QuestionEditor.Data;
using TextEditor = LiveSwitch.TextControl.Editor;

namespace PresentationLayer.QuestionEditor
{
    public partial class HTMLAnswerItem : UserControl
    {
        public TextEditor contentAnswerTextEditor;
        private HtmlRichTextBox htmlRichTextBox;

        private AnswerDataItem _dataItem;
        public AnswerDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.orderAnswer.ToString();
                //OnDataItemChanged();
            }
            get { return _dataItem; }
        }

        public HTMLAnswerItem()
        {
            InitializeComponent();
            InitCustomComponent(true);
            InitEvent();
        }

        public HTMLAnswerItem(AnswerDataItem itemData, bool isEditMode)
        {
            InitializeComponent();
            InitCustomComponent(isEditMode);
            InitGui(itemData, isEditMode);
            //InitEvent();
            InitData(itemData);
        }

        public HTMLAnswerItem(int index)
        {
            InitializeComponent();
            InitCustomComponent(true);
            InitEvent();
            InitData(index);
        }

        public HTMLAnswerItem(AnswerDataItem item, int index)
        {
            InitializeComponent();
            InitCustomComponent(true);
            InitData(index);
            InitEvent();
        }

        private void InitGui(AnswerDataItem itemData, bool isEditMode)
        {
            orderAnswerLabel.Text = (itemData.OrderAnswer + 1).ToString();
            if (isEditMode)
            {
                contentAnswerTextEditor.Html = itemData.ContentAnswer;
            }
            else
            {
                htmlRichTextBox.AddHTML(itemData.ContentAnswer);
                htmlRichTextBox.Text = htmlRichTextBox.Text.Trim();
            }
        }

        private void InitEvent()
        {
            deleteButton.Click += DeleteAnswerButtonClick;
            Leave += ItemLeave;
            trueCheckBox.CheckedChanged += TrueCheckBoxCheckedChanged;
        }

        private void ItemLeave(object sender, EventArgs e)
        {
            _dataItem.ContentAnswer = contentAnswerTextEditor.DocumentText;
        }

        private void InitData(int index)
        {
            DataItem = new AnswerDataItem();
            orderAnswerLabel.Text = index.ToString();
            //DataItem.PropertyChanged += DataItemPropertyChanged;
            Refresh();
        }

        private void InitData(AnswerDataItem data)
        {
            _dataItem = data;
        }

        private void InitCustomComponent(bool isEditMode)
        {
            SuspendLayout();
            //Init contentQuestionTextEditor
            contentPanel.BorderStyle = BorderStyle.None;
            if(isEditMode)
            {
                contentAnswerTextEditor = new TextEditor(isEditMode);
                contentAnswerTextEditor.BackColor = SystemColors.Control;
                contentAnswerTextEditor.BodyBackgroundColor = Color.White;
                contentAnswerTextEditor.BodyHtml = null;
                contentAnswerTextEditor.Parent = this;
                contentAnswerTextEditor.Parent = this;
                contentAnswerTextEditor.BodyText = null;
                contentAnswerTextEditor.Dock = DockStyle.Fill;
                contentAnswerTextEditor.EditorBackColor = Color.FromArgb(((((255)))), ((((255)))), ((((255)))));
                contentAnswerTextEditor.EditorForeColor = Color.FromArgb(((((0)))), ((((0)))), ((((0)))));
                contentAnswerTextEditor.FontSize = FontSize.Three;
                contentAnswerTextEditor.Html = null;
                contentAnswerTextEditor.Location = new Point(0, 24);
                contentAnswerTextEditor.Name = "editor";
                contentAnswerTextEditor.Size = new Size(632, 124);
                contentAnswerTextEditor.TabIndex = 1;
                contentPanel.Controls.Add(contentAnswerTextEditor);
            }
            else
            {
                htmlRichTextBox = new HtmlRichTextBox();
                htmlRichTextBox.Dock = DockStyle.Fill;
                htmlRichTextBox.BorderStyle = BorderStyle.None;
                htmlRichTextBox.Name = "htmlRichTextBox";
                htmlRichTextBox.Size = new Size(369, 30);
                htmlRichTextBox.TabIndex = 1;
                contentPanel.Controls.Add(htmlRichTextBox);
            }

            if (!isEditMode)
            {
                trueCheckBox.Visible = false;
                deleteButton.Visible = false;
                orderAnswerLabel.BorderStyle = BorderStyle.None;
                BorderStyle = BorderStyle.None;

                contentPanel.Size = new Size(369, 30);
            }
            ResumeLayout();
        }

        private void TrueCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            DataItem.isTrue = trueCheckBox.Checked;
            //OnCheckChange(DataItem.orderAnswer - 1, DataItem.isTrue);  
        }

        private void DeleteAnswerButtonClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Do you want to delete this question?", "Delete question.",
                                         MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                OnDelete(this.DataItem.orderAnswer);
            }
        }

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

        private void OnDelete(int idAnswer)
        {
            ActionEventHandler<int> handler = _deleteEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idAnswer);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }
    }
}
