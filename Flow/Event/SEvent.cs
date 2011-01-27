using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
    public struct SEvent
    {
        public string Name;
        public HashSet<string> Data;

        public SEvent(string name, HashSet<string> data)
        {
            
           Name = name;
            Data = data;
        }

    }
}
