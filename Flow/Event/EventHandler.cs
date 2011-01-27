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
    abstract public class EventHandler
    {
        /// <summary>
        /// Atempts to forward the passed event to appropriate
        /// handler inside current class
        /// </summary>
        /// <param name="ev">The event</param>
        public void Notify(SEvent ev)
        {
            if (this.GetType().GetMethod("Handle" + ev.Name) != null)
            {
                // C# WTF?
                object[] prms = new object[0];
                prms[0] = ev;
                this.GetType().GetMethod("Handle" + ev.Name).Invoke(this, prms);
            }
            else
            {
                throw new System.NotImplementedException("This object doesn't have appropriate handler methods for event " + ev.Name);
            }
        }
    }
}
