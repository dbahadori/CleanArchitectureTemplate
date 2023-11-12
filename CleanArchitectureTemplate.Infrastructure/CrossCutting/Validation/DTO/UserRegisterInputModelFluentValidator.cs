﻿using FluentValidation;
using CleanArchitectureReferenceTemplate.Application.DTO.V1;
using CleanArchitectureReferenceTemplate.Constans;

namespace CleanArchitectureReferenceTemplate.Infrastructure.CrossCutting.Validation.DTO
{
    public class UserRegisterInputModelFluentValidator : AbstractValidator<UserRegisterInputMessage>
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