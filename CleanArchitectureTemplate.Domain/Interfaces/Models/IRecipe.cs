using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Models
{
    public interface IRecipe
    {
        Guid Id { get; set; }
        string Name { get; set; }
        RecipeType Type { get; set; }

    }
}
