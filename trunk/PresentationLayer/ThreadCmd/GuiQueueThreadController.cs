using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreadQueueManager;

namespace PresentationLayer.ThreadCmd
{
    public class GuiQueueThreadController : ThreadQueueController
    {
        public GuiQueueThreadController()
        {
            
        }

        public GuiQueueThreadController(string nameQueue) : base(nameQueue)
        {
            
        }
    }
}
