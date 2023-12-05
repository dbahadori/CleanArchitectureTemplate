using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Interfaces.Factories
{
    public interface IRecipeGeneratorFactoryProvider
    {
        IRecipeGeneratorFactory GetFactory(RecipeCategory category);
    }
}
