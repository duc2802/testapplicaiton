﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Commons;
using PresentationLayer.ActionController;
using PresentationLayer.ThreadManager.GuiThread;
using SingleInstanceObject;
using Commons;
using Commons.BusinessObjects;
using ThreadQueueManager;

namespace PresentationLayer.Explorer
{
    public partial class TestListItemCustom : UserControl
    {
        public static int WIDTH = 237;
        public static int HEIGHT = 47;
        private TestDataItem _dataItem;

        public TestDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.IdTest.ToString();
                //OnDataItemChanged();
            }
            get { return _dataItem; }
        }

        public TestListItemCustom()
        {
            InitializeComponent();
            InitEvent();
        }

        public TestListItemCustom(TestDataItem data)
        {
            InitializeComponent();
            InitGui(data);
            InitEvent();
        }

        private void InitGui(TestDataItem data)
        {
            SuspendLayout();
            DataItem = data;
            lbNameExam.Text = data.Name;
            dateTextValue.Text = data.DateCreate.ToString();
            lbNumberQuestion.Text = "Comment here! ";
            ResumeLayout();
        }

        private void InitEvent()
        {
            //Event 
            GotFocus += ListTestItemCustomGotFocus;
            Leave += ListTestItemCustomLeave;
            Click += ListTestItemCustomClick;
            deleteButton.Click += DeleteButtonClick;

            //Component Event.
            titleLabel.Click += ListTestItemCustomClick;
            lbNameExam.Click += ListTestItemCustomClick;
            dateTextValue.Click += ListTestItemCustomClick;
            lbNumberQuestion.Click += ListTestItemCustomClick;

        }

        #region Register Event


        private void DeleteButtonClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Do you want to delete this Test?", "Delete question.",
                                         MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                OnDelete(this.DataItem.IdTest);
            }
        }

        private void ListTestItemCustomGotFocus(object sender, EventArgs e)
        {
            Focus();
            BackColor = ConstantGUI.FocusColor;
        }

        private void ListTestItemCustomClick(object sender, EventArgs e)
        {
            SuspendLayout();
            Focus();
            BackColor = ConstantGUI.FocusColor;
            Refresh();
            ResumeLayout();

            string testId = DataItem.IdTest;
            ICommand command = new LoadQuestionCmd(ExecuteMethod.Async, testId);
            Singleton<GuiQueueThreadController>.Instance.PutCmd(command);
        }

        private void ListTestItemCustomLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
            //Singleton<GuiActionEventController>.Instance.LeaveTest = 1;
        }

        #endregion

        #region Trigger Event
        public event ActionEventHandler<string> Delete
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

        private ActionEventHandler<string> _deleteEvent;
        private readonly object _deleteEventLocker = new object();

        private void OnDelete(string idTest)
        {
            ActionEventHandler<string> handler = _deleteEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idTest);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        public event ActionEventHandler<int> Update
        {
            add
            {
                lock (_updateEventLocker)
                {
                    _updateEvent += value;
                }
            }
            remove
            {
                lock (_updateEventLocker)
                {
                    _updateEvent -= value;
                }
            }
        }

        private ActionEventHandler<int> _updateEvent;
        private readonly object _updateEventLocker = new object();

        private void OnUpdate(int idTest)
        {
            ActionEventHandler<int> handler = _updateEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idTest);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }
        #endregion

    }
}