using System;
using PresentationLayer.ActionController;
using SingleInstanceObject;
using ThreadQueueManager;

namespace PresentationLayer.ThreadCmd
{
    public class LoadQuestionCmd : ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private string _testId;

        public LoadQuestionCmd(ExecuteMethod synch, string testId)
        {
            synch_ = synch;
            _name = "LoadQuestionCmd";
            _testId = testId;
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
                Singleton<GuiActionEventController>.Instance.TestId = _testId;
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