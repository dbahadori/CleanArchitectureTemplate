using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class ActivityEntity : AuditableEntity
    {
        public ActivityType ActivityType { get; set; }

        public required Guid UserProfileId { get; set; }
        public UserProfileEntity? UserProfile { get; set; }
    }
}
 