using System;
using System.Windows.Forms;
using PresentationLayer.ActionController;
using PresentationLayer.Explorer;
using PresentationLayer.QuestionEditor;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.Splash;
using SingleInstanceObject;

namespace PresentationLayer
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private WelcomeScreen _welcomeScreen;
        private bool done = false;

        public MainForm()
        {
            InitializeComponent();
            InitCommonGui();
            InitEvent();
            //DoSplash();
            this.Load += HandleFormLoad;
        }

        private void InitCommonGui()
        {
            ExplorerPanel catologuePanel = new ExplorerPanel();
            catologuePanel.Dock = DockStyle.Fill;
            this.explorerSplitContainer.Panel1.Controls.Add(catologuePanel);

            TestListPanel testListPanel = new TestListPanel();
            testListPanel.Dock = DockStyle.Fill;
            this.explorerSplitContainer.Panel2.Controls.Add(testListPanel);

            QuestionListPanel questionListPanel = new QuestionListPanel();
            this.mainSplitContainer.Panel2.Controls.Add(questionListPanel);
        }

        private void InitEvent()
        {
            InitButtonEvent();
        }

        private void InitButtonEvent()
        {
            this.btNewExam.Click += NewExamButtonClick;
            this.btNewQuestion.Click += NewQuestionButtonClick;
        }

        #region implement Event

        private void NewQuestionButtonClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to add more question.", "Add question", MessageBoxButtons.OK) == DialogResult.OK)
            {
                var dataItem = new QuestionDataItem();
                dataItem.ContentQuestion = "Which one of the five is least like the other four? " +
                                           "Which one of the five is least like the other four?" +
                                           "Which one of the five is least like the other four?" +
                                           "Which one of the five is least like the other four?" +
                                           "Which one of the five is least like the other four?" +
                                           "Which one of the five is least like the other four?";
                dataItem.IdQuestion = 0;
                dataItem.OrderQuestion = 14;
                var answerController = new AnswerDataController(14);
                for (int j = 1; j <= 5; j++)
                {
                    var answer = new AnswerDataItem();
                    answer.ContentAnswer = "Cat";
                    answer.OrderAnswer = j;
                    answerController.Add(answer);
                }
                dataItem.AnswerData = answerController;
                Singleton<GuiActionEventController>.Instance.OnAddQuestionItem(dataItem);
            }
        }

        private void NewExamButtonClick(object sender, EventArgs e)
        {

        }

        #endregion

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
    }
}
