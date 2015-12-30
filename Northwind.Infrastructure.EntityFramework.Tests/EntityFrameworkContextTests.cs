using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Domain.Mapping;
using System.Data.Linq;

namespace Northwind.Infrastructure.EntityFramework.Tests
{
    [TestClass]
    public class EntityFrameworkContextTests
    {
        [TestMethod]
        public void Configuration_Should_Be_Provided_Returns_Success()
        {
            NorthwindContext context =new NorthwindContext();
            var result = context.Categories.Find(1);

            Assert.IsNotNull(result);
        }
    }
}
