using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientPresentationLayer.QuestionPresentation.Data;

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

        public void InitGui() 
        {
            orderAnswer.Text = DataItem.OrderAnswer.ToString();
            lbAnswerContent.Text = DataItem.ContentAnswer;
            btTrueFail.Visible = false;
        }

        private void AnswerItem_Load(object sender, EventArgs e)
        {

        }
    }
}
