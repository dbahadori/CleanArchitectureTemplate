using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation.DomainModels
{

    public class IngredientValidator : AbstractValidator<Ingredient>
    {
        public IngredientValidator()
        {
            RuleFor(ingredient => ingredient.Name).NotNull();
        }
    }
}

