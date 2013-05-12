using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            this.titleLabel.Click += ListTestItemCustomGotFocus;
            this.titleTextValue.Click += ListTestItemCustomGotFocus;
            this.dateTextValue.Click += ListTestItemCustomGotFocus;
            this.noteTextValue.Click += ListTestItemCustomGotFocus;
            this.Leave += ListTestItemCustomLeave;
        }
        #region Register Event
        private void ListTestItemCustomGotFocus(object sender, EventArgs e)
        {
            this.Focus();
            this.BackColor = Color.CadetBlue;
        }
        private void ListTestItemCustomLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        #endregion
    }
}
