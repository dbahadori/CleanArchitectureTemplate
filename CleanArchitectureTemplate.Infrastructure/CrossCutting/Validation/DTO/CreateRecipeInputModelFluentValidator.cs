using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Application.DTO.V2;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Resources;
using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation.DTO
{
    public class CreateRecipeInputModelFluentValidator : AbstractValidator<CreateRecipeInputModel>
    {
        public CreateRecipeInputModelFluentValidator()
        {
            RuleFor(input => input.RecipeCategory)
                .NotEmpty().WithMessage(ValidationMessages.RecipeCategoryNotEmpty)
                .Must(category => Enum.IsDefined(typeof(RecipeCategory), category)).WithMessage("test1");
            
            RuleFor(input => input.RecipeType)
                .NotEmpty().WithMessage(ValidationMessages.RecipeTypeNotEmpty)
                .Must(type => Enum.IsDefined(typeof(RecipeType), type)).WithMessage("test2");
        }

    }
}
