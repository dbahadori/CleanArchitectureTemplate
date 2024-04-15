using AutoMapper;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        private IActivityRepository? _activityRepository;
        private IBookmarkRepository? _bookmarkRepository;
        private IRecipeRepository? _recipeRepository;
        private IIngredientRepository? _ingredientRepository;
        private ISessionRepository? _sessionRepository;
        private ISettingRepository? _settingRepository;
        private IUserProfileRepository? _userProfileRepository;
        private IUserRepository? _userRepository;
        private IRoleRepository? _roleRepository;


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActivityRepository ActivityRepository => _activityRepository ??= new ActivityRepository(_dbContext);
        public IBookmarkRepository BookmarkRepository => _bookmarkRepository ??= new BookmarkRepository(_dbContext);
        public IRecipeRepository RecipeRepository => _recipeRepository ??= new RecipeRepository(_dbContext);
        public IIngredientRepository IngredientRepository => _ingredientRepository ??= new IngredientRepository(_dbContext);
        public ISessionRepository SessionRepository => _sessionRepository ??= new SessionRepository(_dbContext);
        public ISettingRepository SettingRepository => _settingRepository ??= new SettingRepository(_dbContext);
        public IUserProfileRepository UserProfileRepository => _userProfileRepository ??= new UserProfileRepository(_dbContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);
        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_dbContext);


        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
