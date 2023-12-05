using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class UserEntityConfiguration : object, IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            #region User
            builder.HasKey(x => x.Id);
            #endregion

            #region UserProfile
            builder.HasOne(x => x.UserProfile)
                .WithOne(x=> x.User)
                .HasForeignKey<UserProfileEntity>(x => x.UserId)
                .IsRequired(true);
            #endregion


        }
    }
}
