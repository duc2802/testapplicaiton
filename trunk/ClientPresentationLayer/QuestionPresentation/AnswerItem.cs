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
        public bool isChosen =false;

        public bool IsChose
        {
            set
            {
                isChosen = value;
                
            }
            get { return isChosen; }
        }
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
            InitEvent();
        }

        public void InitEvent() 
        {
            cbAnswerItem.CheckedChanged += ComboBoxCheckChagedEvent;
        }

        private void ComboBoxCheckChagedEvent(object sender, EventArgs e)
        {
            if (cbAnswerItem.Checked == true)
                isChosen = true;
        }

        public void InitGui() 
        {
            orderAnswer.Text = (DataItem.OrderAnswer +1).ToString();
            lbAnswerContent.Text = DataItem.ContentAnswer;
            btTrueFail.Visible = false;
        }
        public void InitGui(AnswerBE dataItem)
        {
            orderAnswer.Text = (Int32.Parse(dataItem.AnswerID) +1).ToString();
            lbAnswerContent.Text = DataBEItem.Content;
            btTrueFail.Visible = false;
        }

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnswerItem.Checked)
            {
                _dataItem.isTrue = true;
                return;
            }
            _dataItem.isTrue = false;
        }
    }
}
