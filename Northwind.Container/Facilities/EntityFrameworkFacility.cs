using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System.Data.Entity;
using Northwind.Domain.Mapping;

namespace Northwind.Container.Facilities
{
    public class EntityFrameworkFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<DbContext>()
                                     .ImplementedBy<NorthwindContext>()
                                     .LifestylePerWebRequest());
        }
    }
}
