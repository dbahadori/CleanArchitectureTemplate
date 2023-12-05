using CleanArchitectureTemplate.Domain.Interfaces;


namespace CleanArchitectureTemplate.Domain.Entities
{
    public class RoleEntity : AuditableEntity
    {
        public RoleEntity()
        {
            Users = new List<UserEntity>();
        }

        public required string Name { get; set; }

        public virtual IList<UserEntity> Users { get; set; }
    }
}
