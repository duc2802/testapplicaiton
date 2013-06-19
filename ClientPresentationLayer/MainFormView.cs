using System.Windows.Forms;
using ClientPresentationLayer.QuestionPresentation;

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
            InitCommonGui();
            InitEvent();
        }

        private void InitCommonGui()
        {
            _questionReview = new QuestionReviewPanel();
            _questionReview.Dock = DockStyle.Fill;

            _questionPresent = new QuestionPresentPanel();
            _questionPresent.Dock = DockStyle.Fill;

            _managerTest = new TestManager();
            _managerTest.Dock = DockStyle.Fill;

            Controls.Add(_managerTest);
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
            Controls.Add(_questionReview);
            ResumeLayout();
        }

        private void StartExam(object sender)
        {
            SuspendLayout();
            Controls.Clear();
            Controls.Add(_questionPresent);
            ResumeLayout();
        }
    }
}