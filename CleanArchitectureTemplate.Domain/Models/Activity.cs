
using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; set; } 
        public ActivityType ActivityType { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
 