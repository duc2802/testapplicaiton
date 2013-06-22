using System;
using System.Windows.Forms;
using PresentationLayer.ActionController;
using PresentationLayer.Explorer;
using PresentationLayer.ThreadManager.DataThread;
using SingleInstanceObject;
using ThreadQueueManager;

namespace PresentationLayer.ExamEditor
{
    public partial class NewExamDialog : Form
    {
        public string FolderId { set; get; }

        public NewExamDialog(string idFolder)
        {
            InitializeComponent();
            InitData(idFolder);
            InitGui();
            InitEvent();
        }

        public void InitGui()
        {
            Text = string.Format("Create new exam in \"{0}\" folder.", FolderId);
            numQuestionTextBox.Focus();
            createExamButton.Enabled = false;
        }

        public void InitEvent()
        {
            cancelButton.Click += CancelNewExamButtonClick;
            createExamButton.Click += CreateNewExamButtonClick;
            numQuestionTextBox.KeyPress += NumQuestionTextBoxKeyPress;
        }

        public void InitData(string idFolder)
        {
            FolderId = idFolder;
        }

        private void CancelNewExamButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void NumQuestionTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CreateNewExamButtonClick(object sender, EventArgs e)
        {
            var dataItem = new TestDataItem();
            dataItem.IdTest = DateTime.Now.ToLongDateString();
            dataItem.NumberQuestion = Int32.Parse(numQuestionTextBox.Text);
            dataItem.Name = tbNameExam.Text;
            dataItem.Time = Int32.Parse(tbTime.Text);
            dataItem.DateCreate = DateTime.Now;
            Singleton<GuiActionEventController>.Instance.OnAddTestItem(dataItem);


            ICommand command = new SaveTestCmd(ExecuteMethod.Async, )
            Singleton<DataQueueThreadController>.Instance.PutCmd(command);
            Close();
        }

        private void NameExamTextBoxChanged(object sender, EventArgs e)
        {
            createExamButton.Enabled = true;
        }
    }
}