using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Interfaces.Factories
{
    public interface IRecipeGeneratorFactory
    {
        IRecipeGenerator CreateRecipeGenerator(RecipeType type);

    }
}
