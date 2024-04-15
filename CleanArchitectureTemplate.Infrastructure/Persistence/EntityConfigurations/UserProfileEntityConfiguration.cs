using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class UserProfileEntityConfiguration : object, IEntityTypeConfiguration<UserProfileEntity>
    {
        public void Configure(EntityTypeBuilder<UserProfileEntity> builder)
        {
            builder.HasKey(x => x.Id);

            //Address value object persisted as owned entity type supported since EF Core 2.0
            builder
                .OwnsOne(o => o.Address);
            #region BookMarks
            builder.HasMany(x => x.Bookmarks)
                .WithOne(x=> x.UserProfile)
                .HasForeignKey(x => x.UserProfileId)
                .IsRequired(true);
            #endregion
            
            #region Activities
            builder.HasMany(x => x.Activities)
                .WithOne(x => x.UserProfile)
                .HasForeignKey(x => x.UserProfileId)
                .IsRequired(true);
            #endregion


        }
    }
}
