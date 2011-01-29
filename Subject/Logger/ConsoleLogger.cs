using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Subject.Logger
{
    /// <summary>
    /// A basic logger with console outputs
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Verbosity level
        /// </summary>
        public uint Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value > 10)
                {
                    throw new IndexOutOfRangeException("Verbosity levemust be in <0;10> interval!");
                }
                _level = value;
            }
        }

        public uint _level = 0;

        public ConsoleLogger(uint level)
        {
            Level = level;
        }

        public void Log(ILogContributor sender,string what, uint level)
        {
            if (level <= Level)
            {
                Console.WriteLine(sender.UniqueName + what);
            }
        }
    }
}
