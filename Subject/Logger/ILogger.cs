using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Subject.Logger
{
    public interface ILogger
    {
        void Log(ILogContributor sender, string what, uint level);
        /// <summary>
        /// Range<0,10>
        /// </summary>
        uint Level { get; set; }
    }
}
