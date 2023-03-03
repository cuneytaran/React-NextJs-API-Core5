using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class ProductDeleteValidator : AbstractValidator<Product>
    {
        public ProductDeleteValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();

        }
    }
}
