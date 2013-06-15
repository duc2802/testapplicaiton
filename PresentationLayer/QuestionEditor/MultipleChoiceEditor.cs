using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer.QuestionEditor
{
    public partial class MultipleChoiceEditor : Form
    {
        public MultipleChoiceEditor()
        {
            InitializeComponent();
            InitCommonGui();
        }
        private void InitCommonGui()
        {
            tbListAnswer.SuspendLayout();
            for (int idx = 0; idx < 2; idx++)
            {
                Item itemLayout = new Item();
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                tbListAnswer.Controls.Add(itemLayout);
            }
            tbListAnswer.ResumeLayout();
           
        }

        private void tbQuestionContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            opFileChoseImage.ShowDialog();
            opFileChoseImage.InitialDirectory = @"C:\";
            if (opFileChoseImage.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "" + opFileChoseImage.FileName + "";
            }
        }

        private void MultipleChoiceEditor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btMoreAnswer_Click(object sender, EventArgs e)
        {
            tbListAnswer.SuspendLayout();
            Item itemLayout = new Item();
            itemLayout.Location = new Point(0, itemLayout.Height);
            itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
            itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswer.Controls.Add(itemLayout);
            tbListAnswer.ResumeLayout();

        }
    }
}
