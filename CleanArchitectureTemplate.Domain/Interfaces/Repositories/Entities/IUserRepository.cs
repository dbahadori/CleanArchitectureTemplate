using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.ValueObejects;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IUserRepository :
        IReadableRepository<User, Guid>,
        IWritableRepository<User, Guid>,
        IPaginatedRepository<User>,
        IExistenceRepository<User, Guid>
    {
        Task<User?> FindByEmailAsync(string email);
        Task<User> GetUserWithProfile(Guid userId);
        Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken);
        Task<User?> GetUserWithRolesByUsernameAsync(string userName);
    }
}
