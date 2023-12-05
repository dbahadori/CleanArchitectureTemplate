using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces.Models
{
    public interface IRecipe
    {
        Guid Id { get; set; }
        string Name { get; set; }
        RecipeType Type { get; set; }

    }
}
