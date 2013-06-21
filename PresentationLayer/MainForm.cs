using System;
using System.Windows.Forms;
using PresentationLayer.ActionController;
using PresentationLayer.Explorer;
//using PresentationLayer.Export;
using PresentationLayer.QuestionEditor;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.ExamEditor;
using PresentationLayer.Splash;
using PresentationLayer.ThreadCmd;
using SingleInstanceObject;
using BusinessEntities;
using System.Collections.Generic;
using ThreadQueueManager;

namespace PresentationLayer
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private WelcomeScreen _welcomeScreen;
        private bool done = false;
        private TestDataItem _dataTestDataItem;

        public MainForm()
        {
            InitializeComponent();
            InitCommonGui();
            InitEvent();
            InitSingletonObject();
            //DoSplash();
        }

        private void InitCommonGui()
        {
            btExportExam.Enabled = false;
            btExportDocsExam.Enabled = false;
            btNewQuestion.Enabled = false;
            btEditQuestion.Enabled = false;

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
            Singleton<GuiActionEventController>.Instance.ChangeTestId += ChangeTestId;
            Singleton<GuiActionEventController>.Instance.ChangeLeaveTest += LeaveTest;
            Singleton<GuiActionEventController>.Instance.ChangeQuestionId += ChangeQuestionId;
            Singleton<GuiActionEventController>.Instance.ChangeLeaveQuestion += LeaveQuestion;

            Load += HandleFormLoad;
        }

        private void InitSingletonObject()
        {
            Singleton<GuiQueueThreadController>.Instance.InitializeThreadQueueController("GuiQueueThreadController");
        }

        private void LeaveTest(object sender, int parameter)
        {
            btExportExam.Enabled = false;
            btNewQuestion.Enabled = false;
            btExportDocsExam.Enabled = false;

        }

        private void LeaveQuestion(object sender, int parameter)
        {
            btEditQuestion.Enabled = false;

        }

        private void ChangeTestId(object sender, int parameter)
        {
            btExportExam.Enabled = true;
            btNewQuestion.Enabled = true;
            btExportDocsExam.Enabled = true;

        }

        private void ChangeQuestionId(object sender, int parameter)
        {
            btEditQuestion.Enabled = true;

        }

        private void InitButtonEvent()
        {
            this.btNewExam.Click += NewExamButtonClick;
            this.btNewQuestion.Click += NewQuestionButtonClick;
            this.btExportExam.Click += ButtonExportTestToXML;
            this.btOpenFile.Click += ButtonOpenFileClick;
            this.btExportDocsExam.Click += BtExportDocsExamOnClick;
        }

        private void BtExportDocsExamOnClick(object sender, EventArgs eventArgs)
        {
            //int testId = Singleton<GuiActionEventController>.Instance.TestId;
            //ExportForm exportForm = new ExportForm(testId + 1);
            //exportForm.ShowDialog();
        }

        #region implement Event

        private void ButtonOpenFileClick(object sender, EventArgs e)
        {
            if (openFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Singleton<GuiActionEventController>.Instance.OnChangeFolderId(openFolderBrowserDialog.SelectedPath);
            }
            
        }

        private void ButtonExportTestToXML(object sender, EventArgs e)
        {
            // Test data
            List<BusinessEntities.AnswerBE> la = new List<BusinessEntities.AnswerBE>();
            List<BusinessEntities.QuestionBE> lq = new List<BusinessEntities.QuestionBE>();

            BusinessEntities.AnswerBE ans = new BusinessEntities.AnswerBE();
            ans.AnswerID = "2";
            ans.Content = "content ans";
            ans.Result = "true";
            la.Add(ans);
            BusinessEntities.QuestionBE qs = new BusinessEntities.QuestionBE();
            qs.ListAnswers = la;
            qs.LevelQuestion = "c";
            qs.QuestionContent = "content question";
            qs.QuestionID = "5";
            lq.Add(qs);
            BusinessEntities.TestBE t = new BusinessEntities.TestBE();
            t.ListQuestion = lq;
            t.TestID = "4";

            // Export to XML
            TestBE testContent = new TestBE();

            saveTestToXmlFileDialog.Filter = "XML|*.xml";
            saveTestToXmlFileDialog.Title = "Export an Test File";
            saveTestToXmlFileDialog.ShowDialog();
            bool result = false;

            if (saveTestToXmlFileDialog.FileName != "")
            {
                String url = System.IO.Path.GetDirectoryName(saveTestToXmlFileDialog.FileName);
                TestApplication.TestBLL testMakeFile = new TestApplication.TestBLL();
                result = testMakeFile.exportTestXMLFile(t, saveTestToXmlFileDialog.FileName, url);
            }

            if (result == false)
            {
                MessageBox.Show(this, "Export Test error", "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(this, "Export Test OK", "Ok", MessageBoxButtons.OK);
            }
            
        }

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
            NewExam test = new NewExam();
            test.Show();
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

        private void btExportExam_Click(object sender, EventArgs e)
        {
            //ExportForm exForm = new ExportForm();
            //exForm.ShowDialog();
        }
    }
}
