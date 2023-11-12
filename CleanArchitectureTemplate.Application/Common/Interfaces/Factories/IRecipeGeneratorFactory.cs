using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories
{
    public interface IRecipeGeneratorFactory
    {
        IRecipeGenerator CreateRecipeGenerator(RecipeType type);

    }
}
