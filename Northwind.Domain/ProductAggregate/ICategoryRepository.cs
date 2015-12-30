using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.ProductAggregate
{
    public interface ICategoryRepository
    {
        IList<Category> SearchCategoryByNameOrDescription(string value);
        IList<Category> List();
        Category Load(int Id);
        void Save(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
