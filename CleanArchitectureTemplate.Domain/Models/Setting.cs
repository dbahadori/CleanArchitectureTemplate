namespace CleanArchitectureReferenceTemplate.Domain.Models
{
    public class Setting
    {
        public Guid Id { get; set; }
        public required string Key { get; set; }
        public required string Value { get; set; }

        public Session? Session { get; set; }
        public Guid SessionId { get; set; }
    }
}