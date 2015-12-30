using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Northwind.Infrastructure.Logging;

namespace Northwind.Infrastructure
{
    public class ApplicationLogger : LoggingBase
    {

        public ApplicationConfiguration ApplicationConfiguration { get; private set; }


        public ApplicationLogger(ApplicationConfiguration applicationConfiguration)
        {
            ApplicationConfiguration = applicationConfiguration;
        }

        public void WriteEntry(string referenceId, List<object> parameters, MethodBase methodBase, LoggingLevel level, string resultCode)
        {
            string populatedPath = this.PopulateFilePath(false);

            LoggingValues values = new LoggingValues()
            {

                ReferenceId = referenceId,
                Parameters = parameters,
                LoggingLevel = level,
                MethodBase = methodBase,
                ResultCode = resultCode,
                FormattedTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"),
                Order = LoggingOrder.Entry
            };

            base.WriteEntry(values, populatedPath);
        }

        public void WriteExit(string referenceId, List<object> parameters, MethodBase methodBase, LoggingLevel level, string resultCode, object returnValue)
        {
            string populatedPath = this.PopulateFilePath(false);

            LoggingValues values = new LoggingValues()
            {

                ReferenceId = referenceId,
                Parameters = parameters,
                LoggingLevel = level,
                MethodBase = methodBase,
                ResultCode = resultCode,
                ReturnValue = returnValue,
                FormattedTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"),
                Order = LoggingOrder.Exit
            };

            base.WriteExit(values, populatedPath);


        }

        public void WriteException(string referenceId, Exception ex, List<object> parameters, MethodBase methodBase, LoggingLevel level, string resultCode)
        {
            string populatedPath = this.PopulateFilePath(true);

            LoggingValues values = new LoggingValues()
            {
                ReferenceId = referenceId,
                Exception = ex,
                LoggingLevel = level,
                MethodBase = methodBase,
                ResultCode = resultCode,
                FormattedTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"),
                Order = LoggingOrder.Exception,
                Parameters = parameters
            };

            base.WriteException(values, populatedPath);


        }

        private string PopulateFilePath(bool isException)
        {
            string baseDirectory = "";
            string fileName = "";

            if (!isException)
            {
                fileName = this.ApplicationConfiguration.ApplicationName + " " + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".log";
                baseDirectory = this.ApplicationConfiguration.AppLogDirectory;
            }
            else
            {
                fileName = this.ApplicationConfiguration.ApplicationName + "-Exceptions " + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".log";
                baseDirectory = this.ApplicationConfiguration.AppExceptionsLogDirectory;
            }

            if (Directory.Exists(baseDirectory) == false)
            {
                Directory.CreateDirectory(baseDirectory);
            }

            string filePath = baseDirectory + fileName;

            return filePath;
        }

    }
}
