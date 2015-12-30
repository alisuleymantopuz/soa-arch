using Northwind.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure
{
    public class EntityFrameworkConfiguration : ConfigurationBase
    {
        public string ConnectionString { get { return base.GetConnectionStringByName("NorthwindConnectionString"); } }
    }
}
