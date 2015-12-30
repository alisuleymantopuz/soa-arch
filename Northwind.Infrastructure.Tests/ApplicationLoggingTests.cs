using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Northwind.Exceptions;
using Northwind.Infrastructure.Logging;

namespace Northwind.Infrastructure.Tests
{
     [TestFixture]
    public class ApplicationLoggingTests
    {
          [Test]
          public void WriteEntry_Tests_Return_Success()
          {
              ApplicationConfiguration configuration = new ApplicationConfiguration();

              ApplicationLogger logger = new ApplicationLogger(configuration);

              logger.WriteEntry("referenceIdTest", new List<object>() { 1 }, MethodBase.GetCurrentMethod(), LoggingLevel.Debug, ((int)BusinessExceptionCodes.Success).ToString());

              logger.WriteExit("referenceIdTest", new List<object>() { 1 }, MethodBase.GetCurrentMethod(), LoggingLevel.Debug, ((int)BusinessExceptionCodes.Success).ToString(), null);

              try
              {
                  throw new DivideByZeroException("exception");
              }
              catch (Exception exception)
              {
                  logger.WriteException("referenceIdTest", exception, null, MethodBase.GetCurrentMethod(), LoggingLevel.Debug, ((int)BusinessExceptionCodes.Success).ToString());

              }
          }
    }
}
