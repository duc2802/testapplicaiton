using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.BusinessObjects;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionPresentPanel : UserControl
    {
        public QuestionPresentPanel()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            endExamButton.Click += EndExamButtonClick;
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
