using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SingleInstanceObject;
using ThreadQueueManager;
using ResourceMassageManager;

namespace TestThreadQueueManager
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(LocalizeManager.GetErrorMessage(ErrorMessageClient.TestErrorMessage));
            System.Console.WriteLine(LocalizeManager.GetInfoMessage(InfoMessageClient.TestInfoMessage));

            Singleton<ThreadQueueController>.Instance.InitializeThreadQueueController("testController");
            for (int i = 0; i < 10; i++)
            {
                TestCommand command = new TestCommand(ExecuteMethod.Async, "command " + i);
                Singleton<ThreadQueueController>.Instance.PutCmd(command);
            }

            while (Singleton<ThreadQueueController>.Instance.ThreadQueue.QueueSize > 0)
            {
                System.Console.WriteLine("Number thread in queue threadQueueManager: " + Singleton<ThreadQueueController>.Instance.ThreadQueue.QueueSize);
                Thread.Sleep(500);
            }
        }
    }
}
