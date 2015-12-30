using System.Collections;
using Northwind.Contracts.Services;
using Northwind.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Services.Assemblers;
using Northwind.Domain.ProductAggregate;

namespace Northwind.Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryServiceAssemblers CategoryServiceAssemblers { get; private set; }
        public ICategoryManager CategoryManager { get; private set; }

        public CategoryService(ICategoryServiceAssemblers categoryServiceAssemblers, ICategoryManager categoryManager)
        {
            CategoryManager = categoryManager;
            CategoryServiceAssemblers = categoryServiceAssemblers;
        }

        public SearchCategoryResponse SearchCategory(SearchCategoryRequest searchCategoryRequest)
        {
            SearchCategoryCriteria criteria =
                this.CategoryServiceAssemblers.GetSearchCategoryCriteria(searchCategoryRequest);

            IList<Category> selectResult = this.CategoryManager.SearchCategory(criteria);

            SearchCategoryResponse searchCategoryResponse = this.CategoryServiceAssemblers.GetSearchCategoryResponse(selectResult);

            return searchCategoryResponse;
        }


        public CreateCategoryResponse CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            Category category = this.CategoryServiceAssemblers.GetCategoryInfo(createCategoryRequest);

            this.CategoryManager.SaveCategory(category);

            CreateCategoryResponse createCategoryResponse = this.CategoryServiceAssemblers.GetCreateCategoryResponse(category);

            return createCategoryResponse;
        }


        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            Category category = this.CategoryServiceAssemblers.GetCategoryInfo(deleteCategoryRequest);

            this.CategoryManager.DeleteCategory(category);

            DeleteCategoryResponse deleteCategoryResponse = this.CategoryServiceAssemblers.GetDeleteCategoryResponse(category);

            return deleteCategoryResponse;
        }
    }
}
