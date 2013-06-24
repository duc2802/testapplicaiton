using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessEntities;
using Commons.BusinessObjects;
using PresentationLayer.QuestionEditor.Data;
using TestApplication;
using System.IO;
using SingleInstanceObject;
using Commons;

namespace PresentationLayer.QuestionEditor
{
    public partial class MultipleChoiceEditor : Form
    {
        private readonly String _action = "";
        private int MAX_SHOW_ITEM = 6;
       
        private string PATH_FORDER_IMAGE =Singleton<SettingManager>.Instance.GetImageFolder();
        private QuestionDataItem _dataItem;

        public MultipleChoiceEditor()
        {
            _action = "create";
            InitializeComponent();
            btCreate.Text = @"Create";
            InitData();
            InitEvent();
            InitCommonGui();
        }

        public MultipleChoiceEditor(QuestionDataItem question)
        {
            InitializeComponent();
            _action = "edit";
            btCreate.Text = @"Ok";
            InitEvent();
            InitCommonGui(question);
        }

        private void InitData()
        {
            _dataItem = new QuestionDataItem();
        }

        public QuestionDataItem DataItem
        {
            set
            {
                _dataItem = value;
                Name = _dataItem.IdQuestion.ToString();
                OnDataItemChanged();
            }
            get { return _dataItem; }
        }

        private void InitEvent()
        {
            // Add answer Events.
            btMoreAnswer.Click += MoreAnswerButtonClick;
            btAddImage.Click += AddImageButtonClick;
        }

        private void AddImageButtonClick(object sender, EventArgs e) 
        {
            if (opFileChoseImage.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(opFileChoseImage.FileName))
                {
                    string newName =   Guid.NewGuid().ToString();
                    string ext = Path.GetExtension(opFileChoseImage.FileName);
                    newName = newName + ext;
                    string newPath = PATH_FORDER_IMAGE +newName;
                    File.Copy(opFileChoseImage.FileName, newPath);
                    _dataItem.imageName = newName;
                    DataItem.imageName = newName;
                    pictureBox.Image = new Bitmap(newPath);
                    pictureBox.Show();
                    this.Refresh();
                    // Show Thuilmnal in label
                }
            }
        }

        private void MoreAnswerButtonClick(object sender, EventArgs e)
        {
            // set at 6 item, if more than 6, scrollable
            if (tbListAnswer.Controls.Count == MAX_SHOW_ITEM)
            {
                MessageBox.Show(this, @"Can not add more than 6 answers", @"Error", MessageBoxButtons.OK);
                return;
            }

            Item itemLayout = null;
            AnswerDataItem newItem = null;
            tbListAnswer.SuspendLayout();
            int oderNumber = 1;
            if (DataItem != null)
            {
                //oderNumber = DataItem.AnswerData.AnswerData.Count + 1;
                oderNumber = tbListAnswer.Controls.Count + 1;
            }
            newItem = new AnswerDataItem(oderNumber, "", false);
            DataItem.AnswerData.AnswerData.Add(newItem);
            itemLayout = new Item(newItem, oderNumber);
            itemLayout.DataItem.orderAnswer = oderNumber;
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Location = new Point(0, itemLayout.Height);
            itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
            itemLayout.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswer.Controls.Add(itemLayout);


            tbListAnswer.ResumeLayout();
        }

        private void InitCommonGui()
        {
            tbListAnswer.SuspendLayout();
            for (int idx = 0; idx < 2; idx++)
            {
                var itemLayout = new Item();
                itemLayout.Location = new Point(0, idx*itemLayout.Height);
                itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                itemLayout.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
                tbListAnswer.Controls.Add(itemLayout);
            }
            tbListAnswer.ResumeLayout();
            
        }

        private void InitCommonGui(QuestionDataItem questionData)
        {
            DataItem = questionData;
            DataItem.PropertyChanged += DataItemPropertyChanged;
        }

