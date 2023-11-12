using CleanArchitectureReferenceTemplate.Application.DTO.V1;
using CleanArchitectureReferenceTemplate.Constans;
using FluentValidation;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation.DTO
{
    internal class UserLoginInputMessageFluentValidator : AbstractValidator<UserLoginInputMessage>
    {
        public UserLoginInputMessageFluentValidator()
        {

            RuleFor(input => input.Email)
                .NotNull().WithMessage("The email address field is require.")
                .Matches(RegularExpression.EmailAddress)
                .WithMessage("Invalid email address.");
            RuleFor(input => input.Password).NotNull().WithMessage("The password field is required.");

        }
    }


}
