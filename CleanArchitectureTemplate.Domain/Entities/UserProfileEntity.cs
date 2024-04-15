using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.ValueObejects;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class UserProfileEntity : AuditableEntity
    {
        public UserProfileEntity()
        {
            Bookmarks = new List<BookmarkEntity>();
            Activities = new List<ActivityEntity>();

        }

        public required Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public Address Address { get; private set; }

        public virtual IList<BookmarkEntity> Bookmarks { get; private set; }
        public virtual IList<ActivityEntity> Activities { get; set; }


    }

}