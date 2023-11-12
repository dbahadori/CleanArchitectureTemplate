using Microsoft.EntityFrameworkCore;
using CleanArchitectureReferenceTemplate.Domain.Entities;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        #region DbSet

        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<UserEntity> Users { get; set; } 
        public DbSet<RoleEntity> Roles { get; set; } 

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (assembly: typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
