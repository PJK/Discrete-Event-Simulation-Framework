using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Object.Queue
{
    public interface IQueueable : Flow.Event.IEventHandler
    {
        public void FinishedQueuing(IQueue queue);
    }
}
