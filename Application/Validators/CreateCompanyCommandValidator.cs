using Application.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators
{
    public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(c => c.Company.Name).NotEmpty().MaximumLength(60);
            RuleFor(c => c.Company.Address).NotEmpty().MaximumLength(60);
        }

        public override ValidationResult Validate(ValidationContext<CreateCompanyCommand> context)
        {
            return context.InstanceToValidate.Company is null
                ? new ValidationResult(new[] { new
                    ValidationFailure("CompanyForCreationDto", "CompanyForCreationDto object is null") })
                : base.Validate(context);
        }

    }
}
