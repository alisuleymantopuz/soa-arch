using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.ProductAggregate
{
    public interface ICategoryValidators
    {
        void CategorySaveValidator(Category category);

        void CategoryDeleteValidator(Category category);
    }
}
