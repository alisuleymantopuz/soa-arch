using Northwind.Contracts.Data;
using Northwind.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Assemblers
{
    public interface ICategoryServiceAssemblers
    {
        SearchCategoryCriteria GetSearchCategoryCriteria(SearchCategoryRequest searchCategoryRequest);

        SearchCategoryResponse GetSearchCategoryResponse(IList<Category> selectResult);

        Category GetCategoryInfo(CreateCategoryRequest createCategoryRequest);

        CreateCategoryResponse GetCreateCategoryResponse(Category category);

        DeleteCategoryResponse GetDeleteCategoryResponse(Category category);

        Category GetCategoryInfo(DeleteCategoryRequest deleteCategoryRequest);
    }
}
