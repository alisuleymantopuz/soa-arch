using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Logging
{
    public class LoggingValues
    {
        public string ReferenceId { get; set; }
        public List<object> Parameters { get; set; }
        public MethodBase MethodBase { get; set; }
        public LoggingLevel LoggingLevel { get; set; }
        public LoggingOrder Order { get; set; }
        public string ResultCode { get; set; }
        public object ReturnValue { get; set; }
        public string FormattedTime { get; set; }
        public Exception Exception { get; set; }
    }
}
