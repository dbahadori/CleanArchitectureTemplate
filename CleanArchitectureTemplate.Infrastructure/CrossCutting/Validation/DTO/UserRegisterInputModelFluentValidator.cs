using FluentValidation;
using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Constants;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation.DTO
{
    public class UserRegisterInputModelFluentValidator : AbstractValidator<UserRegisterInputModel>
    {
        public UserRegisterInputModelFluentValidator()
        {

            RuleFor(input => input.Email)
                .NotNull().WithMessage("The email address field is require.")
                .Matches(RegularExpression.EmailAddress)
                .WithMessage("Invalid email address."); 
            RuleFor(input => input.Password).NotNull().WithMessage("The password field is required.")
                .Matches(RegularExpression.Password)
                .WithMessage("Invalid password format. Passwords must be at least 8 characters long and contain at least one upper letter and one digit.");
            RuleFor(input => input.FullName).NotNull().WithMessage("The fullName field is required.");

        }
    }
}
