using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Domain.ProductAggregate;
using Northwind.Contracts.Data;

namespace Northwind.Services.Assemblers
{
    public class CategoryServiceAssemblers : ICategoryServiceAssemblers
    {
        public SearchCategoryCriteria GetSearchCategoryCriteria(SearchCategoryRequest searchCategoryRequest)
        {

            SearchCategoryCriteria criteria = new SearchCategoryCriteria();
            criteria.CategoryId = searchCategoryRequest.CategoryId;

            return criteria;

        }


        public SearchCategoryResponse GetSearchCategoryResponse(IList<Category> selectResult)
        {
            SearchCategoryResponse searchCategoryResponse = new SearchCategoryResponse();

            if (selectResult != null && selectResult.Count > 0)
            {
                searchCategoryResponse.SearchResult = new List<CategoryInfo>();

                foreach (var category in selectResult)
                {
                    searchCategoryResponse.SearchResult.Add(new CategoryInfo()
                        {
                            CategoryId = category.CategoryId,
                            Name = category.CategoryName,
                            Description = category.Description
                        });
                }
            }
            return searchCategoryResponse;


        }


        public Category GetCategoryInfo(CreateCategoryRequest createCategoryRequest)
        {
            Category category = new Category();
            category.CategoryName = createCategoryRequest.CategoryInfo.Name;
            category.Description = createCategoryRequest.CategoryInfo.Description;

            return category;
        }

        public CreateCategoryResponse GetCreateCategoryResponse(Category category)
        {
            CreateCategoryResponse createCategoryResponse = new CreateCategoryResponse();

            createCategoryResponse.CategoryId = category.CategoryId;

            return createCategoryResponse;
        }


        public DeleteCategoryResponse GetDeleteCategoryResponse(Category category)
        {
            return new DeleteCategoryResponse();
        }

        public Category GetCategoryInfo(DeleteCategoryRequest deleteCategoryRequest)
        {
            Category category = new Category();
            category.CategoryId = deleteCategoryRequest.CategoryId;

            return category;
        }
    }
}
