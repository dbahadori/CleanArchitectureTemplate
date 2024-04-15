using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Bookmark : AuditableEntity
    {

        public string? Description { get; set; }

        public UserProfile? UserProfile { get; set; }
        public Guid UserProfileId { get; set; }

    }
}