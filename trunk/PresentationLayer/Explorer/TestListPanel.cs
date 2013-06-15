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