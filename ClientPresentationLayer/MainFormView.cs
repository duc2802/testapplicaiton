using System.Collections.Generic;
using System.Windows.Forms;
using BusinessEntities;
using ClientPresentationLayer.QuestionPresentation;
using Commons;
using SingleInstanceObject;
using TestApplication;

namespace ClientPresentationLayer
{
    public partial class MainFormView : Form
    {
        private TestManager _managerTest;
        private QuestionPresentPanel _questionPresent;
        private QuestionReviewPanel _questionReview;

        public MainFormView()
        {
            InitializeComponent();
            InitData();
            InitCommonGui();
            InitEvent();
        }
        
        private void InitCommonGui()
        {
            _questionPresent = new QuestionPresentPanel();
            _questionPresent.Dock = DockStyle.Fill;

            _managerTest = new TestManager();
            _managerTest.Dock = DockStyle.Fill;

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
        }

        private void EndExam(object sender)
        {
            SuspendLayout();
            Controls.Clear();
            _questionReview = new QuestionReviewPanel();
            _questionReview.Dock = DockStyle.Fill;
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