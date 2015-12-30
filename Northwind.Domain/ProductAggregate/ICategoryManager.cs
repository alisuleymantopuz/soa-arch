using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.ProductAggregate
{
    public interface ICategoryManager
    {
        IList<Category> SearchCategory(SearchCategoryCriteria criteria);
        void SaveCategory(Category category);
        void UpdateCategory(Category category);

        void DeleteCategory(Category category);
    }
}
