using System;
using System.Windows.Forms;
using PresentationLayer.Splash;

namespace PresentationLayer
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private WelcomeScreen _welcomeScreen;
        private bool done = false;

        public MainForm()
        {
            InitializeComponent();
            //DoSplash();
            this.Load += HandleFormLoad;
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
            _welcomeScreen = new WelcomeScreen();
            _welcomeScreen.Show();
            while (!done)
            {
                Application.DoEvents();
            }
            _welcomeScreen.Close();
            this._welcomeScreen.Dispose();
        }

        private void CloseSplash()
        {
            _welcomeScreen.Close();
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void Test_Click(object sender, EventArgs e)
        {

        }
    }
}
