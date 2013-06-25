using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessEntities;
using Commons;
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
using ThreadQueueManager;


namespace PresentationLayer
{
    public partial class MainForm : Office2007RibbonForm
    {
        private TestDataItem _dataTestDataItem;
        private readonly TestListDataItemController _dataItemController = new TestListDataItemController();
        private WelcomeScreen _welcomeScreen;
        private bool done;

        public MainForm()
        {
            InitializeComponent();
            InitData();
            InitCommonGui();
            InitEvent();
            InitSingletonObject();
            done = true;
        }

        private void InitData()
        {
            DoSplash();
            LoadData();
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

        private void InitButtonEvent()
        {
            btNewExam.Click += NewExamButtonClick;
            btNewQuestion.Click += NewQuestionButtonClick;
            btExportExam.Click += ButtonExportTestToXML;
            openFileButton.Click += ButtonOpenFileButtonClick;
            exportDocsExamButton.Click += ExportDocsExamButtonButtonClick;
            btEditQuestion.Click += EditQuestionButtonClick;
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

        public void LoadData()
        {
            LoadNodeExplorerDataItem();
            LoadTestBE();
        }

        private void LoadNodeExplorerDataItem()
        {
            string dataFolder = Singleton<SettingManager>.Instance.GetDataFolder();
            var dataDirectory = new DirectoryInfo(dataFolder);
            Singleton<List<Folder>>.Instance = dataDirectory.GetDirectories().Select(di => new Folder(di.Name)).ToList();
        }

        private void LoadTestBE()
        {
            var testBll = new TestBLL();
            foreach (Folder folder in Singleton<List<Folder>>.Instance)
            {
                if (!folder.FolderName.Equals("Data"))
                {
                    List<TestBE> listTestBe = testBll.ScanTestExamFile(folder.FolderName);
                    foreach (TestBE testBe in listTestBe)
                    {
                        Singleton<List<TestBE>>.Instance.Add(testBe);
                    }
                }
            }
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

        private void ExportDocsExamButtonButtonClick(object sender, EventArgs eventArgs)
        {
            //int testId = Singleton<GuiActionEventController>.Instance.FolderId;
            //ExportForm exportForm = new ExportForm(testId + 1);
            //exportForm.ShowDialog();
        }
        private void EditQuestionButtonClick(object sender, EventArgs eventArgs)
        {
            // Load test Item that 

            string idTest = Singleton<GuiActionEventController>.Instance.TestId;
            string idForder = Singleton<GuiActionEventController>.Instance.FolderId;
            _dataItemController.LoadTestDataItem(idForder);
            _dataTestDataItem = _dataItemController.TestBook[idTest];
            int questionId = Singleton<GuiActionEventController>.Instance.QuestionId;
            MultipleChoiceEditor form = new MultipleChoiceEditor(_dataTestDataItem.QuestionData.DataItems[questionId]);
            if(DialogResult.OK == form.ShowDialog())
            {
                Singleton<GuiActionEventController>.Instance.OnChangeQuestion(form.DataItem);
            }
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            CloseSplash();
        }

        private void DoSplash()
        {
            _welcomeScreen = new WelcomeScreen();
            _welcomeScreen.Show();
            Application.DoEvents();
        }

        private void CloseSplash()
        {
            _welcomeScreen.Close();
            _welcomeScreen.Dispose();
            Application.DoEvents();
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
                result = testMakeFile.ExportTestExamFile(t, saveTestToXmlFileDialog.FileName, url);
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
                var form = new MultipleChoiceEditor();
                if(DialogResult.OK == form.ShowDialog())
                {
                    Singleton<GuiActionEventController>.Instance.OnAddQuestionItem(form.DataItem);

                    var question = form.DataItem.getQuestionBE();
                    Singleton<TestBE>.Instance.ListQuestion.Add(question);

                    ICommand command = new SaveTestCmd(ExecuteMethod.Async, Singleton<TestBE>.Instance);
                    Singleton<DataQueueThreadController>.Instance.PutCmd(command);
                }
            }
        }

        private void NewExamButtonClick(object sender, EventArgs e)
        {
            string idFolder = Singleton<GuiActionEventController>.Instance.FolderId;
            if (idFolder != null && !idFolder.Equals("Data"))
            {
                using (var newExamDialog = new NewExamDialog(idFolder))
                {
                    newExamDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You can't create test item in data folder. Please add a sub folder before.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}