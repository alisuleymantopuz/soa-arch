using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.ProductAggregate
{
    public class CategoryManager : ICategoryManager
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public ICategoryValidators CategoryValidators { get; private set; }
        public CategoryManager(ICategoryRepository categoryRepository, ICategoryValidators categoryValidators)
        {
            CategoryValidators = categoryValidators;
            CategoryRepository = categoryRepository;
        }

        public IList<Category> SearchCategory(SearchCategoryCriteria criteria)
        {
            if (criteria == null)
            {
                return null;
            }
            IList<Category> result = new List<Category>();

            if (criteria.CategoryId != 0)
            {
                Category category = this.CategoryRepository.Load(criteria.CategoryId);

                result.Add(category);
            }
            else
            {
                result = this.CategoryRepository.List();
            }

            return result;
        }


        public void SaveCategory(Category category)
        {
            this.CategoryValidators.CategorySaveValidator(category);

            this.CategoryRepository.Save(category);
        }

        public void UpdateCategory(Category category)
        {
            this.CategoryValidators.CategorySaveValidator(category);

            this.CategoryRepository.Update(category);
        }


        public void DeleteCategory(Category category)
        {
            category = this.CategoryRepository.Load(category.CategoryId);

            this.CategoryValidators.CategoryDeleteValidator(category);

            this.CategoryRepository.Delete(category);
        }
    }
}
