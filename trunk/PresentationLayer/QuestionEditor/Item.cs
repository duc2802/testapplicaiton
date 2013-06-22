﻿using System;
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
      

        public Item()
        {
            InitializeComponent();
            InitEvent();
        }
        public Item(AnswerDataItem item, int index)
        {
            InitializeComponent();
            InitEvent();
            InitCommonGui(item,index);
        }
        private void InitEvent() 
        {
            btDelete.Click += DeleteAnswerButtonClick;
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
            if(cbTrue.Checked)
            {
                _dataItem.isTrue = true;
                return;
            }
            _dataItem.isTrue = false;
        }

        private void tbAnswerContent_TextChanged(object sender, EventArgs e)
        {
            _dataItem.ContentAnswer = tbAnswerContent.Text;
        }



    }
}