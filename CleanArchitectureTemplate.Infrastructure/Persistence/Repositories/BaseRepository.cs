using AutoMapper;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using CleanArchitectureTemplate.Resources;
using Ticketing.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.DTO;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> :
        IReadableRepository<TEntity, TKey>,
        IPaginatedRepository<TEntity>,
        IExistenceRepository<TEntity, TKey>,
        IWritableRepository<TEntity, TKey>,
        IDisposable
        where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _entitySet;

        public BaseRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _entitySet = _dbContext.Set<TEntity>();
        }


        #region Private Methods

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

        #endregion


        #region Public Methods

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {

            try
            {
                var entity = await _entitySet.FindAsync(id);
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

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var addedEntity = await _entitySet.AddAsync(entity);
                return addedEntity.Entity;
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
        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                var addedEntity = _entitySet.Add(entity);
                return addedEntity.Entity;

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
        public virtual async Task DeleteAsync(TKey key)
        {
            try
            {
                var entity = await _entitySet.FindAsync(key);
                if (entity != null)
                {
                    _entitySet.Remove(entity);
                }
                else
                {
                    var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.EntityNotFound, typeof(TEntity).Name, "Id", key);
                    throw new EntityNotFoundException()
                        .WithUserFriendlyMessage(localizedMessage)
                        .WithDeveloperDetail(defaultMessage);
                }

            }
            catch (Exception exception) when (exception is InvalidOperationException || exception is EntityNotFoundException)
            {
                throw;
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
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
           Expression<Func<TEntity, bool>>? condition = null,
           Expression<Func<TEntity, object>>? orderBy = null,
           bool orderByDescending = false,
           CancellationToken cancellationToken = default(CancellationToken)
)
        {
            try
            {
                var query = _entitySet.AsQueryable();
                ApplyCondition(ref query, condition);
                ApplyOrderBy(ref query, orderBy, orderByDescending);

                var result = await query.ToListAsync(cancellationToken: cancellationToken);

                return result;
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
        public virtual async Task<PagedResult<TEntity>> GetAllPagedAsync(
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            int? pageSize = null,
            int? pageNumber = null,
            bool orderByDescending = false,
            CancellationToken cancellationToken = default(CancellationToken)
            )
        {
            try
            {
                var query = _entitySet.AsQueryable();

                ApplyCondition(ref query, condition);
                ApplyOrderBy(ref query, orderBy, orderByDescending);

                IEnumerable<TEntity> result;
                int totalCount = 0;

                if (pageSize.HasValue && pageSize.Value > 0 && pageNumber.HasValue && pageNumber.Value > 0)
                {
                    var paginationQuery = ApplyPagination(query, pageSize.Value, pageNumber.Value);
                    var paginationResult = await paginationQuery.ToListAsync();
                    result = paginationResult;
                }
                else
                {
                    var resultList = await query.ToListAsync();
                    result = resultList.Take(7);
                }
                totalCount = await query.CountAsync();
                var pagedResult = new PagedResult<TEntity>
                {
                    Items = result,
                    Paging = new PaginationResponseMetadata
                    {
                        TotalCount = totalCount,
                        PageNumber = pageNumber.HasValue && pageNumber.Value > 0 ? pageNumber.Value : 1,
                        PageSize = pageSize.HasValue && pageSize.Value > 0 ? pageSize.Value : 7,
                        TotalPages = (int)Math.Ceiling((double)totalCount / (pageSize.HasValue && pageSize.Value > 0 ? pageSize.Value : 1))
                    }
                };

                return pagedResult;
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

        public virtual async Task<bool> ExistAsync(TKey id, CancellationToken cancellationToken)
        {
            var entity = await _entitySet.FindAsync(id);
            return entity != null;
        }

        public virtual async Task<bool> ExistsWithConditionsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entitySet.AnyAsync(predicate, cancellationToken);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        #endregion




    }
}
