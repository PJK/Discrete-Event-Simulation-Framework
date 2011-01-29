using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Subject.Logger
{
    /// <summary>
    /// Specifies an object that is able to use ILogger
    /// </summary>
    public interface ILogContributor
    {
        /// <summary>
        /// Supposedly a "globally" unique name
        /// Sample values: Car1, MrSmith, Costumer-48, Plane747
        /// </summary>
        string UniqueName { get; }
    }
}
