using CleanArchitectureTemplate.Domain.Entities;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ISessionRepository : IBaseRepository<SessionEntity , Guid>
    {
    }
}
