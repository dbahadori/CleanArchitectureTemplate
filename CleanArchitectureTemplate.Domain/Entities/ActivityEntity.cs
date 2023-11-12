using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces;

namespace CleanArchitectureReferenceTemplate.Domain.Entities
{
    public class ActivityEntity : AuditableEntity
    {
        public ActivityType ActivityType { get; set; }

        public required Guid UserProfileId { get; set; }
        public UserProfileEntity? UserProfile { get; set; }
    }
}
 