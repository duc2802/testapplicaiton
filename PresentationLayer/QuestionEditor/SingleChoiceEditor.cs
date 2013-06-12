using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;

namespace PresentationLayer.QuestionEditor
{
    public partial class SingleChoiceEditor : Form
    {
        public SingleChoiceEditor()
        {
            InitializeComponent();
            InitCommonGui();
        }

        private void InitCommonGui()
        {
            this.listBox1.AutoScroll = true;
            listBox1.SuspendLayout();
            for (int idx = 1; idx <= 6; idx++)
            {
                OptionItemCustom itemLayout = new OptionItemCustom();
                itemLayout.Location = new Point(ConstantGUI.PaddingGUI, (idx * ConstantGUI.PaddingGUI) + (itemLayout.Height * (idx - 1)));
                itemLayout.Size = new Size(listBox1.Width - (2 * ConstantGUI.PaddingGUI), itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                listBox1.Controls.Add(itemLayout);
            }
            listBox1.ResumeLayout();
        }
    }
}
