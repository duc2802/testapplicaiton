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
    public partial class DislayImageForm : Form
    {
        public DislayImageForm()
        {
            InitializeComponent();

        }
        public DislayImageForm(string path)
        {
            Image test = Image.FromFile(path);
            this.Width = test.Width;
            this.Height = test.Height;
            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = test;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox);
            this.Refresh();
        }
    }
}
