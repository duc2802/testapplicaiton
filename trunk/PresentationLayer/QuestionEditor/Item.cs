using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Commons;
using Commons.BusinessObjects;
using System.Windows.Forms;
using PresentationLayer.QuestionEditor.Data;

namespace PresentationLayer.QuestionEditor
{
    public partial class Item : UserControl
    {
        private AnswerDataItem _dataItem;
        public AnswerDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.orderAnswer.ToString();
                OnDataItemChanged();
            }
            get { return _dataItem; }
        }


        public Item(int index)
        {
            InitializeComponent();
            InitEvent();
            InitData(index);
        }
        public Item(AnswerDataItem item, int index)
        {
            InitializeComponent();
            InitEvent();
            InitCommonGui(item,index);
            //InitData();
        }
        private void InitEvent() 
        {
            btDelete.Click += DeleteAnswerButtonClick;
            Leave += ItemLeave;
            cbTrue.CheckedChanged += cbTrue_CheckedChanged;
        }

        private void ItemLeave(object sender, EventArgs e)
        {
            _dataItem.ContentAnswer = tbAnswerContent.Text;
        }

        private void InitData(int index)
        {
            _dataItem = new AnswerDataItem();
            this.orderAnswer.Text = index.ToString();
            DataItem = _dataItem;
            DataItem.PropertyChanged += DataItemPropertyChanged;
            this.Refresh();
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

        private void InitCommonGui(AnswerDataItem item,int index)
        {
            if (item != null)
            {
                DataItem = item;
                DataItem.PropertyChanged += DataItemPropertyChanged;
            }

            this.orderAnswer.Text = index.ToString();
            if (item != null)
            {
                this.tbAnswerContent.Text = item.ContentAnswer;
                if (item.isTrue == true)
                    this.cbTrue.Checked = true;
            }
            this.Refresh();
            
        }

        private void DataItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionEventHandler<PropertyChangedEventArgs>(DataItemPropertyChanged), sender, e);
                return;
            }
            if (e.PropertyName.Equals("OrderAnswer"))
            {
                orderAnswer.Text = DataItem.orderAnswer.ToString();
            }
            else if (true)
            {

            }
            OnUpdate(DataItem.orderAnswer);
        }

        private ActionEventHandler<int> _updateEvent;
        private readonly object _updateEventLocker = new object();

        private void OnUpdate(int idQuestion)
        {
            ActionEventHandler<int> handler = _updateEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idQuestion);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        private void OnDataItemChanged()
        {

            tbAnswerContent.Text = DataItem.ContentAnswer;
            orderAnswer.Text = DataItem.orderAnswer.ToString();
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

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrue.Checked)
            {
                DataItem.isTrue = true;
                _dataItem.isTrue = true;
            }
            else {
                DataItem.isTrue = false;
                _dataItem.isTrue = false;
            }

            OnCheckChange(DataItem.orderAnswer, DataItem.isTrue);  
        }

        private void tbAnswerContent_TextChanged(object sender, EventArgs e)
        {
            //_dataItem.ContentAnswer = tbAnswerContent.Text;
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
