using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Northwind.Infrastructure;
using Northwind.Infrastructure.Configuration;
using Northwind.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Container.Installers
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            #region Infrastructure-Configuration

            container.Register(Component.For<ConfigurationBase>().LifestyleTransient());

            container.Register(Component.For<LoggingBase>().LifestyleTransient());

            container.Register(Component.For<EntityFrameworkConfiguration>().LifestyleTransient());

            container.Register(Component.For<WebAPIConfiguration>().LifestyleTransient());

            container.Register(Component.For<ApplicationConfiguration>().LifestyleTransient());

            container.Register(Component.For<WebApplicationLogger>().LifestyleTransient());

            container.Register(Component.For<ApplicationLogger>().LifestyleTransient());

            #endregion
        }
    }
}
