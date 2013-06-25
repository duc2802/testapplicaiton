using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientPresentationLayer.QuestionPresentation.Data;
using BusinessEntities;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class AnswerItem : UserControl
    {
        private AnswerDataItem _dataItem;
        public AnswerDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.orderAnswer.ToString();
            }
            get { return _dataItem; }
        }

        private AnswerBE _dataBEItem;
        public AnswerBE DataBEItem
        {
            set
            {
                _dataBEItem = value;
                Name = _dataBEItem.AnswerID.ToString();
            }
            get { return _dataBEItem; }
        }

        public AnswerItem()
        {
            InitializeComponent();
        }

        public AnswerItem(AnswerDataItem dataItem)
        {
            DataItem = dataItem;
            InitializeComponent();
            InitGui();
        }

        public AnswerItem(AnswerBE dataItem)
        {
            DataBEItem = dataItem;
            InitializeComponent();
            InitGui(dataItem);
        }

        public void InitGui() 
        {
            orderAnswer.Text = DataItem.OrderAnswer.ToString();
            lbAnswerContent.Text = DataItem.ContentAnswer;
            btTrueFail.Visible = false;
        }
        public void InitGui(AnswerBE dataItem)
        {
            orderAnswer.Text = DataBEItem.AnswerID.ToString();
            lbAnswerContent.Text = DataBEItem.Content;
            btTrueFail.Visible = false;
        }

        private void AnswerItem_Load(object sender, EventArgs e)
        {

        }
    }
}
