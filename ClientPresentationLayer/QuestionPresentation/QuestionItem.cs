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
using SingleInstanceObject;
using BusinessEntities;
using System.Collections;
namespace ClientPresentationLayer
{
    public partial class QuestionItem : UserControl
    {
        private QuestionDataItem _dataItem;
        private QuestionBE _dataBEItem;
        private string PATH_FORDER_IMAGE = Singleton<SettingManager>.Instance.GetImageFolder();
        public bool isExplainStatus;
        public QuestionItem()
        {
            InitializeComponent();
        }
        public QuestionItem(QuestionDataItem Item)
        {
            InitializeComponent();
            InitGui(Item);
            InitEvent();
        }
        public QuestionItem(QuestionBE Item)
        {
            InitializeComponent();
            InitData(Item);
            InitGui(Item);
            InitEvent();
        }

        public QuestionItem(QuestionBE Item, Hashtable studenAnswerPrev)
        {
            InitializeComponent();
            InitData(Item);
            InitGui(Item,studenAnswerPrev);
            InitEvent();
        }
        public void InitEvent() 
        {
        }

        private void InitData(QuestionBE Item)
        {
            DataBEItem = Item;
        }
        
        public void InitGui(QuestionDataItem Item)
        {
            DataItem = Item;
            tbQuestionContent.Text = DataItem.ContentQuestion;
            if (DataItem.ImageName != null && DataItem.ImageName != "")
            {
                string newPath = PATH_FORDER_IMAGE + DataItem.ImageName;
                pictureBox.Image = new Bitmap(newPath);
                pictureBox.Show();
            }
            AddAnswerOptions();
        }
        public void InitGui(QuestionBE Item)
        {
            //DataItem = Item;
            tbQuestionContent.Text = DataBEItem.QuestionContent;
            if (DataBEItem.NameImage != null && DataBEItem.NameImage != "")
            {
                string newPath = PATH_FORDER_IMAGE + DataBEItem.NameImage;
                pictureBox.Image = new Bitmap(newPath);
                pictureBox.Show();
            }
            AddAnswerOptionsFromBE();
            ResumeLayout();
        }

        public void InitGui(QuestionBE Item,Hashtable studentAnswer)
        {
            //DataItem = Item;
            tbQuestionContent.Text = DataBEItem.QuestionContent;
            if (DataBEItem.NameImage != null && DataBEItem.NameImage != "")
            {
                string newPath = PATH_FORDER_IMAGE + DataBEItem.NameImage;
                pictureBox.Image = new Bitmap(newPath);
                pictureBox.Show();
            }
            AddAnswerOptionsFromBE();
            ResumeLayout();
        }

        private void QuestionItem_Load(object sender, EventArgs e)
        {

        }
        private void AddAnswerOptions()
        {
            foreach (AnswerDataItem answerItem in DataItem.AnswerData.AnswerData)
            {
                AddNewLine(answerItem);
            }
        }
        private void AddAnswerOptionsFromBE()
        {
            foreach (AnswerBE answerItem in DataBEItem.ListAnswers)
            {
                AddNewLine(answerItem);
            }
        }

        private void AddAnswerOptionsFromBE( Hashtable studentAnswer)
        {
            foreach (AnswerBE answerItem in DataBEItem.ListAnswers)
            {
                AddNewLine(answerItem);
            }
        }


        private void AddNewLine(AnswerDataItem item)
        {
            tbListAnswerItem.SuspendLayout();
            var answerItem = new AnswerItem();
            answerItem.Location = new Point(0, answerItem.Height);
            answerItem.Size = new Size(tbListAnswerItem.Width - 10, answerItem.Height);
            answerItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswerItem.Controls.Add(answerItem);
            tbListAnswerItem.ResumeLayout();
        }

        private void AddNewLine(AnswerBE item)
        {
            SuspendLayout();
            tbListAnswerItem.SuspendLayout();
            var answerItem = new AnswerItem(item);
            answerItem.Location = new Point(0, answerItem.Height);
            answerItem.CheckChange += CheckChangeOfAnswerItem;
            answerItem.Size = new Size(tbListAnswerItem.Width, answerItem.Height);
            answerItem.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswerItem.Controls.Add(answerItem);
            tbListAnswerItem.ResumeLayout();
            ResumeLayout();
        }

        private void CheckChangeOfAnswerItem(object sender, bool parameter)
        {
            MessageBox.Show("Hello");
            
        }

        public QuestionDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.IdQuestion.ToString();
            }
            get { return _dataItem; }
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
            DislayImageForm picture = new DislayImageForm(PATH_FORDER_IMAGE + pathImage);
            picture.ShowDialog();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            ShowImageofQuestion(DataItem.ImageName);
        }
    }
}
