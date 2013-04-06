using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TestApplication;

namespace PresentationLayer
{
    public partial class Main : Form
    {
        private  WelcomeScreen welcomeScreen;
        private bool done = false;

        public Main()
        {
            InitializeComponent();
            this.Load += new EventHandler(HandleFormLoad);
            this.welcomeScreen = new WelcomeScreen();
        }

        // WelcomeScreen controler
        private void HandleFormLoad(object sender, EventArgs e)
        {
            this.Hide();

            Thread thread = new Thread(new ThreadStart(this.ShowSplashScreen));
            thread.Start();

            Hardworker worker = new Hardworker();
            worker.ProgressChanged += (o, ex) =>
            {
                this.welcomeScreen.UpdateProgress(ex.Progress);
            };

            worker.HardWorkDone += (o, ex) =>
            {
                done = true;
                this.Show();
            };

            worker.DoHardWork();
        }



        private void ShowSplashScreen()
        {
            welcomeScreen.Show();
            while (!done)
            {
                Application.DoEvents();
            }
            welcomeScreen.Close();
            this.welcomeScreen.Dispose();
        }

    }
}
