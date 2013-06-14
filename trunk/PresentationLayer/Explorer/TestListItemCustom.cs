using System;
using System.Drawing;
using System.Windows.Forms;
using Commons;
using PresentationLayer.ActionController;
using SingleInstanceObject;

namespace PresentationLayer.Explorer
{
    public partial class TestListItemCustom : UserControl
    {
        public static int WIDTH = 237;
        public static int HEIGHT = 47;

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
            titleTextValue.Text = data.Title;
            dateTextValue.Text = data.DateCreate.ToString();
            noteTextValue.Text = "Comment here! ";
        }

        private void InitEvent()
        {
            GotFocus += ListTestItemCustomGotFocus;
            titleLabel.Click += ListTestItemCustomClick;
            titleTextValue.Click += ListTestItemCustomClick;
            dateTextValue.Click += ListTestItemCustomClick;
            noteTextValue.Click += ListTestItemCustomClick;
            Leave += ListTestItemCustomLeave;
        }

        #region Register Event

        private void ListTestItemCustomGotFocus(object sender, EventArgs e)
        {
            Focus();
            BackColor = ConstantGUI.FocusColor;
        }

        private void ListTestItemCustomClick(object sender, EventArgs e)
        {
            Focus();
            BackColor = ConstantGUI.FocusColor;
            Singleton<GuiActionEventController>.Instance.TestId = 1;
        }

        private void ListTestItemCustomLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        #endregion
    }
}