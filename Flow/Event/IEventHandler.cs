using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Event
{
   public interface IEventHandler
    {
        void Notify(SEvent ev);
    }
}
