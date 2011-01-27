using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    /// <summary>
    /// Interface of an object capable of
    /// accepting standard events
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Allows an event emmiter to notify handler
        /// about an event
        /// </summary>
        /// <param name="ev">The event</param>
        /// <param name="source">Reference event source</param>
        void Notify(SEvent ev, IEventEmmiter source);
    }
}
