using AutoMapper;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using CleanArchitectureTemplate.Resources;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
        }

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _entitySet.AddAsync(entity);

                return true;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FailedToAddEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);

            }
        }

        public virtual async Task<bool> DeleteAsync(TKey key)
        {

            try
            {
                var entityToRemove = await _entitySet.FindAsync(key);
                if (entityToRemove != null)
                    _entitySet.Remove(entityToRemove);
                else
                    throw new NotFoundException();
                return true;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FailedToDeleteEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {

            try
            {
                if (entity != null)
                    _entitySet.Remove(entity);
                else
                    throw new ArgumentNullException();
                return true;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FailedToDeleteEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey Tkey)
        {

            try
            {
                var entity = await _entitySet.FindAsync(Tkey);
                return entity;

            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FailedToGetEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }

        public virtual TEntity Update(TEntity entity)
        {

            try
            {
                var updatedEntity = _entitySet.Update(entity);
                return updatedEntity.Entity;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.UpdateEntityError, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            int? pageSize = null,
            int? pageIndex = null,
            bool orderByDescending = false)
        {
            try
            {
                var query = _entitySet.AsQueryable();
                ApplyCondition(ref query, condition);
                ApplyOrderBy(ref query, orderBy, orderByDescending);

                IEnumerable<TEntity> resultModels;

                if (pageSize.HasValue && pageSize.Value > 0 && pageIndex.HasValue && pageIndex.Value > 0)
                {
                     resultModels = await ApplyPagination(query, pageSize.Value, pageIndex.Value).ToListAsync();
                }
                else
                {
                    resultModels = await query.ToListAsync();
                }

                return resultModels;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FailedToGetAllEntities);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
        }

        private async Task<TEntity?> GetEntityByIdAsync(TKey Tkey)
        {
            var entityName = typeof(TEntity).Name;

            try
            {
                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var property = Expression.Property(parameter, "Id"); // "Id" is the primary key property name, adjust it if needed
                var keySelector = Expression.Lambda<Func<TEntity, TKey>>(property, parameter);
                var entity = await _entitySet.AsNoTracking().FirstOrDefaultAsync(x => keySelector.Compile()(x)!.Equals(Tkey));
                return entity;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FailedToGetEntity, entityName);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }

        private void ApplyCondition(ref IQueryable<TEntity> query, Expression<Func<TEntity, bool>>? condition)
        {
            if (condition != null)
            {
                query = query.Where(condition);
            }
        }

        private void ApplyOrderBy(ref IQueryable<TEntity> query, Expression<Func<TEntity, object>>? orderBy, bool orderByDescending)
        {
            if (orderBy != null)
            {
                query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }
        }

        private IQueryable<TEntity> ApplyPagination(IQueryable<TEntity> query, int pageSize, int pageIndex)
        {
            if (pageSize <= 0 || pageIndex <= 0)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.InvalidPageSizePageNumber);
                throw new InvalidPageSizePageNumberException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage);
            }

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
