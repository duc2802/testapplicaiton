using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using ClientPresentationLayer.Common;
using ClientPresentationLayer.QuestionPresentation.Data;
using Commons.BusinessObjects;
using SingleInstanceObject;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class TestManager : UserControl
    {
        private TestDataListViewItemController _dataController;
        private TestDataListViewItemController DataController
        {
            set
            {
                _dataController = value;
                OnChangeDataController();
            }
            get { return _dataController; }
        }

        public TestManager()
        {
            InitializeComponent();
            Init();
            InitGui();
            InitEvent();
        }

        private void Init()
        {
            DataController = new TestDataListViewItemController();
        }

        private void InitGui()
        {
            testlistView.Items.AddRange(DataController.DisplayItems.ToArray());
        }

        private void InitEvent()
        {
            testlistView.SelectedIndexChanged += TestlistViewSelectedIndexChanged;
            startExamButton.Click += StartExamButtonClick;
        }

        #region implement Event

        private void TestlistViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (testlistView.SelectedItems.Count == 0)
            {
                deleteButton.Enabled = false;
                startExamButton.Enabled = false;
                return;
            }
            var itemSelected = testlistView.SelectedItems[0];
            if(itemSelected != null)
            {
                Singleton<DataItemCollection>.Instance.TestItemDataSelected = TryGetDataItem(itemSelected.Tag.ToString());
                deleteButton.Enabled = true;
                startExamButton.Enabled = true;
            }
        }

        private void StartExamButtonClick(object sender, EventArgs e)
        {
            var testBe = Singleton<List<TestBE>>.Instance.FirstOrDefault(
                test => test.TestID.Equals(Singleton<DataItemCollection>.Instance.TestItemDataSelected.Id));
            Singleton<TestBE>.Instance = testBe;
            OnStartExam();
        }

        #endregion

        private TestDataListViewItem TryGetDataItem(string id)
        {
            return DataController.DataItems.FirstOrDefault(dataItem => dataItem.Id == id);
        }

        private void OnChangeDataController()
        {
            numOfExamTextBox.Text = DataController.DataItems.Count.ToString();
        }

        #region Register new event

        public event ActionEventHandler StartExam
        {
            add
            {
                lock (_startExamEventLocker)
                {
                    _startExamEvent += value;
                }
            }
            remove
            {
                lock (_startExamEventLocker)
                {
                    _startExamEvent -= value;
                }
            }
        }

        private ActionEventHandler _startExamEvent;
        private readonly object _startExamEventLocker = new object();

        private void OnStartExam()
        {
            ActionEventHandler handler = _startExamEvent;
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
