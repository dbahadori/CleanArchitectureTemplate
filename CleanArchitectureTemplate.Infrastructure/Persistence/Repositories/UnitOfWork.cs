using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IMapper _mapper;
        private IActivityRepository? _activityRepository;
        private IBookmarkRepository? _bookmarkRepository;
        private IRecipeRepository? _recipeRepository;
        private IIngredientRepository? _ingredientRepository;
        private ISessionRepository? _sessionRepository;
        private ISettingRepository? _settingRepository;
        private IUserProfileRepository? _userProfileRepository;
        private IUserRepository? _userRepository;
        private IRoleRepository? _roleRepository;


        public UnitOfWork(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActivityRepository ActivityRepository => _activityRepository ??= new ActivityRepository(_dbContext, _mapper);
        public IBookmarkRepository BookmarkRepository => _bookmarkRepository ??= new BookmarkRepository(_dbContext, _mapper);
        public IRecipeRepository RecipeRepository => _recipeRepository ??= new RecipeRepository(_dbContext, _mapper);
        public IIngredientRepository IngredientRepository => _ingredientRepository ??= new IngredientRepository(_dbContext, _mapper);
        public ISessionRepository SessionRepository => _sessionRepository ??= new SessionRepository(_dbContext, _mapper);
        public ISettingRepository SettingRepository => _settingRepository ??= new SettingRepository(_dbContext, _mapper);
        public IUserProfileRepository UserProfileRepository => _userProfileRepository ??= new UserProfileRepository(_dbContext, _mapper);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext, _mapper);
        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_dbContext, _mapper);


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
