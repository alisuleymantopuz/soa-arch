using Castle.MicroKernel.Registration; 
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Container.Interceptors;

namespace Northwind.Container.Installers
{
 public   class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<LoggingInterceptor>().LifestyleTransient());
            container.Register(Component.For<ExceptionHandlingInterceptor>().LifestyleTransient());
        
        }
    }
}
