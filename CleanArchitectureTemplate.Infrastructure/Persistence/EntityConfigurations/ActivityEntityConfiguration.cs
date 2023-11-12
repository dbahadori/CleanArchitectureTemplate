using CleanArchitectureReferenceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class ActivityEntityConfiguration : object, IEntityTypeConfiguration<ActivityEntity>
    {
        public void Configure(EntityTypeBuilder<ActivityEntity> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
