
using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class RecipeEntity : AuditableEntity
    {
        public RecipeEntity()
        {
            IngredientEntitys = new List<IngredientEntity>();
        }

        public string Name { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TimeSpan CookingTime { get; set; }
        public RecipeType Type { get; set; }
        public RecipeCategory Category { get; set; }
        public virtual IList<IngredientEntity> IngredientEntitys { get;  set; }


    }
}