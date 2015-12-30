using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Container.Installers;
using Northwind.Container.Facilities;

namespace Northwind.Container
{
    public static class Bootstrapper
    {
        public static WindsorContainer Container { get; private set; }

        public static void Initialize()
        {
            Container = new WindsorContainer();


            Container
                     .AddFacility<InterceptorFacility>()
                     .Install(new InterceptorInstaller())
                     .Install(new InfrastructureInstaller())
                     .Install(new DatabaseContextInstaller())
                     .Install(new RepositoryInstaller())
                     .Install(new ValidatorInstaller())
                     .Install(new ManagerInstaller())
                     .Install(new AssemblerInstaller())
                     .Install(new TransformerInstaller())
                     .Install(new ServiceInstaller());

        }
    }
}
