using CleanArchitectureReferenceTemplate.Domain.Entities;


namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ITempDataRepository : IBaseRepository<TempDataEntity, Guid>
    {
    }
}
