using Northwind.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Services
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        SearchCategoryResponse SearchCategory(SearchCategoryRequest searchCategoryRequest);

        [OperationContract]
        CreateCategoryResponse CreateCategory(CreateCategoryRequest createCategoryRequest);

        [OperationContract]
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest);
    }
}
