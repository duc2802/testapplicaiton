using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestCallEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            // _contentQuestionTextEditor.InsertImage();
            string editor = path + "\\" + "Editor.exe";

            Process p = new Process();
            p.StartInfo.FileName = editor;
            p.Start();
            string test = p.ProcessName;
            p.WaitForExit();
        }
    }
}
