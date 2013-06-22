using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BusinessEntities;
using DevComponents.DotNetBar;
using PresentationLayer.ActionController;
using PresentationLayer.ExamEditor;
using PresentationLayer.Explorer;
using PresentationLayer.Explorer.Data;
using PresentationLayer.QuestionEditor;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.Splash;
using PresentationLayer.ThreadManager.DataThread;
using PresentationLayer.ThreadManager.GuiThread;
using SingleInstanceObject;
using TestApplication;
//using PresentationLayer.Export;

namespace PresentationLayer
{
    public partial class MainForm : Office2007RibbonForm
    {
        private TestDataItem _dataTestDataItem;
        private WelcomeScreen _welcomeScreen;
        private bool done = false;

        public MainForm()
        {
            InitializeComponent();
            InitData();
            InitCommonGui();
            InitEvent();
            InitSingletonObject();
        }

        private void InitData()
        {
            //DoSplash();
            Singleton<GuiActionEventController>.Instance.FolderId = "Data";
        }

        private void InitCommonGui()
        {
            btExportExam.Enabled = false;
            exportDocsExamButton.Enabled = false;
            btNewQuestion.Enabled = false;
            btEditQuestion.Enabled = false;

            var catologuePanel = new ExplorerPanel();
            catologuePanel.Dock = DockStyle.Fill;
            explorerSplitContainer.Panel1.Controls.Add(catologuePanel);

            var testListPanel = new TestListPanel();
            testListPanel.Dock = DockStyle.Fill;
            explorerSplitContainer.Panel2.Controls.Add(testListPanel);

            var questionListPanel = new QuestionListPanel();
            mainSplitContainer.Panel2.Controls.Add(questionListPanel);
        }

        private void InitEvent()
        {
            InitButtonEvent();

            Singleton<GuiActionEventController>.Instance.ChangeTestId += ChangeTestId;
            Singleton<GuiActionEventController>.Instance.ChangeLeaveTest += LeaveTest;
            Singleton<GuiActionEventController>.Instance.ChangeQuestionId += ChangeQuestionId;
            Singleton<GuiActionEventController>.Instance.ChangeLeaveQuestion += LeaveQuestion;

            Load += HandleFormLoad;
            explorerSplitContainer.SplitterMoved += ExplorerSplitContainerMoved;
            mainSplitContainer.SplitterMoved += MainSplitContainerMoved;
        }
        
        private void InitSingletonObject()
        {
            Singleton<GuiQueueThreadController>.Instance.InitializeThreadQueueController("GuiQueueThreadController");
            Singleton<DataQueueThreadController>.Instance.InitializeThreadQueueController("DataQueueThreadController");
        }

        private void LeaveTest(object sender, string parameter)
        {
            btExportExam.Enabled = false;
            btNewQuestion.Enabled = false;
            exportDocsExamButton.Enabled = false;
        }

        private void LeaveQuestion(object sender, int parameter)
        {
            btEditQuestion.Enabled = false;
        }

        private void ChangeTestId(object sender, string parameter)
        {
            btExportExam.Enabled = true;
            btNewQuestion.Enabled = true;
            exportDocsExamButton.Enabled = true;
        }

        private void ChangeQuestionId(object sender, int parameter)
        {
            btEditQuestion.Enabled = true;
        }

        private void InitButtonEvent()
        {
            btNewExam.Click += NewExamButtonClick;
            btNewQuestion.Click += NewQuestionButtonClick;
            btExportExam.Click += ButtonExportTestToXML;
            openFileButton.Click += ButtonOpenFileButtonClick;
            exportDocsExamButton.Click += ExportDocsExamButtonButtonClick;
        }

        private void ExportDocsExamButtonButtonClick(object sender, EventArgs eventArgs)
        {
            //int testId = Singleton<GuiActionEventController>.Instance.FolderId;
            //ExportForm exportForm = new ExportForm(testId + 1);
            //exportForm.ShowDialog();
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
            _welcomeScreen.Dispose();
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

        #region implement Event

        private void MainSplitContainerMoved(object sender, SplitterEventArgs e)
        {
            if (mainSplitContainer.SplitterDistance > 520 || mainSplitContainer.SplitterDistance < 500)
            {
                mainSplitContainer.SplitterDistance = 520;
            }
        }

        private void ExplorerSplitContainerMoved(object sender, SplitterEventArgs e)
        {
            if (explorerSplitContainer.SplitterDistance > 150 || explorerSplitContainer.SplitterDistance < 100)
            {
                explorerSplitContainer.SplitterDistance = 150;
            }
        }

        private void ButtonOpenFileButtonClick(object sender, EventArgs e)
        {
            if (openFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Singleton<GuiActionEventController>.Instance.OnChangeFolderId(openFolderBrowserDialog.SelectedPath);
            }
        }

        private void ButtonExportTestToXML(object sender, EventArgs e)
        {
            var la = new List<AnswerBE>();
            var lq = new List<QuestionBE>();

            var ans = new AnswerBE();
            ans.AnswerID = "2";
            ans.Content = "content ans";
            ans.Result = "true";
            la.Add(ans);
            var qs = new QuestionBE();
            qs.ListAnswers = la;
            qs.LevelQuestion = "c";
            qs.QuestionContent = "content question";
            qs.QuestionID = "5";
            lq.Add(qs);
            var t = new TestBE();
            t.ListQuestion = lq;
            t.TestID = "4";

            // Export to XML
            var testContent = new TestBE();

            saveTestToXmlFileDialog.Filter = "XML|*.xml";
            saveTestToXmlFileDialog.Title = "Export an Test File";
            saveTestToXmlFileDialog.ShowDialog();
            bool result = false;

            if (saveTestToXmlFileDialog.FileName != "")
            {
                String url = Path.GetDirectoryName(saveTestToXmlFileDialog.FileName);
                var testMakeFile = new TestBLL();
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
            if (MessageBox.Show(this, "Do you want to add more question.", "Add question", MessageBoxButtons.OK) ==
                DialogResult.OK)
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
            string idFolder = Singleton<GuiActionEventController>.Instance.FolderId;
            using (var newExamDialog = new NewExamDialog(idFolder))
            {
                newExamDialog.ShowDialog();
            }
        }

        #endregion
    }
}