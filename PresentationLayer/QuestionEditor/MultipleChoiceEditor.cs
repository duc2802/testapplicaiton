using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BusinessEntities;
using Commons;
using Commons.BusinessObjects;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.QuestionEditor.Data;
using TestApplication;

namespace PresentationLayer.QuestionEditor
{
    public partial class MultipleChoiceEditor : Form
    {
        private QuestionDataItem _dataItem;
        private int MAX_SHOW_ITEM = 6;
        private String _action = "";

        public MultipleChoiceEditor()
        {
            _action = "create";            
            InitializeComponent();
            this.btCreate.Text = @"Create";
            InitEvent();
            InitCommonGui();
        }

        public MultipleChoiceEditor(QuestionDataItem question)
        {
            _action = "edit";
            
            InitializeComponent();
            this.btCreate.Text = @"Ok";
            InitEvent();
            InitCommonGui(question);
        }

        private void InitEvent()
        {
            // Add answer Events.
            btMoreAnswer.Click += MoreAnswerButtonClick;            
        }

        private void MoreAnswerButtonClick(object sender, EventArgs e)
        {
            // set at 6 item, if more than 6, scrollable
            if (tbListAnswer.Controls.Count == MAX_SHOW_ITEM)
            {
                MessageBox.Show(this, @"Can not add more than 6 answers", @"Error", MessageBoxButtons.OK);
                return;
            }

            Item itemLayout=null;
            AnswerDataItem newItem = null;
            tbListAnswer.SuspendLayout();
            int oderNumber = 1;
            if (DataItem != null){
                //oderNumber = DataItem.AnswerData.AnswerData.Count + 1;
                oderNumber = tbListAnswer.Controls.Count + 1;
            }
            newItem = new AnswerDataItem(oderNumber,"",false);
            DataItem.AnswerData.AnswerData.Add(newItem);
            itemLayout = new Item(newItem, oderNumber);
            itemLayout.DataItem.orderAnswer = oderNumber;
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.Location = new Point(0, itemLayout.Height);
            itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
            itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswer.Controls.Add(itemLayout);

           
            tbListAnswer.ResumeLayout();

        }

        private void InitCommonGui()
        {
            tbListAnswer.SuspendLayout();
            for (int idx = 0; idx < 2; idx++)
            {
                Item itemLayout = new Item();
                itemLayout.Location = new Point(0, idx * itemLayout.Height);
                itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
                itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
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
                this.Text = DataItem.OrderQuestion.ToString();
            }
            else if (true)
            {

            }
            OnUpdate(DataItem.IdQuestion);
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

        private void OnDataItemChanged()
        {
            tbQuestionContent.Text = DataItem.ContentQuestion;
            this.Text ="Question "+ DataItem.OrderQuestion.ToString();
            if (DataItem.imageName != null)
            {
                label1.Text = "Click here to view image";
                label1.MouseClick += ShowImageofQuestion;
                label1.Visible = true;
            }
            AddAnswerOptions();
        }

        private void ShowImageofQuestion(object sender, EventArgs e)
        {
            //Load image in new form
            Graphics g = this.CreateGraphics();
            Rectangle rect = new Rectangle(50, 30, 100, 100);
            Bitmap image = new Bitmap("c:\\test.jpg");
            Point p = new Point(10, 10);
            g.DrawImage(image, p);
            g.Dispose();
            
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
            Item itemLayout = new Item(item,orderNumber);
            itemLayout.Delete += ItemLayoutDelete;
            itemLayout.DataItem.OrderAnswer = orderNumber;
            itemLayout.DataItem.orderAnswer = orderNumber;
            //itemLayout.Update += ItemLayoutUpdate;
            itemLayout.Location = new Point(0, itemLayout.Height);
            itemLayout.Size = new Size(tbListAnswer.Width - 10, itemLayout.Height);
            itemLayout.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            tbListAnswer.Controls.Add(itemLayout);
            tbListAnswer.ResumeLayout();
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
            DataItem.ContentQuestion = tbQuestionContent.Text;
        }

        private void tbQuestionExplain_TextChanged(object sender, EventArgs e)
        {
            DataItem.explain = tbQuestionExplain.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            opFileChoseImage.ShowDialog();
            opFileChoseImage.InitialDirectory = @"C:\";
            if (opFileChoseImage.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "" + opFileChoseImage.FileName + "";
            }
        }

        private void MultipleChoiceEditor_Load(object sender, EventArgs e)
        {

        }

        private void DeleteAnswerItem(int orderAnswer)
        {
            tbListAnswer.SuspendLayout();
            tbListAnswer.Controls.RemoveAt(orderAnswer-1);            
            /*
            var item = tbListAnswer.Controls.Find(orderAnswer.ToString(), true).First() as Item;
            if (item != null)
            {
                int idx = tbListAnswer.Controls.IndexOf(item);
               
                tbListAnswer.Refresh();
            }
            else
            {
                MessageBox.Show(this, "Delete Error", "Error", MessageBoxButtons.OK);
            }*/
            UpdateAllDataItem();
            tbListAnswer.ResumeLayout();
            this.Refresh();
            //Refresh();
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

       
        #region Trigger Event
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

        private ActionEventHandler<int> _deleteEvent;
        private readonly object _deleteEventLocker = new object();

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

        public event ActionEventHandler<int> Update
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

        private ActionEventHandler<int> _updateEvent;
        private readonly object _updateEventLocker = new object();

        private void OnUpdate(int idQuestion)
        {
            ActionEventHandler<int> handler = _updateEvent;
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

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            DataItem.AnswerData.AnswerData.Clear();

            for (int idx = 0; idx < tbListAnswer.Controls.Count; idx++)
            {
                var item = tbListAnswer.Controls[idx] as Item;
                if (item != null && item.DataItem.ContentAnswer != "")
                {
                    DataItem.AnswerData.AnswerData.Add(item.DataItem);
                }
            }

            QuestionBE qbe = DataItem.getQuestionBE();

            if(_action == "edit"){                             
                QuestionBLL qBll = new QuestionBLL();
                //hard code test id = 1
                if(qBll.UpdateQuestion(qbe, "xx"))
                {
                    MessageBox.Show(@"Update Succesful");
                    this.Close();
                }else
                {
                    MessageBox.Show(@"Update Fail");
                }
            }
            if (_action == "create")
            {
                QuestionBLL qBll = new QuestionBLL();
                //hard code test id = 1
                if (qBll.AddQuestion(qbe, "xx"))
                {
                    MessageBox.Show(@"Add Succesful");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"Add Fail");
                }
            }

        }
    }
}
