using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Subject.Logger
{
    /// <summary>
    /// Defines interface of a progress logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Sends a log entry
        /// </summary>
        /// <param name="sender">Reference to sender</param>
        /// <param name="what">The message</param>
        /// <param name="level">Level of entrys' importance</param>
        void Log(ILogContributor sender, string what, uint level);

        /// <summary>
        /// Designates level of verbosity
        /// Intended to be in range of <0,10> where 10 is the most verbose
        /// DESF uses following:
        /// 1 - main events
        /// 5 - important events
        /// 10 - every move
        /// </summary>
        uint Level { get; set; }
    }
}
