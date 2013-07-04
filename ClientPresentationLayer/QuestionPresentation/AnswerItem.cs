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
using Commons.BusinessObjects;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class AnswerItem : UserControl
    {
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

        public AnswerItem()
        {
            InitializeComponent();
        }

        public AnswerItem(AnswerBE dataItem, bool isChoise)
        {
            DataBEItem = dataItem;
            InitializeComponent();
            InitGui(dataItem, isChoise);
            InitEvent();
        }

        public void InitEvent() 
        {
            answerItemCheckBox.CheckedChanged += CheckChangedEvent;
        }

        private void CheckChangedEvent(object sender, EventArgs e)
        {
            IsChoise = answerItemCheckBox.Checked;
            OnCheckChange(OrderAnswer, IsChoise);
        }

        public void InitGui(AnswerBE dataItem, bool isChoise)
        {
            orderAnswer.Text = (int.Parse(dataItem.AnswerID) +1).ToString();
            lbAnswerContent.Text = DataBEItem.Content;
            btTrueFail.Visible = false;
            if(isChoise)
            {
                answerItemCheckBox.Checked = isChoise;
            }
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
