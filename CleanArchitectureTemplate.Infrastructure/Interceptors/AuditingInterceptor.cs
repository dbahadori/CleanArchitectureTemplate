using CleanArchitectureTemplate.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CleanArchitectureTemplate.Application.Common.Interfaces;

namespace CleanArchitectureTemplate.Infrastructure.Interceptors
{
    internal class AuditingInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public AuditingInterceptor(ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            ApplyAuditing(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            ApplyAuditing(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void ApplyAuditing(DbContext? context)
        {
            if (context == null) return;

            var now = DateTime.UtcNow;

            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is AuditableEntity auditableEntity)
                    {
                        auditableEntity.CreatedBy = _currentUserService.UserId;
                        auditableEntity.CreatedAt = _dateTime.TimeStampNow;
                        auditableEntity.LastModified = _dateTime.TimeStampNow;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is AuditableEntity auditableEntity)
                    {
                        auditableEntity.LastModified = _dateTime.TimeStampNow;
                        auditableEntity.LastModifiedBy = _currentUserService.UserId;
                    }
                }
            }
        }
    }
}
