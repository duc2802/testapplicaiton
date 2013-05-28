using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            this.titleTextValue.Text = data.Title;
            this.dateTextValue.Text = data.DateCreate.ToString();
            this.noteTextValue.Text = "Comment here! ";
        }

        private void InitEvent()
        {
            this.GotFocus += ListTestItemCustomGotFocus;
            this.titleLabel.Click += ListTestItemCustomClick;
            this.titleTextValue.Click += ListTestItemCustomClick;
            this.dateTextValue.Click += ListTestItemCustomClick;
            this.noteTextValue.Click += ListTestItemCustomClick;
            this.Leave += ListTestItemCustomLeave;
        }

        #region Register Event
        private void ListTestItemCustomGotFocus(object sender, EventArgs e)
        {
            this.Focus();
            this.BackColor = Color.CadetBlue;
        }

        private void ListTestItemCustomClick(object sender, EventArgs e)
        {
            this.Focus();
            this.BackColor = Color.CadetBlue;
            Singleton<GuiActionEventController>.Instance.TestId = 1;
        }
        private void ListTestItemCustomLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        #endregion
    }
}
