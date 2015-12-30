using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Configuration
{
    public class ConfigurationBase
    {
        protected string GetStringValueByKeyName(string Name)
        {
            return ConfigurationManager.AppSettings[Name].ToString();
        }

        protected int GetIntegerValueByKeyName(string Name)
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings[Name].ToString());
        }

        protected string GetConnectionStringByName(string Name)
        {
            return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }
    }
}
