using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    /// <summary>
    /// Provides methods for management of subscribers
    /// and event triggering
    /// </summary>
    public class EventEmmitingProvider : IEventEmmiter
    {
        /// <summary>
        /// Holds references to all registred handlers
        /// </summary>
        protected List<IEventHandler> _handlers = new List<IEventHandler>();

        /// <summary>
        /// Attaches a handler
        /// </summary>
        /// <param name="handler">A event handler/subscriber</param>
        public void AttachHandler(IEventHandler handler)
        {
            _handlers.Add(handler);
        }

        /// <summary>
        /// Detaches a handler
        /// </summary>
        /// <param name="handler">A event handler/subscriber</param>
        public void DetachHandler(IEventHandler handler)
        {
            if (!_handlers.Remove(handler))
            {
                throw new ArgumentException("Referenced handler is not attached to this emmiter!");
            }
        }

        /// <summary>
        /// Removes all subscriptions
        /// </summary>
        public void DetachAllHandlers()
        {
            _handlers = new List<IEventHandler>();
        }

        /// <summary>
        /// Triggers passed event at all registred handlers
        /// </summary>
        /// <param name="ev">The event</param>
        public void FireEvent(SEvent ev)
        {
            foreach (IEventHandler handler in _handlers) {
                handler.Notify(ev);
            }
        }
    }
}
