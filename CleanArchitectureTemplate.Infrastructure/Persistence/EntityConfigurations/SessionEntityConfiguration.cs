using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class SessionEntityConfiguration : object, IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            #region Session
            builder.HasKey(x => x.Id);
            #endregion

            #region Settings
            builder.HasMany(x => x.Settings)
                .WithOne(x=> x.Session)
                .HasForeignKey(x => x.SessionId)
                .IsRequired(true);
            #endregion
        }
    }
}
