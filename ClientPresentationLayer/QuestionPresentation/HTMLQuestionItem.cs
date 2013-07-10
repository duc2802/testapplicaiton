using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;
using LiveSwitch.TextControl;
using SingleInstanceObject;
using TextEditor = LiveSwitch.TextControl.Editor;
using BusinessEntities;
using Commons.BusinessObjects;
using ClientPresentationLayer.QuestionPresentation.Data;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class HTMLQuestionItem : UserControl
    {
        private TextEditor _contentQuestionTextEditor;
        private QuestionBE _dataBEItem;

        private string PATH_FORDER_IMAGE = Singleton<SettingManager>.Instance.GetImageFolder();

        public bool isExplainStatus;

        public HTMLQuestionItem()
        {
            InitializeComponent();
        }

        public HTMLQuestionItem(QuestionBE Item)
        {
            InitializeComponent();
            InitData(Item);
            InitGui(Item);
            InitEvent();
        }

        public HTMLQuestionItem(QuestionBE Item, bool isExplain)
        {
            InitializeComponent();
            InitData(Item);
            InitGui(Item, isExplain);
            InitEvent();
        }

        public void InitEvent() 
        {

        }

        private void InitData(QuestionBE Item)
        {
            DataBEItem = Item;
        }
        
        public void InitGui(QuestionBE Item)
        {
            _contentQuestionTextEditor.Html = DataBEItem.QuestionContent;
            AddAnswerOptionsFromBe();
            ResumeLayout();
        }

        public void InitGui(QuestionBE Item, bool isExplain)
        {
            _contentQuestionTextEditor.Html = DataBEItem.QuestionContent;
            AddAnswerOptionsFromBe(isExplain);
            ResumeLayout();
        }
        
        private void QuestionItemLoad(object sender, EventArgs e)
        {

        }

        private void AddAnswerOptionsFromBe(bool isExplain)
        {
            int dix = 0;
            foreach (AnswerBE answerItem in DataBEItem.ListAnswers)
            {
                AddNewLine(answerItem, isExplain);
            }
        }

        private void AddAnswerOptionsFromBe()
        {
            int dix = 0;
            foreach (AnswerBE answerItem in DataBEItem.ListAnswers)
            {
                AddNewLine(answerItem);
            }
        }

        private void AddNewLine(AnswerBE dataItem, bool isExplain)
        {
            SuspendLayout();
            listAnswer.SuspendLayout();
            var answerItem = CreateAnswerItem(dataItem, isExplain);
            listAnswer.Controls.Add(answerItem);
            listAnswer.ResumeLayout();
            ResumeLayout();
        }

        private void AddNewLine(AnswerBE dataItem)
        {
            SuspendLayout();
            listAnswer.SuspendLayout();
            var answerItem = CreateAnswerItem(dataItem);
            listAnswer.Controls.Add(answerItem);
            listAnswer.ResumeLayout();
            ResumeLayout();
        }

        private HTMLAnswerItem CreateAnswerItem(AnswerBE dataItem)
        {
            HTMLAnswerItem answerItem;
            if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.ContainsKey(_dataBEItem.QuestionID))
            {
                List<int> answerList;
                if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.TryGetValue(_dataBEItem.QuestionID, out answerList))
                {
                    if (answerList.Contains(int.Parse(dataItem.AnswerID)))
                    {
                        answerItem = new HTMLAnswerItem(dataItem, true);
                    }
                    else
                    {
                        answerItem = new HTMLAnswerItem(dataItem, false);
                    }
                }
                else
                {
                    answerItem = new HTMLAnswerItem(dataItem, false);
                }
            }
            else
            {
                answerItem = new HTMLAnswerItem(dataItem, false);
            }
            answerItem.Location = new Point(0, answerItem.Height);
            answerItem.CheckChange += CheckChangeOfAnswerItem;
            answerItem.Size = new Size(listAnswer.Width, answerItem.Height);
            answerItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            return answerItem;
        }

        private HTMLAnswerItem CreateAnswerItem(AnswerBE dataItem, bool isExplain)
        {
            HTMLAnswerItem answerItem;
            if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.ContainsKey(_dataBEItem.QuestionID))
            {
                List<int> answerList;
                if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.TryGetValue(_dataBEItem.QuestionID, out answerList))
                {
                    if (answerList.Contains(int.Parse(dataItem.AnswerID)))
                    {
                        answerItem = new HTMLAnswerItem(dataItem, true);
                    }
                    else
                    {
                        answerItem = new HTMLAnswerItem(dataItem, false);
                    }
                }
                else
                {
                    answerItem = new HTMLAnswerItem(dataItem, false);
                }
            }
            else
            {
                answerItem = new HTMLAnswerItem(dataItem, false);
            }

            if (isExplain && FormatHelper.StringToBoolean((dataItem.Result)))
            {
                answerItem.TurnOnAnswer(true);
            }
            else
            {
                answerItem.TurnOnAnswer(false);
            }

            answerItem.Location = new Point(0, answerItem.Height);
            answerItem.CheckChange += CheckChangeOfAnswerItem;
            answerItem.Size = new Size(listAnswer.Width, answerItem.Height);
            answerItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            return answerItem;
        }

        private void CheckChangeOfAnswerItem(object sender, int index, bool ischecked)
        {
            if(ischecked)
            {
                OnChoiseAnswer(_dataBEItem.QuestionID, index);
            }
            else
            {
                OnUnChoiseAnswer(_dataBEItem.QuestionID, index);
            }
        }

        public QuestionBE DataBEItem
        {
            set
            {
                _dataBEItem = value;
                Name = _dataBEItem.QuestionID;
            }
            get { return _dataBEItem; }
        }

        private void ShowImageofQuestion(string pathImage)
        {
            //Load image in new form
            var picture = new DislayImageForm(PATH_FORDER_IMAGE + pathImage);
            picture.ShowDialog();
        }
        private void InitCustomComponent()
        {
            SuspendLayout();
            //Init contentQuestionTextEditor
            _contentQuestionTextEditor = new TextEditor(true);
            _contentQuestionTextEditor.BackColor = SystemColors.Control;
            _contentQuestionTextEditor.BodyBackgroundColor = Color.White;
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
            panelQuestionContent.Controls.Add(_contentQuestionTextEditor);
            ResumeLayout(false);
        }
        
        /// <summary>
        /// Choise a answer event
        /// </summary>
        public event ActionEventHandler<string, int> ChoiseAnswer
        {
            add
            {
                lock (__choiseAnswerEventLocker)
                {
                    _choiseAnswerEvent += value;
                }
            }
            remove
            {
                lock (__choiseAnswerEventLocker)
                {
                    _choiseAnswerEvent -= value;
                }
            }
        }

        private ActionEventHandler<string, int> _choiseAnswerEvent;
        private readonly object __choiseAnswerEventLocker = new object();

        private void OnChoiseAnswer(string questionId, int idx)
        {
            ActionEventHandler<string, int> handler = _choiseAnswerEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, questionId, idx);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        /// <summary>
        /// Unchoise event
        /// </summary>
        public event ActionEventHandler<string, int> UnChoiseAnswer
        {
            add
            {
                lock (__unchoiseAnswerEventLocker)
                {
                    _unchoiseAnswerEvent += value;
                }
            }
            remove
            {
                lock (__unchoiseAnswerEventLocker)
                {
                    _unchoiseAnswerEvent -= value;
                }
            }
        }

        private ActionEventHandler<string, int> _unchoiseAnswerEvent;
        private readonly object __unchoiseAnswerEventLocker = new object();

        private void OnUnChoiseAnswer(string questionId, int idx)
        {
            ActionEventHandler<string, int> handler = _unchoiseAnswerEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, questionId, idx);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }
    }
    }
}
