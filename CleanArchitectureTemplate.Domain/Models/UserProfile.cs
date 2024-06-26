using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.ValueObejects;

namespace CleanArchitectureTemplate.Domain.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            Bookmarks = new List<Bookmark>();
            Activities = new List<Activity>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public Address Address { get; private set; }

        public IList<Bookmark> Bookmarks { get; private set; }
        public  IList<Activity> Activities { get; set; }
 

    }

}