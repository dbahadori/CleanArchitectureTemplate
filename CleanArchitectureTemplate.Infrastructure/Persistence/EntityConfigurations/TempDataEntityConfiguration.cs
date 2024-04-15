using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfigurations
{

    internal sealed class TempDataEntityConfiguration : object, IEntityTypeConfiguration<TempData>
    {
        public void Configure(EntityTypeBuilder<TempData> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
