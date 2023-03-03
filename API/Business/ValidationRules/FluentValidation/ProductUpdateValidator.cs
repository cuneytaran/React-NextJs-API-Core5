using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class ProductUpdateValidator : AbstractValidator<Product>
    {
        public ProductUpdateValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
        }
    }
}
