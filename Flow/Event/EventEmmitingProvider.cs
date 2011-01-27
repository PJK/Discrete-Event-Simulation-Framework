using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    public class EventEmmitingProvider : IEventEmmiter
    {
        protected List<IEventHandler> _handlers = new List<IEventHandler>();

        public void AttachHandler(IEventHandler handler)
        {
            _handlers.Add(handler);
        }

        public void DetachHandler(IEventHandler handler)
        {
            if (!_handlers.Remove(handler))
            {
                throw new ArgumentException("Referenced handler is not attached to this emmiter!");
            }
        }

        public void DetachAllHandlers()
        {
            _handlers = new List<IEventHandler>();
        }

        public void FireEvent(SEvent ev)
        {
            foreach (IEventHandler handler in _handlers) {
                handler.Notify(ev);
            }
        }
    }
}
