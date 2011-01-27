using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    /// <summary>
    /// Represents an event
    /// </summary>
    public struct SEvent
    {
        /// <summary>
        /// Events' name
        /// </summary>
        public string Name;
        /// <summary>
        /// Data passed alongside with the event
        /// </summary>
        public HashSet<string> Data;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="data">Event data</param>
        public SEvent(string name, HashSet<string> data)
        {
            
            Name = name;
            Data = data;
        }

    }
}
