using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Role : AuditableEntity
    {
        public required string Name { get; set; }

        public virtual IList<User> Users { get; set; }

    }
}
