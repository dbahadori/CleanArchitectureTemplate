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
        protected readonly IMapper _mapper;

        public BaseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
            _mapper = mapper;
        }

        public virtual async Task<bool> AddAsync<TModel>(TModel model)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(model);
                await _entitySet.AddAsync(entity);

                return true;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.FailedToAddEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);

            }
        }

        public virtual async Task<bool> DeleteAsync<TModel>(TKey key)
        {

            try
            {
                var entity = await GetEntityByIdAsync(key);
                _entitySet.Remove(entity);
                return true;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.FailedToDeleteEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
        }

        public virtual async Task<TModel> GetByIdAsync<TModel>(TKey Tkey)
        {

            try
            {
                var entity = await GetEntityByIdAsync(Tkey);
                var model = _mapper.Map<TModel>(entity);
                return model;

            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.FailedToGetEntity, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }

        public virtual TModel Update<TModel>(TModel model)
        {

            try
            {
                var entity = _mapper.Map<TEntity>(model);

                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                var updatedModel = _mapper.Map<TModel>(entity);
                return updatedModel;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.UpdateEntityError, typeof(TEntity).Name);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(
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

                IEnumerable<TModel> resultModels;

                if (pageSize.HasValue && pageSize.Value > 0 && pageIndex.HasValue && pageIndex.Value > 0)
                {
                    var paginationResult = await ApplyPagination(query, pageSize.Value, pageIndex.Value).ToListAsync();
                    resultModels = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(paginationResult);
                }
                else
                {
                    var resultList = await query.ToListAsync();
                    resultModels = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(resultList);
                }

                return resultModels;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.FailedToGetAllEntities);
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
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.FailedToGetEntity, entityName);
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
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.InvalidPageSizePageIndex);
                throw new InvalidPageSizePageIndexException()
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
