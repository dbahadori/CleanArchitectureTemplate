using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces;

namespace CleanArchitectureReferenceTemplate.Domain.Entities
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

        public virtual IList<BookmarkEntity> Bookmarks { get; private set; }
        public virtual IList<ActivityEntity> Activities { get; set; }


    }

}