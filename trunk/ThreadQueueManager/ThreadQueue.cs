using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadQueueManager
{
    public class ThreadQueue<T> : IQueueInterface<T>
    {
        private readonly Object _locker = new Object();
        private readonly Queue<T> _queue = new Queue<T>(1000);
        private readonly AutoResetEvent _waitEvent = new AutoResetEvent(false);

        virtual public int Count
        {
            get
            {
                lock (_locker)
                    return _queue.Count;
            }
        }

        virtual public void Push(T obj)
        {
            lock (_locker)
            {
                _queue.Enqueue(obj);

                if (_queue.Count == 1)
                    _waitEvent.Set();
            }
        }

        virtual public T Pop()
        {
            try
            {
                T cmd = SafePop();
                if (cmd != null)
                {
                    return cmd;
                }
                    
            }
            catch (Exception ex)
            {
                //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                //    LocalizeManager.GetErrorMessage(ErrorMessageClient.FailedPopItemFromQueue, ex));
            }

            _waitEvent.WaitOne();
            _waitEvent.Reset();

            T waitCmd = SafePop();
            if (waitCmd == null)
                return default(T);
            return waitCmd;
        }

        public T SafePop()
        {
            T rc;
            lock (_locker)
            {
                if (_queue.Count > 0)
                {
                    rc = _queue.Dequeue();
                }
                else
                    return default(T);
            }
            return rc;
        }

        public void Close()
        {
            lock (_locker)
            {
                _queue.Clear();
                _waitEvent.Set();
            }
        }
    }
}
