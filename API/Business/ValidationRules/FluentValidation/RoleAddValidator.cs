using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class RoleAddValidator : AbstractValidator<Role>
    {
        public RoleAddValidator()
        {
            RuleFor(p => p.RoleName).NotEmpty();

        }
    }
}
