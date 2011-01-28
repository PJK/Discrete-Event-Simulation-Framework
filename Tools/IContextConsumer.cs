using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Tools
{
    public interface IContextConsumer
    {
        void setContext(SimulationContext context);
    }
}
