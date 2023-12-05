using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Models;
using CleanArchitectureTemplate.Domain.ValueObejects;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IUserRepository : IBaseRepository<UserEntity, Guid>
    {
        Task CreateUserAsync(User user);
        Task<User> FindByIdAsync(Guid userId);
        Task<User> FindByEmailAsync(string email);
        Task<User> GetUserWithProfile(Guid userId);
        Task<bool> IsEmailExist(string email);
    }
}
