using CleanArchitectureTemplate.Application.DTO.V1.Users;
using CleanArchitectureTemplate.Constants;
using FluentValidation;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation.DTO
{
    internal class UserLoginInputMessageFluentValidator : AbstractValidator<UserLoginRequestDTO>
    {
        public UserLoginInputMessageFluentValidator()
        {

            RuleFor(input => input.Email)
                .NotNull().WithMessage("The email address field is require.")
                .Matches(RegularExpression.EmailAddress).WithMessage("Invalid email address.");
            RuleFor(input => input.Password)
                .NotNull().WithMessage("The password field is required.");

        }
    }


}