        private void DataItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionEventHandler<PropertyChangedEventArgs>(DataItemPropertyChanged), sender, e);
                return;
            }
            if (e.PropertyName.Equals("OrderAnswer"))
            {
                Text = DataItem.OrderQuestion.ToString();
            }
            else if (true)
            {
            }
            OnUpdate(DataItem.IdQuestion.ToString());
        }

        private void OnDataItemChanged()
        {
            tbQuestionContent.Text = DataItem.ContentQuestion;
            Text = "Question " + DataItem.OrderQuestion.ToString();
            if (DataItem.imageName != null && DataItem.imageName != "")
            {
                // Dislay Image;
                pictureBox.Image = new Bitmap(PATH_FORDER_IMAGE + DataItem.imageName);
                pictureBox.Show();
                lbDislayImage.Visible = false;
            }
            else
            {
                pictureBox.Visible = false;
                lbDislayImage.Visible = true;
            }
            AddAnswerOptions();
        }

        private void ShowImageofQuestion( string pathImage)
        {
            //Load image in new form
            DislayImageForm picture = new DislayImageForm(PATH_FORDER_IMAGE +pathImage);
            picture.ShowDialog();
        }

        private void AddAnswerOptions()
        {
            int i = 1;
            foreach (AnswerDataItem answerItem in DataItem.AnswerData.AnswerData)
            {
                AddNewLine(answerItem, i);
                i++;
            }
        }

        private void AddNewLine(AnswerDataItem item, int orderNumber)
        {
            tbListAnswer.SuspendLayout();
            var itemLayout = new Item(item, orderNumber);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.DataItem.OrderAnswer = orderNumber;
            itemLayout.DataItem.orderAnswer = orderNumber;
            //itemLayout.Update += ItemLayoutUpdate;
            itemLayout.Location = new Point(0, itemLayout.Height);
            itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
            itemLayout.Anchor = (((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswer.Controls.Add(itemLayout);
            tbListAnswer.ResumeLayout();
            this.ResumeLayout(false);
        }

        private void ItemLayoutDelete(object sender, int parameter)
        {
            DeleteAnswerItem(parameter);
        }

        private void ItemLayoutUpdate(object sender, int parameter)
        {
            UpdateAnswerItem(parameter);
        }

        private void UpdateAnswerItem(int orderAnswer)
        {
            var item = tbListAnswer.Controls.Find(orderAnswer.ToString(), true).First() as Item;
            if (item != null)
            {
                item.Refresh();
                tbListAnswer.Refresh();
            }
            else
            {
                MessageBox.Show(this, "Update Error", "Error", MessageBoxButtons.OK);
            }
        }

        private void tbQuestionContent_TextChanged(object sender, EventArgs e)
        {
            //DataItem.ContentQuestion = tbQuestionContent.Text;
        }

        private void tbQuestionExplain_TextChanged(object sender, EventArgs e)
        {
            //DataItem.ExplainContent = tbQuestionExplain.Text;
        }
        private void MultipleChoiceEditor_Load(object sender, EventArgs e)
        {
        }

        private void DeleteAnswerItem(int orderAnswer)
        {
            tbListAnswer.SuspendLayout();
            tbListAnswer.Controls.RemoveAt(orderAnswer - 1);
            UpdateAllDataItem();
            tbListAnswer.ResumeLayout();
            Refresh();
        }

        private void UpdateAllDataItem()
        {
            for (int idx = 0; idx < tbListAnswer.Controls.Count; idx++)
            {
                var item = tbListAnswer.Controls[idx] as Item;
                if (item != null)
                {
                    item.DataItem.OrderAnswer = idx + 1;
                    item.Size = new Size(tbListAnswer.Width - 10, item.Height);
                }
            }
            tbListAnswer.Refresh();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            DataItem.IdQuestion = string.Format("{0:ddmmyyyyHHmmss}", DateTime.Now);
            DataItem.ContentQuestion = tbQuestionContent.Text;
            DataItem.ExplainContent = tbQuestionContent.Text;
            for (int idx = 0; idx < tbListAnswer.Controls.Count; idx++)
            {
                var item = tbListAnswer.Controls[idx] as Item;
                if (item != null && item.DataItem.ContentAnswer != "")
                {
                    var answer = new AnswerDataItem();
                    answer.ContentAnswer = item.DataItem.ContentAnswer;
                    answer.OrderAnswer = idx;
                    DataItem.AnswerData.AnswerData.Add(answer);
                }
            }

            //QuestionBE qbe = DataItem.getQuestionBE();

            //if (_action == "edit")
            //{
            //    var qBll = new QuestionBLL();
            //    //hard code test id = 1
            //    if (qBll.UpdateQuestion(qbe, "xx"))
            //    {
            //        MessageBox.Show(@"Update Succesful");
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(@"Update Fail");
            //    }
            //}
            //if (_action == "create")
            //{
            //    var qBll = new QuestionBLL();
            //    //hard code test id = 1
            //    if (qBll.AddQuestion(qbe, "xx"))
            //    {
            //        MessageBox.Show(@"Add Succesful");
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(@"Add Fail");
            //    }
            //}
        }

        #region Trigger Event

        private readonly object _deleteEventLocker = new object();
        private readonly object _updateEventLocker = new object();
        private ActionEventHandler<int> _deleteEvent;
        private ActionEventHandler<string> _updateEvent;

        public event ActionEventHandler<int> Delete
        {
            add
            {
                lock (_deleteEventLocker)
                {
                    _deleteEvent += value;
                }
            }
            remove
            {
                lock (_deleteEventLocker)
                {
                    _deleteEvent -= value;
                }
            }
        }

        private void OnDelete(int idQuestion)
        {
            ActionEventHandler<int> handler = _deleteEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idQuestion);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        public event ActionEventHandler<string> Update
        {
            add
            {
                lock (_updateEventLocker)
                {
                    _updateEvent += value;
                }
            }
            remove
            {
                lock (_updateEventLocker)
                {
                    _updateEvent -= value;
                }
            }
        }

        private void OnUpdate(string idQuestion)
        {
            ActionEventHandler<string> handler = _updateEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, idQuestion);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion

        private void pictureBox_Click(object sender, EventArgs e)
        {
            ShowImageofQuestion(DataItem.imageName);
        }

    }
}