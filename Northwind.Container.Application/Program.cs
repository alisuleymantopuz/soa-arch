using Northwind.Container;
using Northwind.Contracts.Data;
using Northwind.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Initialize();

            var container = Bootstrapper.Container;

            var service = container.Resolve<ICategoryService>();

            if (service != null)
            {
                SearchCategoryRequest request = new SearchCategoryRequest();
                request.CategoryId = 1;
                SearchCategoryResponse response = service.SearchCategory(request);
            }

        }
    }
}
