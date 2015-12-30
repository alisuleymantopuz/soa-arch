using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Logging
{
    public enum LoggingLevel
    {
        Trace = 1,
        Warning = 2,
        Information = 3,
        Error = 4,
        Debug = 5,
        Fatal = 6
    }
}
