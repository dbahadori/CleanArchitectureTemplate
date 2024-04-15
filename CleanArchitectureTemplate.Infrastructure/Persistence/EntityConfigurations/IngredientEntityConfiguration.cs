using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class IngredientEntityConfiguration : object, IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            #region Ingredient
            builder.HasKey(x => x.Id);
            #endregion

        }
    }
}
