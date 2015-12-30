using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Northwind.Container;
using Northwind.Web.Api.Container;

namespace Northwind.Web.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();
        }

        private void BootstrapContainer()
        {
            Bootstrapper.Initialize();
            var container = Bootstrapper.Container;
            container.Install(new ControllerInstaller());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));

            var dependencyResolver = new WindsorDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }
    }
}