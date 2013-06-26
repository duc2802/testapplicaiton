using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using ClientPresentationLayer.Common;
using ClientPresentationLayer.QuestionPresentation.Data;
using Commons.BusinessObjects;
using PresentationLayer.QuestionEditor;
using SingleInstanceObject;
using System.Collections;


namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionPresentPanel : UserControl
    {
        int timetestInSeconds =60;
        private TestBE _dataItem;
        int indexQuestion =0;
        int maxIndexQuestion;

        public TestBE DataItem
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
            InitData();
            InitGui();
        }

        private void InitData()
        {
            DataItem = new TestBE();
        }

        private void InitGui() 
        {
            timeTest.Interval = 1000;
            timeTest.Start();
            LoadContentPanel();
        }


        public void FillQuestionDataWithQuestionIndex(int indexQuestionData)
        {
            SuspendLayout();
            if (DataItem.TestID != null)
            {
                // Clear panel
                ArrayList list = new ArrayList(contentQuestionPanel.Controls);
                foreach (Control c in list)
                {
                    contentQuestionPanel.Controls.Remove(c);
                }

                // Load data into answer and panel
                lbQuestionOrder.Text = (indexQuestionData +1).ToString();
                var questionItem = new QuestionItem(DataItem.ListQuestion[indexQuestion]);
                questionItem.Dock = DockStyle.Fill;
                contentQuestionPanel.Controls.Add(questionItem);
                indexQuestion = indexQuestionData;
            }
            ResumeLayout();
        }


        public void LoadContentPanel()
        {
            //Load combobox
            if (DataItem.TestID != null)
            {
                maxIndexQuestion = DataItem.ListQuestion.Count;

                for (int i = 1; i <= maxIndexQuestion; i++)
                {
                    goToQuesNumcomboBox.Items.Add(i);
                }
            }
            FillQuestionDataWithQuestionIndex(0);
        }

        private void InitEvent()
        {
            endExamButton.Click += EndExamButtonClick;
            timeTest.Tick += new EventHandler(Timer_Tick);
            lbTime.Text = getTime();

            previousButton.Click += PreviousButtonClick;
            nextButton.Click += NextButtonClick;
            goToQuesNumcomboBox.SelectedIndexChanged += SelectQuestionInCombobox;
            
        }


        private void SelectQuestionInCombobox(object sender, EventArgs e)
        {
            indexQuestion =(int)goToQuesNumcomboBox.SelectedItem -1;
            FillQuestionDataWithQuestionIndex(indexQuestion);
        }

        private void PreviousButtonClick(object sender, EventArgs e)
        {
           if(indexQuestion > 0)
                indexQuestion -= 1;
            FillQuestionDataWithQuestionIndex(indexQuestion);
        }

        private void NextButtonClick(object sender, EventArgs e)
        {
            if(indexQuestion < maxIndexQuestion-1)
            indexQuestion += 1;

            FillQuestionDataWithQuestionIndex(indexQuestion);
        }

        private void EndExamButtonClick(object sender, EventArgs e)
        {
           
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
