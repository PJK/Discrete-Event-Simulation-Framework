using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    /// <summary>
    /// Interface of an object capable of "emmiting" events
    /// </summary>
    public interface IEventEmmiter
    {
        /// <summary>
        /// Attaches a new subscriber
        /// </summary>
        /// <param name="handler">The subscriber</param>
        void AttachHandler(IEventHandler handler);

        /// <summary>
        /// Detaches a subscriber
        /// </summary>
        /// <param name="handler">The subscriber</param>
        void DetachHandler(IEventHandler handler);
    }
}
