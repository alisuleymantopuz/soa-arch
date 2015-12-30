using FluentValidation;
using Northwind.Domain.ProductAggregate;
using Northwind.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Northwind.Domain.Validators
{
    public class CategorySaveValidator : AbstractValidator<Category>
    {
        public CategorySaveValidator()
        {
            this.RuleFor(x => x.CategoryName)
                .NotNull()
                .WithMessage(((int) BusinessExceptionCodes.CategoryCanNotNull).ToString());

        } 
    }
}
