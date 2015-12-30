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
    public class ExceptionHandlingInterceptor : IInterceptor
    {
        public ApplicationLogger ApplicationLogger { get; private set; }


        public ExceptionHandlingInterceptor(ApplicationLogger applicationLogger)
        {
            ApplicationLogger = applicationLogger;
        }

        public void Intercept(IInvocation invocation)
        {
            string referenceId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                this.ApplicationLogger.WriteException(referenceId, exception, new List<object>() { invocation.Method, invocation.Arguments, invocation.ReturnValue }, MethodBase.GetCurrentMethod(), LoggingLevel.Error, "");
            }
        }
    }
}
