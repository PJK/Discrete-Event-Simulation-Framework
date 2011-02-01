using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    /// <summary>
    /// Provides reflection-based dispaching to discrete
    /// handling methods
    /// </summary>
    public static class ReflectiveEventDispatcher
    {
        /// <summary>
        /// Atempts to forward the passed event to appropriate
        /// handler inside current class
        /// </summary>
        /// <param name="ev">The event</param>
        /// <param name="source">The emmiting object</param>
        /// <param name="handler">Object to handler the event</param>
        public static void Notify(this IEventHandler handler, Event ev, IEventEmmiter source)
        {
            if (handler.GetType().GetMethod("Handle" + ev.Name) != null)
            {
                // C# WTF?
                object[] prms = new object[] {ev, source};
                handler.GetType().GetMethod("Handle" + ev.Name).Invoke(handler, prms);
            }
            else
            {
                throw new System.NotImplementedException("This object doesn't have appropriate handler methods for event " + ev.Name);
            }
        }
    }
}
