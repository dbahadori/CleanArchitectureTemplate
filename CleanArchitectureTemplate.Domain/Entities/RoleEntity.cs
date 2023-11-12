using CleanArchitectureReferenceTemplate.Domain.Interfaces;


namespace CleanArchitectureReferenceTemplate.Domain.Entities
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
