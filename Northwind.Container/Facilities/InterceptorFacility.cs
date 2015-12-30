using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel.Facilities;
using Northwind.Container.Interceptors;

namespace Northwind.Container.Facilities
{
    public class InterceptorFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentRegistered += new Castle.MicroKernel.ComponentDataDelegate(Kernel_ComponentRegistered);
        }

        private void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            if (handler.ComponentModel.Name.EndsWith("Service"))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(LoggingInterceptor)));
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ExceptionHandlingInterceptor)));
            }
            else if (handler.ComponentModel.Name.EndsWith("Manager"))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(LoggingInterceptor)));
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ExceptionHandlingInterceptor)));
            }
        }
    }
}
