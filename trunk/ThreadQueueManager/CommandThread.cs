using System;
using System.Threading;

namespace ThreadQueueManager
{
    public class CommandThread
    {
        protected IQueueInterface<ICommand> QueueAsyncCommands;
        protected bool IsTerminateThread;

        public Thread Thread { get; private set; }

        public int QueueSize
        {
            get
            {
                return QueueAsyncCommands.Count;
            }
        }

        public virtual void PutCmd(ICommand cmd)
        {
            if (!IsTerminate)
            {
                switch (cmd.IsSeparate())
                {
                    case ExecuteMethod.Sync:
                        //LogManager.Log(event_type.et_Internal, severity_type.st_debug, string.Format("Sync start: {0}", cmd.GetType().Name));
                        try
                        {
                            cmd.Execute();
                        }
                        catch (Exception ex)
                        {
                            //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                            //    LocalizeManager.GetErrorMessage(ErrorMessageClient.FailedExecuteSyncCommand, ex));
                        }
                        break;
                    case ExecuteMethod.Async:
                        try
                        {
                            QueueAsyncCommands.Push(cmd);
                        }
                        catch (Exception ex)
                        {
                            //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                            //    LocalizeManager.GetErrorMessage(ErrorMessageClient.FailedPutAsyncCommand, ex));
                        }
                        break;
                }
            }
        }

        public virtual void CreateThread(IQueueInterface<ICommand> queue, string name)
        {
            QueueAsyncCommands = queue;
            Thread = new Thread(AsyncProc)
            {
                Name = name,
                IsBackground = true
            };
            Thread.Start();
        }

        protected virtual void AsyncProc()
        {
            while (!IsTerminate)
            {
                try
                {
                    ICommand cmd = QueueAsyncCommands.Pop();
                    if (cmd != null)
                    {
                        System.Console.WriteLine("Name Queue: " + cmd.GetName());
                        cmd.Execute();
                    }
                }
                catch (Exception ex)
                {
                    //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                    //    String.Format("CommandThread: {0}.", ex));
                }
            }
        }

        public virtual bool IsTerminate
        {
            get { return IsTerminateThread; }
            set
            {
                IsTerminateThread = value;
                QueueAsyncCommands.Close();
            }
        }
    }
}
