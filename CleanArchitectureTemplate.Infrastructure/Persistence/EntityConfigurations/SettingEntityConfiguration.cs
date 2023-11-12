using CleanArchitectureReferenceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class SettingEntityConfiguration : object, IEntityTypeConfiguration<SettingEntity>
    {
        public SettingEntityConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<SettingEntity> builder)
        {
            #region Setting
            builder.HasKey(x => x.Id);
            #endregion
        }
    }
}
