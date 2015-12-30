using Northwind.Domain.Mapping;
using Northwind.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public class CategoryRepository :ICategoryRepository
    {
        public NorthwindContext NorthwindContext { get; private set; }
        public CategoryRepository(NorthwindContext northwindContext)
        {
            NorthwindContext = northwindContext;
        }

        public IList<Category> SearchCategoryByNameOrDescription(string value)
        {
            value = value.ToLower();
            return
                this.NorthwindContext.Categories.Where(
                    a => a.CategoryName.ToLower().Contains(value) || a.Description.ToLower().Contains(value)).ToList();
            
        }

        public IList<Category> List()
        {
            return this.NorthwindContext.Categories.ToList();
        }

        public Category Load(int Id)
        {
            return this.NorthwindContext.Categories.Find(Id);
        }

        public void Save(Category category)
        {
            this.NorthwindContext.Categories.Add(category);
            this.NorthwindContext.SaveChanges();
        }

        public void Update(Category category)
        {
            if (category.CategoryId==0)
            {
                this.NorthwindContext.Categories.Add(category);
                
            }
            this.NorthwindContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            this.NorthwindContext.Categories.Remove(category);
            this.NorthwindContext.SaveChanges();
        }
    }
}
