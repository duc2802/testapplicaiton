using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ThreadQueueManager;

namespace TestThreadQueueManager
{
    public class TestCommand : ICommand
    {
        ExecuteMethod synch_ = ExecuteMethod.Async;
        private string _name;

        public TestCommand(ExecuteMethod synch, String name)
        {
            synch_ = synch;
            _name = name;
        }

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
                Thread.Sleep(3000);
                System.Console.WriteLine("Execute() thread name: " + _name);
            }
            catch (Exception ex)
            {
                //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                //    "PositionsClosedCmd: " + LocalizeManager.GetErrorMessage(ErrorMessageClient.ErrorOccurred, ex));
            }
        }
    }
}
