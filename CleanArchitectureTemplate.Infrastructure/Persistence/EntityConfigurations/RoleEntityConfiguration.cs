using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class RoleEntityConfiguration : object, IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
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
