using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientPresentationLayer.QuestionPresentation.Data;
using ClientPresentationLayer.QuestionPresentation;
using Commons;
using Commons.BusinessObjects;
using SingleInstanceObject;
using BusinessEntities;
using System.Collections;
namespace ClientPresentationLayer
{
    public partial class QuestionItem : UserControl
    {
        private QuestionBE _dataBEItem;

        private string PATH_FORDER_IMAGE = Singleton<SettingManager>.Instance.GetImageFolder();

        public bool isExplainStatus;

        public QuestionItem()
        {
            InitializeComponent();
        }

        public QuestionItem(QuestionBE Item)
        {
            InitializeComponent();
            InitData(Item);
            InitGui(Item);
            InitEvent();
        }

        public QuestionItem(QuestionBE Item, bool isExplain)
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
            tbQuestionContent.Text = DataBEItem.QuestionContent;
            if (!string.IsNullOrEmpty(DataBEItem.NameImage))
            {
                string newPath = PATH_FORDER_IMAGE + DataBEItem.NameImage;
                pictureBox.Image = new Bitmap(newPath);
                pictureBox.Show();
            }
            AddAnswerOptionsFromBe();
            ResumeLayout();
        }

        public void InitGui(QuestionBE Item, bool isExplain)
        {
            tbQuestionContent.Text = DataBEItem.QuestionContent;
            if (!string.IsNullOrEmpty(DataBEItem.NameImage))
            {
                string newPath = PATH_FORDER_IMAGE + DataBEItem.NameImage;
                pictureBox.Image = new Bitmap(newPath);
                pictureBox.Show();
            }
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
            tbListAnswerItem.SuspendLayout();
            var answerItem = CreateAnswerItem(dataItem, isExplain);
            tbListAnswerItem.Controls.Add(answerItem);
            tbListAnswerItem.ResumeLayout();
            ResumeLayout();
        }

        private void AddNewLine(AnswerBE dataItem)
        {
            SuspendLayout();
            tbListAnswerItem.SuspendLayout();
            var answerItem = CreateAnswerItem(dataItem);
            tbListAnswerItem.Controls.Add(answerItem);
            tbListAnswerItem.ResumeLayout();
            ResumeLayout();
        }

        private AnswerItem CreateAnswerItem(AnswerBE dataItem)
        {
            AnswerItem answerItem;
            if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.ContainsKey(_dataBEItem.QuestionID))
            {
                List<int> answerList;
                if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.TryGetValue(_dataBEItem.QuestionID, out answerList))
                {
                    if (answerList.Contains(int.Parse(dataItem.AnswerID)))
                    {
                        answerItem = new AnswerItem(dataItem, true);
                    }
                    else
                    {
                        answerItem = new AnswerItem(dataItem, false);
                    }
                }
                else
                {
                    answerItem = new AnswerItem(dataItem, false);
                }
            }
            else
            {
                answerItem = new AnswerItem(dataItem, false);
            }
            answerItem.Location = new Point(0, answerItem.Height);
            answerItem.CheckChange += CheckChangeOfAnswerItem;
            answerItem.Size = new Size(tbListAnswerItem.Width, answerItem.Height);
            answerItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            return answerItem;
        }

        private AnswerItem CreateAnswerItem(AnswerBE dataItem, bool isExplain)
        {
            AnswerItem answerItem;
            if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.ContainsKey(_dataBEItem.QuestionID))
            {
                List<int> answerList;
                if (Singleton<AnswerSheetDataController>.Instance.AnswerSheet.TryGetValue(_dataBEItem.QuestionID, out answerList))
                {
                    if (answerList.Contains(int.Parse(dataItem.AnswerID)))
                    {
                        answerItem = new AnswerItem(dataItem, true);
                    }
                    else
                    {
                        answerItem = new AnswerItem(dataItem, false);
                    }
                }
                else
                {
                    answerItem = new AnswerItem(dataItem, false);
                }
            }
            else
            {
                answerItem = new AnswerItem(dataItem, false);
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
            answerItem.Size = new Size(tbListAnswerItem.Width, answerItem.Height);
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
