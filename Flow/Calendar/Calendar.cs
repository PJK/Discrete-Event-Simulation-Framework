using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Calendar
{
    /// <summary>
    /// The heart of simulation proccess. Registers and invokes
    /// terms, triggers "global" events and manages queues.
    /// </summary>
    class Calendar : Event.IEventEmmiter
    {

        protected Event.EventEmmitingProvider _provider = new Event.EventEmmitingProvider();

        public void AttachHandler(Event.IEventHandler handler)
        {
            _provider.AttachHandler(handler);
        }

        public void DetachHandler(Event.IEventHandler handler)
        {
            _provider.DetachHandler(handler);
        }

        public void AddTerm(Term term)
        {
        }

    }
}
