using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientPresentationLayer.QuestionPresentation.Data;

namespace ClientPresentationLayer.QuestionPresentation
{
    public partial class QuestionReviewPanel : UserControl
    {
        private QuestionDataListViewItemController _dataController;

        private QuestionDataListViewItemController DataController
        {
            set
            {
                _dataController = value;
                //OnChangeDataController();
            }
            get { return _dataController; }
        }

        public QuestionReviewPanel()
        {
            InitializeComponent();
            Init();
            InitGui();
            InitEvent();
        }

        public void Init()
        {
            DataController = new QuestionDataListViewItemController();
        }

        public void InitGui()
        {
            questionlistView.Clear();
            questionlistView.Items.AddRange(DataController.DisplayItems.ToArray());
        }

        public void InitEvent()
        {
            
        }

        public void RefreshGui()
        {
            DataController.FillQuestioinDataListViewItem();
            questionlistView.Clear();
            questionlistView.Items.AddRange(DataController.DisplayItems.ToArray());
        }
    }
}
