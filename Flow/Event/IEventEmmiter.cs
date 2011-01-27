using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    public interface IEventEmmiter
    {
        void AttachHandler(IEventHandler handler);
        void DetachHandler(IEventHandler handler);
    }
}
