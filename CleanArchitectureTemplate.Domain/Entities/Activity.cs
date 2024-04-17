using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Activity : AuditableEntity
    {
        public ActivityType ActivityType { get; set; }

        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }


    }
}
