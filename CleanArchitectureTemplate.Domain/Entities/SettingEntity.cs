using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class SettingEntity : AuditableEntity
    {
        public required string Key { get; set; }
        public required string Value { get; set; }

        public Guid SessionId { get; set; }
        public SessionEntity? Session { get; set; }

    }
}