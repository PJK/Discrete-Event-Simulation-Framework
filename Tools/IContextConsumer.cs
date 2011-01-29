using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Tools
{
    /// <summary>
    /// Interface of a class dependent on the context
    /// </summary>
    public interface IContextConsumer
    {
        void setContext(SimulationContext context);
    }
}
