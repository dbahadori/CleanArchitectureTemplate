

namespace CleanArchitectureReferenceTemplate.Domain.Models
{
    public class Bookmark
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public UserProfile? UserProfile { get; set; }
        public Guid UserProfileId { get; set; }

    }
}