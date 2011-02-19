using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Tools
{
    public static class LoggingHelpers
    {
        public static string GetTypeOrName(object o)
        {
            if (o is Subject.Logger.ILogContributor)
            {
                return ((Subject.Logger.ILogContributor)o).UniqueName;
            }
            else
            {
                return o.GetType().ToString();
            }
        }
    }
}
