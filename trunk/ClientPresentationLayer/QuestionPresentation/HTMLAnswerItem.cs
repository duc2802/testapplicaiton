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
using TextEditor = LiveSwitch.TextControl.Editor;
using BusinessEntities;


namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class HTMLAnswerItem : UserControl
    {
        private HtmlRichTextBox _contentAnswerTextEditor;
        public bool IsChoise { set; get; }

        public int OrderAnswer { get { return int.Parse(DataBEItem.AnswerID); } }

        private AnswerBE _dataBEItem;
        public AnswerBE DataBEItem
        {
            set
            {
                _dataBEItem = value;
                Name = _dataBEItem.AnswerID;
            }
            get { return _dataBEItem; }
        }

        public HTMLAnswerItem()
        {
            InitializeComponent();
            InitCustomComponent(true);
            InitEvent();
        }

        private void InitData(AnswerBE itemData)
        {
            _dataBEItem = itemData;
        }

        public HTMLAnswerItem(AnswerBE itemData, bool isEditMode)
        {
            InitializeComponent();
            InitCustomComponent(isEditMode);
            InitGui(itemData, isEditMode);
            InitEvent();
            InitData(itemData);
            //InitData(index);
        }

        public HTMLAnswerItem(int index)
        {
            InitializeComponent();
            InitCustomComponent(true);
            InitEvent();
            InitData(index);
        }

        public HTMLAnswerItem(AnswerBE item, int index)
        {
            InitializeComponent();
            InitCustomComponent(true);
            InitEvent();
        }

        private void InitGui(AnswerBE itemData, bool isChoise)
        {
            //contentAnswerTextEditor.Html = itemData.Content;
            _contentAnswerTextEditor.Text = "";
            _contentAnswerTextEditor.AddHTML(itemData.Content);
            _contentAnswerTextEditor.Text = _contentAnswerTextEditor.Text.Trim();
            orderAnswerLabel.Text = (int.Parse(itemData.AnswerID) + 1).ToString();
            btTrueFail.Visible = false;
            trueCheckBox.Visible = true;
            if (isChoise)
            {
                trueCheckBox.Checked = isChoise;
            }
        }

        public void TurnOnAnswer(bool on)
        {
            btTrueFail.Visible = on;
        }

        private void InitEvent()
        {
            trueCheckBox.CheckedChanged += CheckChangedEvent;
            orderAnswerLabel.Click += OrderAnswerClick;
        }

        private void OrderAnswerClick(object sender, EventArgs e)
        {
            trueCheckBox.Checked = !trueCheckBox.Checked;
        }

        private void CheckChangedEvent(object sender, EventArgs e)
        {
            IsChoise = trueCheckBox.Checked;
            OnCheckChange(OrderAnswer, IsChoise);
        }

        private void ItemLeave(object sender, EventArgs e)
        {
            //_dataBEItem.Content = _contentAnswerTextEditor.DocumentText;

        }

        private void InitData(int index)
        {
            Refresh();
        }

        private void InitCustomComponent(bool isEditMode)
        {
            SuspendLayout();
            //Init contentQuestionTextEditor
            contentPanel.BorderStyle = BorderStyle.None;
            _contentAnswerTextEditor = new HtmlRichTextBox();
            _contentAnswerTextEditor.BorderStyle = BorderStyle.None;
            //contentAnswerTextEditor.BackColor = SystemColors.Control;
            //contentAnswerTextEditor.BodyBackgroundColor = Color.White;
            //contentAnswerTextEditor.BodyHtml = null;
            //contentAnswerTextEditor.BodyText = null;
            //contentAnswerTextEditor.Dock = DockStyle.Fill;
            //contentAnswerTextEditor.EditorBackColor = Color.FromArgb(((((255)))), ((((255)))), ((((255)))));
            //contentAnswerTextEditor.EditorForeColor = Color.FromArgb(((((0)))), ((((0)))), ((((0)))));
            //contentAnswerTextEditor.Html = null;
            //contentAnswerTextEditor.Location = new Point(0, 24);
            //contentAnswerTextEditor.Name = "editor";
            _contentAnswerTextEditor.Size = new Size(632, 124);
            _contentAnswerTextEditor.TabIndex = 1;
            contentPanel.Controls.Add(_contentAnswerTextEditor);

            if (!isEditMode)
            {
                trueCheckBox.Visible = false;
                orderAnswerLabel.BorderStyle = BorderStyle.None;
                BorderStyle = BorderStyle.None;

                contentPanel.Size = new Size(369, 30);
            }
            ResumeLayout(false);
        }

        private void TrueCheckBoxCheckedChanged(object sender, EventArgs e)
        {
          //  DataItem.isTrue = trueCheckBox.Checked;
            //OnCheckChange(DataItem.orderAnswer - 1, DataItem.isTrue);  
        }
        public event ActionEventHandler<int, bool> CheckChange
        {
            add
            {
                lock (_checkboxChangetLocker)
                {
                    _checkboxChangeEvent += value;
                }
            }
            remove
            {
                lock (_checkboxChangetLocker)
                {
                    _checkboxChangeEvent -= value;
                }
            }
        }

        private ActionEventHandler<int, bool> _checkboxChangeEvent;
        private readonly object _checkboxChangetLocker = new object();

        private void OnCheckChange(int idx, bool status)
        {
            ActionEventHandler<int, bool> handler = _checkboxChangeEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idx, status);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

    }
}
