using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.DataThread
{
    public class DataQueueThreadController : ThreadQueueController
    {
        public DataQueueThreadController()
        {

        }

        public DataQueueThreadController(string nameQueue)
            : base(nameQueue)
        {

        }
    }
}
