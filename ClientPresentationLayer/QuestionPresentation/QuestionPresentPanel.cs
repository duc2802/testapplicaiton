using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.BusinessObjects;
using ClientPresentationLayer.QuestionPresentation.Data;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionPresentPanel : UserControl
    {
        int timetestInSeconds =60;
        private TestDataListViewItem _dataItem;
        public TestDataListViewItem DataItem
        {
            set
            {
                _dataItem = value;
            }
            get { return _dataItem; }
        }
        public QuestionPresentPanel()
        {
            InitializeComponent();
            InitEvent();
            InitGui();
        }

        private void InitGui() 
        {
            timeTest.Interval = 1000;
            timeTest.Start();
            LoadContentPanel();
        }
        public void LoadContentPanel()
        {
            var questionItem = new QuestionItem();
            contentQuestionPanel.Controls.Add(questionItem);
        }

        private void InitEvent()
        {
            endExamButton.Click += EndExamButtonClick;
            timeTest.Tick += new EventHandler(Timer_Tick);
            lbTime.Text = getTime(); 
        }

        private void EndExamButtonClick(object sender, EventArgs e)
        {
            OnEndExam();
        }

        public string getTime()
        {
            string time = "";
            timetestInSeconds--;

            if (timetestInSeconds == 0)
            {
                startStop();
            }
            else
            {
                TimeSpan ts = TimeSpan.FromSeconds(Convert.ToDouble(timetestInSeconds));
                time = ts.ToString("hh\\:mm\\:ss");
            }
            return time;
        }

        private void startStop()
        {
            // Do some thing with exam
        }

        public void Timer_Tick(object sender, EventArgs eArgs)
        {
                lbTime.Text = getTime();
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
