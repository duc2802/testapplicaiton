using System;
using System.Windows.Forms;
using BusinessEntities;
using PresentationLayer.ActionController;
using PresentationLayer.Explorer;
using PresentationLayer.Explorer.Data;
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

            nameExamTextBox.Validating += TextBoxValidating;
            numQuestionTextBox.Validating += NumberValidating;
            timeTestTextBox.Validating += NumberValidating;
        }

        private void TextBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            if(string.IsNullOrWhiteSpace(textbox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(string.Format("{0} cannot be empty", "Name"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NumberValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int num;
            if (string.IsNullOrWhiteSpace(textbox.Text) || !int.TryParse(textbox.Text, out num))
            {
                e.Cancel = true;
                MessageBox.Show(string.Format("{0} must type number", "Text box"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
            if (string.IsNullOrWhiteSpace(nameExamTextBox.Text))
            {
                MessageBox.Show(string.Format("{0} cannot be empty", "Name"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int num;
            if (string.IsNullOrWhiteSpace(timeTestTextBox.Text) || !int.TryParse(timeTestTextBox.Text, out num))
            {
                MessageBox.Show(string.Format("{0} must type number", "Text box"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(numQuestionTextBox.Text) || !int.TryParse(numQuestionTextBox.Text, out num))
            {
                MessageBox.Show(string.Format("{0} must type number", "Text box"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dataItem = new TestDataItem
                               {
                                   IdTest = String.Format("{0:ddmmyyyyHHmmss}", DateTime.Now),
                                   NumberQuestion = Int32.Parse(numQuestionTextBox.Text),
                                   Name = nameExamTextBox.Text,
                                   Time = Int32.Parse(timeTestTextBox.Text),
                                   FolderId = FolderId,
                                   DateCreate = DateTime.Now
                               };
            Singleton<GuiActionEventController>.Instance.OnAddTestItem(dataItem);

            ICommand command = new CreateTestItemCmd(ExecuteMethod.Async, (TestBE)dataItem.TranslateToBE());
            Singleton<DataQueueThreadController>.Instance.PutCmd(command);
            Close();
        }

        private void NameExamTextBoxChanged(object sender, EventArgs e)
        {
            createExamButton.Enabled = true;
        }
    }
}