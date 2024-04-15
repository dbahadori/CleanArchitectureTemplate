using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class RecipeEntityConfiguration : object, IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);

            #region Ingredients
            builder.HasMany(x => x.Ingredients)
                .WithOne(x=> x.Recipe)
                .HasForeignKey(x => x.RecipeId)
                .IsRequired(true);
            #endregion

        }
    }
}
