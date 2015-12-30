using FluentValidation.Results;
using Northwind.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Exceptions;

namespace Northwind.Domain.Validators
{
    public class CategoryValidators : ICategoryValidators
    {
        public void CategorySaveValidator(Category category)
        {
            CategorySaveValidator validator = new CategorySaveValidator();
            ValidationResult result = validator.Validate(category);
            if (result.Errors.Count > 0)
            {
                foreach (var validationFailure in result.Errors)
                {
                    int errorCode = Convert.ToInt32(validationFailure.ErrorMessage);
                    throw new BusinessException((BusinessExceptionCodes)errorCode);

                }
            }
        }


        public void CategoryDeleteValidator(Category category)
        {
            CategoryDeleteValidator validator = new CategoryDeleteValidator();
            ValidationResult result = validator.Validate(category);
            if (result.Errors.Count > 0)
            {
                foreach (var validationFailure in result.Errors)
                {
                    int errorCode = Convert.ToInt32(validationFailure.ErrorMessage);
                    throw new BusinessException((BusinessExceptionCodes)errorCode);

                }
            }
        }
    }
}
