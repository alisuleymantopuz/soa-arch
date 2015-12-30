using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Contracts.Services;
using Northwind.Services;

namespace Northwind.Container.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
            .AddFacility<WcfFacility>(f =>
            {
                f.CloseTimeout = TimeSpan.Zero;
            })
            .Register(
                Component
                    .For<ICategoryService>()
                    .ImplementedBy<CategoryService>()
                    .LifeStyle.Transient
                    .AsWcfService(new DefaultServiceModel()
                                      .AddBaseAddresses("http://localhost:8080/MyService")
                                      .AddEndpoints(WcfEndpoint.BoundTo(new BasicHttpBinding())
                                                        .At("basic"))
                                      .PublishMetadata(o => o.EnableHttpGet())));
        }
    }
}
