using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using BusinessEntities;
using ClientPresentationLayer.Common;
using ClientPresentationLayer.QuestionPresentation.Data;
using Commons.BusinessObjects;
using DataAccessLayer;
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
            importButton.Click += ImportButtonClick;
        }

        private void RefreshGui()
        {
            testlistView.Items.Clear();
            testlistView.Items.AddRange(DataController.DisplayItems.ToArray());
        }
        
        #region implement Event

        private void ImportButtonClick(object sender, EventArgs e)
        {
            using(var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Exam File|*.exb";
                openDialog.Title = "Import an Test File";
                if(DialogResult.OK == openDialog.ShowDialog())
                {
                    string file = openDialog.FileName;
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        using (var cfs = new GZipStream(fs, CompressionMode.Decompress))
                        {
                            var serializerObject = new XmlSerializer(typeof(TestBE));
                            var testBe = (TestBE)serializerObject.Deserialize(cfs);

                            //Add to data controller.
                            DataController.DataItems.Add(new TestDataListViewItem(testBe));
                            //writer to client data folder.
                            XmlHelper.WriteExamClientFile(testBe, testBe.TestID);
                            RefreshGui();
                        }
                    }
                }
            }
        }

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
            var testBe = TryLoadTestBE(Singleton<DataItemCollection>.Instance.TestItemDataSelected.Id);
            if(testBe != null)
            {
                Singleton<TestBE>.Instance = testBe;
                Singleton<AnswerSheetDataController>.Instance.TestId = testBe.TestID;
                OnStartExam();
            }
            else
            {
                MessageBox.Show(this, "This exam maybe delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TestBE TryLoadTestBE(string id)
        {
            var test = TestDAL.LoadTestBEClient(id);
            return test;
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
