﻿using System;
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

        private void InitEvent()
        {
            
        }

        private void InitCommonGui()
        {
            //Init list from dataItemController.
            testListBox.SuspendLayout();
            int[] keys = _dataItemController.TestBook.Keys.ToArray();
            for(int idx = 0; idx < keys.Count(); idx++)
            {
                TestDataItem itemData = _dataItemController.TestBook[idx];
                TestListItemCustom itemLayout = new TestListItemCustom(itemData);
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(testListBox.Width - 20, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                testListBox.Controls.Add(itemLayout);
            }
            testListBox.ResumeLayout();
        }
    }
}
