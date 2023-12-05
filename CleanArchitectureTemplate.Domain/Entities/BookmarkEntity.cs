using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class BookmarkEntity : AuditableEntity
    {
        public string? Description { get; set; }


        public required Guid UserProfileId { get; set; }
        public UserProfileEntity? UserProfile { get; set; }


    }
}