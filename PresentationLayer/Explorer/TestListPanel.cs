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
    public partial class TestListPanel : UserControl
    {
        private TestListDataItemController _dataItemController = new TestListDataItemController();

        public TestListPanel()
        {
            InitializeComponent();
            InitCommonGui();
        }

        public void InitCommonGui()
        {
            
        }
    }
}
