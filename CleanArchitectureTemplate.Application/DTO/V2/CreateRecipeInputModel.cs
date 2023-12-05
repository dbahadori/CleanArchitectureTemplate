using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.DTO.V2
{
    public class CreateRecipeInputModel
    {
        public required string RecipeCategory { get; set; }
        public required string RecipeType { get; set; }
    }
}
