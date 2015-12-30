using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Northwind.Container.Facilities;
using Northwind.Domain.Mapping;
using Northwind.Infrastructure;
using Northwind.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Container.Installers
{
    public class DatabaseContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<NorthwindContext>().LifestyleTransient());
        }
    }
}
