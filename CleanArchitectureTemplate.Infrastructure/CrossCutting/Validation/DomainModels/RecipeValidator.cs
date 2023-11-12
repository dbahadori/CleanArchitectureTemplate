using FluentValidation;
using CleanArchitectureReferenceTemplate.Domain.Models;

namespace CleanArchitectureReferenceTemplate.Infrastructure.CrossCutting.Validation.DomainModels
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {

            RuleFor(recipe => recipe.Instructions).NotEmpty();
        }
    }
}
