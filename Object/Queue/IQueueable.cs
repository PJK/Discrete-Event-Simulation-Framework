using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Object.Queue
{
    public interface IQueueable
    {
        void FinishedQueuing(IQueue queue, DESF.Flow.Event.Event ev);
    }
}
