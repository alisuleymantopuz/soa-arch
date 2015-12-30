using Northwind.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure
{
    public class ApplicationConfiguration : ConfigurationBase
    {
        public string ConnectionString { get { return base.GetConnectionStringByName("NorthwindConnectionString"); } }

        public string ApplicationName { get { return base.GetStringValueByKeyName("ApplicationName"); } }

        public string AppLogDirectory { get { return base.GetStringValueByKeyName("AppLogDirectory"); } }

        public string AppExceptionsLogDirectory { get { return base.GetStringValueByKeyName("AppExceptionsLogDirectory"); } }


    }
}
