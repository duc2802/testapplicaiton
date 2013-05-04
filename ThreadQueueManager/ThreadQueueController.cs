using System;
using System.Threading;

namespace ThreadQueueManager
{
    public class ThreadQueueController
    {
        private readonly object _locker = new object();

        private CommandThread _commandThreads;

        public CommandThread ThreadQueue 
        {
            get { return _commandThreads; }
        }

        public ThreadQueueController()
        {
             
        }

        public ThreadQueueController(string nameController)
        {
            InitializeThreadQueueController(nameController);
        }

        public void Do(Delegate method)
        {
            PutCmd(new DelegateCommand(method), false);
        }

        public void Do(Delegate method, params Object[] args)
        {
            PutCmd(new DelegateCommand(method, args), false);
        }

        public void Do(Delegate method, CommandThread thread)
        {
            PutCmd(new DelegateCommand(method, thread, null), false);
        }

        public void Do(Delegate method, CommandThread thread, params object[] args)
        {
            PutCmd(new DelegateCommand(method, thread, args), false);
        }

        public void RunOrQueue(Delegate method)
        {
            PutCmd(new DelegateCommand(method), true);
        }

        public void RunOrQueue(Delegate method, params Object[] args)
        {
            PutCmd(new DelegateCommand(method, args), true);
        }

        public void RunOrQueue(Delegate method, CommandThread thread)
        {
            PutCmd(new DelegateCommand(method, thread, null), true);
        }

        public void RunOrQueue(Delegate method, CommandThread thread, params object[] args)
        {
            PutCmd(new DelegateCommand(method, thread, args), true);
        }

        public void PutCmd(ICommand command)
        {
            PutCmd(command, false);
        }

        public void PutCmd(ICommand command, bool tryExecute)
        {
            if (tryExecute && IsCurrentThread())
            {
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    //LogManager.Log(event_type.et_Internal, severity_type.st_error, String.Format("CommandThreads: {0}.", ex), ex);
                }
            }
            else
            {
                _commandThreads.PutCmd(command);
            }
        }

        public void InitializeThreadQueueController(string nameController)
        {
            lock (_locker)
            {
                _commandThreads = new CommandThread();
                _commandThreads.CreateThread(new ThreadQueue<ICommand>(), nameController);
            }
        }

        public void TerminateCommandThreads()
        {
            lock (_locker)
            {
                _commandThreads.IsTerminate = true;
            }
        }

        public bool IsTerminated
        {
            get
            {
                lock (_locker)
                {
                    return _commandThreads.IsTerminate;
                }
            }
        }

        public bool IsCurrentThread()
        {
            return _commandThreads.Thread == Thread.CurrentThread;
        }

        
    } 
}
