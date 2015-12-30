using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Domain.ProductAggregate;
using Northwind.Infrastructure;

namespace Northwind.Domain.Mapping
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext():base("NorthwindConnectionString")
        { 

        }

        public DbSet<Category> Categories { get; set; } 
    }
}
