using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;


namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IUserRepository : IBaseRepository<UserEntity, Guid>
    {
        Task<OperationResult> CreateUserAsync(User user, string password);
        Task<OperationResult> ValidateCredentialsAsync(string email, string password);
        Task<OperationResult> FindByIdAsync(Guid userId);
        Task<OperationResult> FindByEmailAsync(string email);
        Task<OperationResult> GetUserWithProfile(Guid userId);
        Task<OperationResult> IsEmailExist(string email);
    }
}
