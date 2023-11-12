using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureReferenceTemplate.Domain.Entities;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfigurations
{

    internal sealed class TempDataEntityConfiguration : object, IEntityTypeConfiguration<TempDataEntity>
    {
        public void Configure(EntityTypeBuilder<TempDataEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
