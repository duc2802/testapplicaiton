using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PresentationLayer.Category;
using PresentationLayer.Splash;
using TestApplication;
using WeifenLuo.WinFormsUI.Docking;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        private WelcomeScreen welcomeScreen;
        private bool done = false;

        public MainForm()
        {
            InitializeComponent();
            //DoSplash();
            this.Load += new EventHandler(HandleFormLoad);
        }

        // WelcomeScreen controler
        private void HandleFormLoad(object sender, EventArgs e)
        {
            //this.Hide();

            //Thread thread = new Thread(new ThreadStart(this.DoSplash));
            //thread.Start();

            //Hardworker worker = new Hardworker();
            //worker.ProgressChanged += (o, ex) =>
            //{
            //    this.welcomeScreen.UpdateProgress(ex.Progress);
            //};

            //worker.HardWorkDone += (o, ex) =>
            //{
            //    done = true;
            //    this.Show();
            //};

            //worker.DoHardWork();

            //CloseSplash();
        }

        private void DoSplash()
        {
            welcomeScreen = new WelcomeScreen();
            welcomeScreen.Show();
            while (!done)
            {
                Application.DoEvents();
            }
            welcomeScreen.Close();
            this.welcomeScreen.Dispose();
        }

        private void CloseSplash()
        {
            welcomeScreen.Close();
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryExplorer category = new CategoryExplorer();
            category.Show(dockPanel, DockState.Float);
        }
    }
}
