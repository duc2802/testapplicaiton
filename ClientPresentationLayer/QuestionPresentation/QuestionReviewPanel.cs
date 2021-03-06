﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientPresentationLayer.QuestionPresentation.Data;
using Commons.BusinessObjects;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionReviewPanel : UserControl
    {
        private QuestionDataListViewItemController _dataController;

        private QuestionDataListViewItemController DataController
        {
            set
            {
                _dataController = value;
                //OnChangeDataController();
            }
            get { return _dataController; }
        }

        public QuestionReviewPanel()
        {
            InitializeComponent();
            Init();
            InitGui();
            InitEvent();
        }

        public void Init()
        {
            DataController = new QuestionDataListViewItemController();
        }

        public void InitGui()
        {
            questionlistView.Items.AddRange(DataController.DisplayItems.ToArray());
        }

        public void InitEvent()
        {
            questionlistView.DoubleClick += QuestionlistViewClick;
            backButton.Click += BackButtonClick;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            OnBackTestManager();
        }

        private void QuestionlistViewClick(object sender, EventArgs e)
        {
            var itemSelected = questionlistView.SelectedIndices;
            var idQuestion = itemSelected[0];
            OnReviewQuestion(idQuestion);
        }

        public void RefreshGui()
        {
            DataController.DataItems.Clear();
            questionlistView.Items.Clear();
            DataController.FillQuestioinDataListViewItem();
            totalTextBox.Text = DataController.DataItems.Count.ToString();
            attemptedTextBox.Text = DataController.NumOfAttempted.ToString();
            markedTextBox.Text = DataController.NumOfMarked.ToString();
            questionlistView.Items.AddRange(DataController.DisplayItems.ToArray());
        }

        public event ActionEventHandler<int> ReviewQuestion
        {
            add
            {
                lock (__reviewQuestionEventLocker)
                {
                    _reviewQuestionEvent += value;
                }
            }
            remove
            {
                lock (__reviewQuestionEventLocker)
                {
                    _reviewQuestionEvent -= value;
                }
            }
        }

        private ActionEventHandler<int> _reviewQuestionEvent;
        private readonly object __reviewQuestionEventLocker = new object();

        private void OnReviewQuestion(int idx)
        {
            ActionEventHandler<int> handler = _reviewQuestionEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idx);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #region Register new event

        public event ActionEventHandler BackTestManager
        {
            add
            {
                lock (_backTestManagerEventLocker)
                {
                    _backTestManagerEvent += value;
                }
            }
            remove
            {
                lock (_backTestManagerEventLocker)
                {
                    _backTestManagerEvent -= value;
                }
            }
        }

        private ActionEventHandler _backTestManagerEvent;
        private readonly object _backTestManagerEventLocker = new object();

        private void OnBackTestManager()
        {
            ActionEventHandler handler = _backTestManagerEvent;
            if (handler != null)
            {
                try
                {
                    handler(this);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion End register new event
    }
}
