using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.BusinessObjects;
using PresentationLayer.ThreadManager.GuiThread;
using SingleInstanceObject;
using ThreadQueueManager;

namespace PresentationLayer.Splash
{
    public partial class Loading : Form
    {
        readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        public Loading()
        {
            InitializeComponent();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        private string testId;
        public void Run(string testID)
        {
            testId = testID;
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ICommand command = new LoadQuestionCmd(ExecuteMethod.Sync, testId);
            Singleton<GuiQueueThreadController>.Instance.PutCmd(command);
        }
       

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}
