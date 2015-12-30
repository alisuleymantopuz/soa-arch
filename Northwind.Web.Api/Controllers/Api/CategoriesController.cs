using System.Net;
using System.Net.Http;
using Castle.Windsor;
using Northwind.Container;
using Northwind.Contracts.Data;
using Northwind.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Northwind.WebAPI.Controllers.Api
{
    public class CategoriesController : ApiController
    {

        public ICategoryService CategoryService { get; private set; }
        public CategoriesController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        // GET api/Categories

        public IEnumerable<CategoryInfo> Get()
        {
            SearchCategoryRequest request = new SearchCategoryRequest();
            SearchCategoryResponse response = CategoryService.SearchCategory(request);
            return response.SearchResult.AsEnumerable();
        }

        // GET api/Categories/5

        public CategoryInfo Get(int id)
        {
            SearchCategoryRequest request = new SearchCategoryRequest();
            request.CategoryId = id;
            SearchCategoryResponse response = CategoryService.SearchCategory(request);
            return response.SearchResult.First();
        }

        // POST api/Categories

        public HttpResponseMessage Post([FromBody]CategoryInfo categoryInfo)
        {
            try
            {
                CreateCategoryRequest request = new CreateCategoryRequest();
                request.CategoryInfo = categoryInfo;
                CreateCategoryResponse response = this.CategoryService.CreateCategory(request);
                if (response == null || response.CategoryId == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public void Delete(int id)
        {
            if (id > 0)
            {

                DeleteCategoryRequest request = new DeleteCategoryRequest();
                request.CategoryId = id;

                DeleteCategoryResponse response = this.CategoryService.DeleteCategory(request);
            }

        }
    }
}
