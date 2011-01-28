using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Tools
{
    /// <summary>
    /// Enables all objects in the simulation to get
    /// refernces to various common components
    /// </summary>
    public class SimulationContext
    {
        public Subject.Logger.ILogger Logger { set; get; }
        public Flow.Calendar.Calendar Calendar { get; set; }
    }
}
