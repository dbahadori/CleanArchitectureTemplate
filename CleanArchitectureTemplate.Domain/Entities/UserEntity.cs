using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class UserEntity : AuditableEntity
    {
        public UserEntity()
        {
            Sessions = new List<SessionEntity>();
            TempData = new List<TempDataEntity>();
            Roles = new List<RoleEntity>();
        }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public ThirdPartyType? ThirdPartyType { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public string? PasswordHash { get; set; }

        public virtual UserProfileEntity? UserProfile { get; set; }

        public virtual IList<SessionEntity> Sessions { get; set; }
        public virtual IList<TempDataEntity> TempData { get; set; }
        public virtual IList<RoleEntity> Roles { get; set; }
    }
}
