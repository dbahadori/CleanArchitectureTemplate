using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfiguration
{
    internal sealed class SettingEntityConfiguration : object, IEntityTypeConfiguration<Setting>
    {
        public SettingEntityConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            #region Setting
            builder.HasKey(x => x.Id);
            #endregion
        }
    }
}
