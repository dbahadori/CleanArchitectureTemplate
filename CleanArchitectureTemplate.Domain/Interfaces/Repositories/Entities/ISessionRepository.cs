using CleanArchitectureReferenceTemplate.Domain.Entities;


namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ISessionRepository : IBaseRepository<SessionEntity , Guid>
    {
    }
}
