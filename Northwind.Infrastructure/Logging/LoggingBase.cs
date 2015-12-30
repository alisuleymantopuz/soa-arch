using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Northwind.Infrastructure.Logging
{
    public class LoggingBase
    {



        public void WriteEntry(LoggingValues values, string populatedPath)
        {
            

            StreamWriter writer = new StreamWriter(populatedPath, true);
            writer.WriteLine(JsonConvert.SerializeObject(values, Formatting.Indented));
            writer.WriteLine(".................................................................................");
            writer.Close();
        }

        public void WriteExit(LoggingValues values, string populatedPath)
        {
            

            StreamWriter writer = new StreamWriter(populatedPath, true);
            writer.WriteLine(JsonConvert.SerializeObject(values, Formatting.Indented));
            writer.WriteLine(".................................................................................");
            writer.Close();
        }

        public void WriteException(LoggingValues values, string populatedPath)
        {
            


            StreamWriter writer = new StreamWriter(populatedPath, true);
            writer.WriteLine(JsonConvert.SerializeObject(values, Formatting.Indented));
            writer.WriteLine(".................................................................................");
            writer.Close();

        }

        
    }
}
