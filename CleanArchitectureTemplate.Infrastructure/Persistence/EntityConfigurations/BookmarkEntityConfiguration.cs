using CleanArchitectureReferenceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class BookmarkEntityConfiguration : object, IEntityTypeConfiguration<BookmarkEntity>
    {
        public void Configure(EntityTypeBuilder<BookmarkEntity> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
