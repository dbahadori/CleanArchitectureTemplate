using CleanArchitectureReferenceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class IngredientEntityConfiguration : object, IEntityTypeConfiguration<IngredientEntity>
    {
        public void Configure(EntityTypeBuilder<IngredientEntity> builder)
        {
            #region Ingredient
            builder.HasKey(x => x.Id);
            #endregion

        }
    }
}
