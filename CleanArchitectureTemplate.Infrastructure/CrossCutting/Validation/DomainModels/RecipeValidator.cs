using FluentValidation;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation.DomainModels
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {

            RuleFor(recipe => recipe.Ingredients).NotEmpty();
        }
    }
}
