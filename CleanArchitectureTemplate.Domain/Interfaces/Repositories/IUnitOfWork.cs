using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;

namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        void Rollback();

        IActivityRepository ActivityRepository { get; }
        IBookmarkRepository BookmarkRepository { get; }
        IRecipeRepository RecipeRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        ISessionRepository SessionRepository { get; }
        ISettingRepository SettingRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }

    }
}
