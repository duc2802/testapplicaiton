using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using SingleInstanceObject;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.DataThread
{
    public class SaveTestCmd : ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private TestBE _testBE;

        public SaveTestCmd(ExecuteMethod synch, TestBE testBE)
        {
            synch_ = synch;
            _name = "SaveTestCmd";
            _testBE = testBE;
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
