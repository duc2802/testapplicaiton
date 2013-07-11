using System.Collections.Generic;
using System.Windows.Forms;
using BusinessEntities;
using ClientPresentationLayer.QuestionPresentation;
using ClientPresentationLayer.QuestionPresentation.Data;
using Commons;
using SingleInstanceObject;
using TestApplication;

namespace ClientPresentationLayer
{
    public partial class TestEasyClient : Form
    {
        private TestManager _managerTest;
        private HTMLQuestionPresentPanel _questionPresent;
        private QuestionReviewPanel _questionReview;
        private HTMLQuestionExplainPanel _questionExplain;

        public TestEasyClient()
        {
            InitializeComponent();
            InitData();
            InitCommonGui();
            InitEvent();
        }
        
        private void InitCommonGui()
        {
            _questionReview = new QuestionReviewPanel();
            _questionReview.Dock = DockStyle.Fill;

            _questionPresent = new HTMLQuestionPresentPanel();
            _questionPresent.Dock = DockStyle.Fill;

            _managerTest = new TestManager();
            _managerTest.Dock = DockStyle.Fill;

            _questionExplain = new HTMLQuestionExplainPanel();
            _questionExplain.Dock = DockStyle.Fill;

            Controls.Add(_managerTest);
        }

        private void InitData()
        {
            LoadTestBE();
        }

        private void InitEvent()
        {
            _managerTest.StartExam += StartExam;
            _questionPresent.EndExam += EndExam;

            _questionExplain.EndExam += EndExam;
            _questionReview.ReviewQuestion += QuestionReview;
            _questionReview.BackTestManager += QuestionReviewBackTestManager;
        }

        private void QuestionReviewBackTestManager(object sender)
        {
            SuspendLayout();
            Singleton<AnswerSheetDataController>.Instance.AnswerSheet.Clear();
            Controls.Clear();
            Controls.Add(_managerTest);
            ResumeLayout();
        }

        private void QuestionReview(object sender, int idx)
        {
            SuspendLayout();
            Controls.Clear();
            _questionExplain.ReloadData();
            _questionExplain.OrderNumber = idx;
            Controls.Add(_questionExplain);
            ResumeLayout();
        }

        private void EndExam(object sender)
        {
            SuspendLayout();
            Controls.Clear();
            _questionReview.RefreshGui();
            Controls.Add(_questionReview);
            ResumeLayout();
        }

        private void StartExam(object sender)
        {
            SuspendLayout();
            Controls.Clear();
            _questionPresent.DataItem = Singleton<TestBE>.Instance;
            _questionPresent.LoadContentPanel();
            Controls.Add(_questionPresent);
            ResumeLayout();
        }

        private void LoadTestBE()
        {
            var testBll = new TestBLL();
            List<TestBE> listTestBe = testBll.ScanClientTestExamFile("ClientData");
            foreach (TestBE testBe in listTestBe)
            {
                Singleton<List<TestBE>>.Instance.Add(testBe);
            }
        }
    }
}