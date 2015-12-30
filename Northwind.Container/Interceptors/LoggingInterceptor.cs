using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Infrastructure;
using System.Reflection;
using Northwind.Infrastructure.Logging;

namespace Northwind.Container.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public ApplicationLogger ApplicationLogger { get; private set; }

        public LoggingInterceptor(ApplicationLogger applicationLogger)
        {
            ApplicationLogger = applicationLogger;
        }

        public void Intercept(IInvocation invocation)
        {
            string referenceId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();

            this.ApplicationLogger.WriteEntry(referenceId, new List<object>() { invocation.Method, invocation.Arguments }, MethodBase.GetCurrentMethod(), LoggingLevel.Information, "");

            invocation.Proceed();

            this.ApplicationLogger.WriteExit(referenceId, new List<object>() { invocation.Method, invocation.Arguments }, MethodBase.GetCurrentMethod(), LoggingLevel.Information, "", invocation.ReturnValue);
        }
    }
}
