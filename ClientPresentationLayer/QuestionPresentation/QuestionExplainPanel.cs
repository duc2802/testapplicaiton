using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using Commons.BusinessObjects;
using SingleInstanceObject;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionExplainPanel : UserControl
    {

        private int _index = 1;
        public int OrderNumber
        {
            set
            {
                _index = value;
                RefreshGui(value);
            }
            get { return _index; }

        }

        private PresentQuestionPanel _questionPresent;

        public QuestionExplainPanel()
        {
            InitializeComponent();
            InitEvent();
            InitGui();
        }

        void InitGui() 
        {
            _questionPresent = new PresentQuestionPanel();
            _questionPresent.DataItem = Singleton<TestBE>.Instance;
            splitContainer.Panel1.Controls.Add(_questionPresent);
        }

        public void ReloadData()
        {
            _questionPresent.DataItem = Singleton<TestBE>.Instance;
            //Load combobox
            if (Singleton<TestBE>.Instance.TestID != null)
            {
                var maxIndexQuestion = Singleton<TestBE>.Instance.ListQuestion.Count;

                for (int i = 1; i <= maxIndexQuestion; i++)
                {
                    goToQuesNumcomboBox.Items.Add(i);
                }
            }
        }

        private void InitEvent()
        {
            nextButton.Click += NextButtonClick;
            previousButton.Click += PreviousButtonClick;
            btCloseViewExplain.Click += EndExamButtonClick;
        }

        private void PreviousButtonClick(object sender, EventArgs e)
        {
            var idx = OrderNumber - 1;
            OrderNumber = idx < 0 ? _questionPresent.DataItem.ListQuestion.Count - 1 : idx;
        }

        private void NextButtonClick(object sender, EventArgs e)
        {
            var idx = OrderNumber + 1;
            OrderNumber = _questionPresent.DataItem.ListQuestion.Count > idx
                              ? idx
                              : 0;
        }

        public void RefreshGui(int idx)
        {
            SuspendLayout();
            _questionPresent.FillQuestionDataWithQuestionIndex(idx);
            tbExplain.Text = Singleton<TestBE>.Instance.ListQuestion[idx].Explain;
            orderQuestionTextBox.Text = (idx + 1).ToString();

            ResumeLayout();
        }

        private void EndExamButtonClick(object sender, EventArgs e)
        {
            OnEndExam();
        }

        #region Register new event

        public event ActionEventHandler EndExam
        {
            add
            {
                lock (_endExamEventLocker)
                {
                    _endExamEvent += value;
                }
            }
            remove
            {
                lock (_endExamEventLocker)
                {
                    _endExamEvent -= value;
                }
            }
        }

        private ActionEventHandler _endExamEvent;
        private readonly object _endExamEventLocker = new object();

        private void OnEndExam()
        {
            ActionEventHandler handler = _endExamEvent;
            if (handler != null)
            {
                try
                {
                    handler(this);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion End register new event
    }
}
