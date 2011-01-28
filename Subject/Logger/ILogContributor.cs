using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Subject.Logger
{
    public interface ILogContributor
    {
        string UniqueName { get; }
    }
}
