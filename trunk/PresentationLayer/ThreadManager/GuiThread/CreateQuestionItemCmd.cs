using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.QuestionEditor;
using PresentationLayer.QuestionEditor.Data;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.GuiThread
{
    class CreateQuestionItemCmd : ICommand
    {
         private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private QuestionDataItem _data;

        private int _index;

        private TableLayoutPanel _questionPanel;

        public CreateQuestionItemCmd(ExecuteMethod synch, QuestionDataItem data, TableLayoutPanel panel, int idx)
        {
            synch_ = synch;
            _data = data;
            _index = idx;
            _questionPanel = panel;
            _name = "CreateQuestionItemCmd";
        }

        #region ICommand Members

        public string GetName()
        {
            return _name;
        }

        public ExecuteMethod IsSeparate()
        {
            return synch_;
        }

        public int Priority
        {
            get { return 0; }
        }

        public void Execute()
        {
            try
            {
                var questionItem = CreateQuestionItem(_data);
                questionItem.DataItem.OrderQuestion = _index;
                lock (_questionPanel)
                {
                    _questionPanel.Controls.Add(questionItem, 0, _index);
                }
            }
            catch (Exception ex)
            {
                //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                //    "PositionsClosedCmd: " + LocalizeManager.GetErrorMessage(ErrorMessageClient.ErrorOccurred, ex));
            }
        }


        private QuestionListItemCustom CreateQuestionItem(QuestionDataItem questionData)
        {
            var itemLayout = new QuestionListItemCustom(questionData);
            //itemLayout.Delete += ItemLayoutDelete;
            //itemLayout.Update += ItemLayoutUpdate;
            //itemLayout.MouseDown += ItemLayoutMouseDown;
            //itemLayout.Edit += ItemLayoutEdit;
            itemLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return itemLayout;
        }

        #endregion
    }
}
