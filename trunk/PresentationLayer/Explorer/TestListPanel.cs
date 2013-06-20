using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PresentationLayer.ActionController;
using SingleInstanceObject;

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
            //Singleton<GuiActionEventController>.Instance.ChangeTestId += ChangeTestId;
            Singleton<GuiActionEventController>.Instance.AddTestItem += OnAddTestItem;

            //Singleton<GuiActionEventController>.Instance.ClearAllQuestionItem += ClearAllQuestionItem;

            //questionPanel.DragDrop += QuestionPanelDragDrop;
           // questionPanel.DragOver += QuestionPanelDragOver;
           // questionPanel.DragEnter += QuestionPanelDragEnter;
        }

        private void OnAddTestItem(object sender, TestDataItem parameter)
        {
            int idx = testListBox.Controls.Count +1;
            testListBox.SuspendLayout();

            _dataItemController.TestBook.Add(idx.ToString(),parameter);
            AddTestItem(parameter, idx + 1);
            testListBox.ResumeLayout(true);
        }

        private void AddTestItem(TestDataItem testData, int idx)
        {
            testListBox.SuspendLayout();
            TestListItemCustom answerItem = CreateTestItem(testData);
           // questionItem.DataItem.OrderQuestion = idx;
            var style = new RowStyle(SizeType.AutoSize);
            testListBox.RowStyles.Add(style);
            testListBox.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
            testListBox.Controls.Add(answerItem, 0, idx);
            testListBox.ResumeLayout(false);
        }
        private TestListItemCustom CreateTestItem(TestDataItem testData)
        {
            var itemLayout = new TestListItemCustom(testData);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Update += ItemLayoutUpdate;
            //itemLayout.MouseDown += ItemLayoutMouseDown;
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

        private void ItemLayoutDelete(object sender, int parameter)
        {
            DeleteTestItem(parameter);
        }

        private void DeleteTestItem(int idTest)
        {
            testListBox.SuspendLayout();
            var item = testListBox.Controls.Find(idTest.ToString(), true).First() as TestListItemCustom;
            if (item != null)
            {
                int idx = testListBox.Controls.IndexOf(item);
                testListBox.Controls.Remove(item);
                testListBox.RowStyles.RemoveAt(idx);
                testListBox.Refresh();
            }
            else
            {
                MessageBox.Show(this, "Delete Error", "Error", MessageBoxButtons.OK);
            }
            UpdateAllDataItem();
            testListBox.ResumeLayout();
            Refresh();
        }

        private void UpdateAllDataItem()
        {
            for (int idx = 0; idx < testListBox.Controls.Count; idx++)
            {
                var item = testListBox.Controls[idx] as TestListItemCustom;
                if (item != null)
                {
                    item.DataItem.IdTest = idx + 1;
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
           // itemLayout.MouseDown += ItemLayoutMouseDown;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return itemLayout;
        }

        private void FillTestItem(string idFolder)
        {
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