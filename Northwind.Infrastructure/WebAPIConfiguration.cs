using Northwind.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure
{
    public class WebAPIConfiguration : ConfigurationBase
    {
        public string ConnectionString { get { return base.GetConnectionStringByName("NorthwindConnectionString"); } }

        public string WebApplicationName { get { return base.GetStringValueByKeyName("WebApplicationName"); } }

        public string WebLogDirectory { get { return base.GetStringValueByKeyName("WebLogDirectory"); } }

        public string WebExceptionsLogDirectory { get { return base.GetStringValueByKeyName("WebExceptionsLogDirectory"); } }
    }
}
