
using CleanArchitectureReferenceTemplate.Domain.Enums;

namespace CleanArchitectureReferenceTemplate.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; set; } 
        public ActivityType ActivityType { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
 