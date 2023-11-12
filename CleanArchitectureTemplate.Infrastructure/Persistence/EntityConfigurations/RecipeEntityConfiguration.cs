using CleanArchitectureReferenceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class RecipeEntityConfiguration : object, IEntityTypeConfiguration<RecipeEntity>
    {
        public void Configure(EntityTypeBuilder<RecipeEntity> builder)
        {
            builder.HasKey(x => x.Id);

            #region Ingredients
            builder.HasMany(x => x.IngredientEntitys)
                .WithOne(x=> x.Recipe)
                .HasForeignKey(x => x.RecipeId)
                .IsRequired(true);
            #endregion

        }
    }
}
