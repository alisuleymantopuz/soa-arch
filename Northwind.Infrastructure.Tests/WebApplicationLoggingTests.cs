using Northwind.Exceptions;
using Northwind.Infrastructure.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Tests
{
    [TestFixture]
    public class WebApplicationLoggingTests
    {
        [Test]
        public void WriteEntry_Tests_Return_Success()
        {
            WebAPIConfiguration configuration = new WebAPIConfiguration();

            WebApplicationLogger logger = new WebApplicationLogger(configuration);

            logger.WriteEntry("referenceIdTest", new List<object>() { 1 }, MethodBase.GetCurrentMethod(), LoggingLevel.Debug, ((int)BusinessExceptionCodes.Success).ToString());

            logger.WriteExit("referenceIdTest", new List<object>() { 1 }, MethodBase.GetCurrentMethod(), LoggingLevel.Debug, ((int)BusinessExceptionCodes.Success).ToString(), null);

            try
            {
                throw new DivideByZeroException("exception");
            }
            catch (Exception exception)
            {
                logger.WriteException("referenceIdTest", exception, MethodBase.GetCurrentMethod(), LoggingLevel.Debug, ((int)BusinessExceptionCodes.Success).ToString());

            }
        }
    }
}
