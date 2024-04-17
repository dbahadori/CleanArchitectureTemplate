using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.ValueObejects;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class UserProfile : AuditableEntity
    {
        public UserProfile()
        {
            Bookmarks = new List<Bookmark>();
            Activities = new List<Activity>();
        }

        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Address Address { get; private set; }

        public IList<Bookmark> Bookmarks { get; private set; }
        public IList<Activity> Activities { get; private set; }


    }

}