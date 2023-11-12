using CleanArchitectureReferenceTemplate.Domain.Entities;


namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ISettingRepository : IBaseRepository<SettingEntity , Guid>
    {
    }
}
