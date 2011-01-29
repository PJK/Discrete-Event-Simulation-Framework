using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Object.Queue
{
    public interface IQueue : Flow.Event.IEventHandler, Subject.Logger.ILogContributor
    {
        void Add(IQueueable member, uint processingTime);
        void Remove(IQueueable member);
        uint Length
        {
            get;
        }

        uint MembersCount
        {
            get;
        }
    }
}
