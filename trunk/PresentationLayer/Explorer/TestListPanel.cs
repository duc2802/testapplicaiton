using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessEntities;
using PresentationLayer.ActionController;
using PresentationLayer.Explorer.Data;
using PresentationLayer.ThreadManager.DataThread;
using SingleInstanceObject;
using ThreadQueueManager;

namespace PresentationLayer.Explorer
{
    public partial class TestListPanel : UserControl
    {
        private readonly TestListDataItemController _dataItemController = new TestListDataItemController();

        public TestListPanel()
        {
            InitializeComponent();
            InitCommonGui();
            InitEvent();
        }

        private void InitEvent()
        {
            Singleton<GuiActionEventController>.Instance.ChangeFolderId += ChangeFolderId;
            Singleton<GuiActionEventController>.Instance.AddTestItem += OnAddTestItem;
            Singleton<GuiActionEventController>.Instance.ClearAllTestItem += ClearAllTestItem;
        }

        private void ClearAllTestItem(object sender)
        {
            testListBox.SuspendLayout();
            _dataItemController.TestBook.Clear();
            testListBox.Controls.Clear();
            testListBox.ResumeLayout(true);
        }

        private void OnAddTestItem(object sender, TestDataItem parameter)
        {
            int idx = testListBox.Controls.Count;
            parameter.IdTest = parameter.IdTest;
            testListBox.SuspendLayout();
            _dataItemController.TestBook.Add(idx.ToString(),parameter);
            AddTestItem(parameter, idx + 1);
            testListBox.ResumeLayout(true);
        }

        private void AddTestItem(TestDataItem testData, int idx)
        {
            testListBox.SuspendLayout();
            TestListItemCustom testItem = CreateTestItem(testData);
            testItem.DataItem.IdTest = testData.IdTest;
            var style = new RowStyle(SizeType.AutoSize);
            testListBox.RowStyles.Add(style);
            testListBox.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
            testListBox.Controls.Add(testItem, 0, idx);
            testListBox.ResumeLayout(false);
        }
        private TestListItemCustom CreateTestItem(TestDataItem testData)
        {
            var itemLayout = new TestListItemCustom(testData);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Update += ItemLayoutUpdate;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return itemLayout;
        }

        private void ItemLayoutUpdate(object sender, int parameter)
        {
            UpdateTestItem(parameter);
        }

        private void UpdateTestItem(int idTest)
        {
            var item = testListBox.Controls.Find(idTest.ToString(), true).First() as TestListItemCustom;
            if (item != null)
            {
                item.Refresh();
                testListBox.Refresh();
            }
            else
            {
                MessageBox.Show(this, "Update Error", "Error", MessageBoxButtons.OK);
            }
        }

        private void ItemLayoutDelete(object sender, string parameter)
        {
            DeleteTestItem(parameter);
        }

        private void DeleteTestItem(string idTest)
        {
            testListBox.SuspendLayout();
            testListBox.Controls.RemoveAt(0);
            _dataItemController.TestBook.Remove(idTest);
            UpdateAllDataItem();
            testListBox.ResumeLayout();
            Refresh();
            Singleton<GuiActionEventController>.Instance.OnClearAllQuestionItem();

            var testBE = Singleton<List<TestBE>>.Instance.FirstOrDefault(test => test.TestID.Equals(idTest));
            ICommand command = new DeleteTestCmd(ExecuteMethod.Async, testBE);
            Singleton<DataQueueThreadController>.Instance.PutCmd(command);
        }

        private void UpdateAllDataItem()
        {
            for (int idx = 0; idx < testListBox.Controls.Count; idx++)
            {
                var item = testListBox.Controls[idx] as TestListItemCustom;
                if (item != null)
                {
                    //item.DataItem. = idx + 1;
                }
            }
            testListBox.Refresh();
        }

        private void UpdateGui(string idFolder)
        {
            headingButton.Text = idFolder;
            FillTestItem(idFolder);
        }

        private void InitCommonGui()
        {
            //Init list from dataItemController.
            FillTestItem("Data");
        }

        private void FillQuestionItem()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;
            testListBox.RowStyles.Clear();
            testListBox.AutoSize = true;
            testListBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            for (int idx = 0; idx < _dataItemController.TestBook.Count; idx++)
            {
                AddTestItem(_dataItemController.TestBook[idx.ToString()], idx + 1);
            }
        }

        private TestListItemCustom CreateQuestionItem(TestDataItem TestData)
        {
            var itemLayout = new TestListItemCustom(TestData);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Update += ItemLayoutUpdate;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return itemLayout;
        }

        private void FillTestItem(string idFolder)
        {
            SuspendLayout();
            testListBox.SuspendLayout();
            testListBox.Controls.Clear();

            LoadTestDataItemController(idFolder);

            string[] keys = _dataItemController.TestBook.Keys.ToArray();

            int idx = 0;
            foreach (string key in keys)
            {
                TestDataItem itemData = _dataItemController.TestBook[key];
                var itemLayout = new TestListItemCustom(itemData);
                itemLayout.Delete += ItemLayoutDelete;
                itemLayout.Update += ItemLayoutUpdate;
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(testListBox.Width - 20, itemLayout.Height);
                itemLayout.Anchor = (((AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)));
                testListBox.Controls.Add(itemLayout);
                idx++;
            }
            testListBox.ResumeLayout();
            ResumeLayout();
        }

        private void LoadTestDataItemController(string idFolder)
        {
            _dataItemController.LoadTestDataItem(idFolder);
        }

        #region Implement registed event.

        private void ChangeFolderId(object sender, string parameter)
        {
            UpdateGui(parameter);
        }

        #endregion
    }
}