using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Setting : AuditableEntity
    {
        public required string Key { get; set; }
        public required string Value { get; set; }

        public Session? Session { get; set; }
        public Guid SessionId { get; set; }
    }
}