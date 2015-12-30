using FluentValidation;
using Northwind.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Exceptions;

namespace Northwind.Domain.Validators
{
    public class CategoryDeleteValidator : AbstractValidator<Category>
    {
        public CategoryDeleteValidator()
        {
            this.RuleFor(x => x.CategoryId).GreaterThan(0)
                .WithMessage(((int)BusinessExceptionCodes.CategoryCanNotNull).ToString());
        }
    }
}
