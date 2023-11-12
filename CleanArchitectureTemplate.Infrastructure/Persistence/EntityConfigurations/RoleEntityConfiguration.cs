using CleanArchitectureReferenceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class RoleEntityConfiguration : object, IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(x => x.Id);

            #region Users
            builder.HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .UsingEntity(x => x.ToTable("User_Roles"));
            #endregion
        }
    }
}
