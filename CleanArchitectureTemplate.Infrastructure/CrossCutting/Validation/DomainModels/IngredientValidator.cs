using FluentValidation;
using CleanArchitectureReferenceTemplate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Infrastructure.CrossCutting.Validation.DomainModels
{

    public class IngredientValidator : AbstractValidator<Ingredient>
    {
        public IngredientValidator()
        {
            RuleFor(ingredient => ingredient.Name).NotNull();
        }
    }
}

