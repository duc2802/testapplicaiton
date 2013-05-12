using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.CommonGui
{
    public partial class InputDialog : Form
    {
        private string _inputText;

        public string ResultText
        {
            get { return _inputText; }
            private set { _inputText = value; }
        }

        public InputDialog(string title, string labelText, string textboxString)
        {
            InitializeComponent();
            this.Text = title;
            this.lblInput.Text = labelText;
            this.txtInput.Text = textboxString;
        }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void TxtInputTextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text.Trim().Length > 0)
            {
                btnOk.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            ResultText = txtInput.Text.Trim();
        }
    }
}
