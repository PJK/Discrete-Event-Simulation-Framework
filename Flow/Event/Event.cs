using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    /// <summary>
    /// Represents an event
    /// </summary>
    public struct Event
    {
        /// <summary>
        /// Events' name
        /// </summary>
        public string Name;
        /// <summary>
        /// Data passed alongside with the event
        /// </summary>
        public object[] Data;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="data">Event data</param>
        public Event(string name, object[] data)
        {
            
            Name = name;
            Data = data;
        }

    }
}
