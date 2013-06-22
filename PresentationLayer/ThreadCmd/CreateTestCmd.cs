using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PresentationLayer.Explorer;
using ThreadQueueManager;

namespace PresentationLayer.ThreadCmd
{
    public class CreateTestCmd : ICommand
    {
         private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private TestDataItem _dataItem;

        public CreateTestCmd(ExecuteMethod synch, TestDataItem dataItem)
        {
            synch_ = synch;
            _name = "LoadQuestionCmd";
            _dataItem = dataItem;
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
                //Create file xml in appdate.
            }
            catch (Exception ex)
            {
                //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                //    "PositionsClosedCmd: " + LocalizeManager.GetErrorMessage(ErrorMessageClient.ErrorOccurred, ex));
            }
        }

        #endregion
    }
}
