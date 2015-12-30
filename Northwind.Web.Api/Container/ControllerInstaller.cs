using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Northwind.Web.Api.Controllers;
using Northwind.WebAPI.Controllers.Api;
using System.Web.Http;
using System.Web.Mvc;

namespace Northwind.Web.Api.Container
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            
            container.Register(Component.For<CategoriesController>().LifestyleTransient());
            container.Register(Component.For<ValuesController>().LifestyleTransient());
            container.Register(Component.For<HomeController>().LifestyleTransient());

        }


    }
}