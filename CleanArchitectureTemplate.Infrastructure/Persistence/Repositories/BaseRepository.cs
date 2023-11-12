using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;
using CleanArchitectureReferenceTemplate.Infrastructure.Extentions;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entitye;
        protected readonly IMapper _mapper;

        public BaseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _entitye = _context.Set<TEntity>();
            _mapper = mapper;
        }

        public virtual async Task<OperationResult> AddAsync<TModel>(TModel model)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(model);

                await _entitye.AddAsync(entity);

                return OperationResult<TModel>.Success(model);
            }
            catch (Exception execption)
            {
                return OperationResult<TModel>.Failure(model, execption);
            }
        }


        public virtual async Task<OperationResult> DeleteAsync<TModel>(TKey key)
        {
            try
            {
                var entityResult = (OperationResult<TEntity>)await GetByIdAsync<TModel>(key); ;
                if (entityResult.IsSuccessful)
                {
                    _entitye.Remove(entityResult.Data!);
                    return OperationResult.Success();

                }
                else
                    return OperationResult.Failure(new NotFoundException(_entitye.ToString()!, key!));

            }
            catch (Exception exception)
            {
                return OperationResult.Failure(exception);
            }
        }

        public virtual OperationResult DeleteAll(IQueryable<TEntity> deleteEntities)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(deleteEntities.AsEnumerable());
                return OperationResult.Success();
            }
            catch (Exception exception)
            {
                return OperationResult.Failure(exception);

            }
        }

        public virtual async Task<OperationResult> GetByIdAsync<TModel>(TKey Tkey)
        {
            // TODO : Add AsNoTracking() to this method
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, "Id"); // "Id" is the primary key property name, adjust it if needed
            var keySelector = Expression.Lambda<Func<TEntity, TKey>>(property, parameter);
            //eturn _entity.AsNoTracking().Where(x=> x.ty);

            //var res = _entitye.FindAsync(Tkey);
            var entity = await _entitye.AsNoTracking().FirstOrDefaultAsync(x => keySelector.Compile()(x)!.Equals(Tkey));
            
            if (entity == null)
                return OperationResult.Failure(new NotFoundException(_entitye.ToString()!, Tkey!));

            else
            {
                var model = _mapper.Map<TModel>(entity);
                return OperationResult<TModel>.Success(model);
            }
        }

        public virtual async Task<OperationResult> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return OperationResult.Success();
            }
            catch (Exception exception)
            {
                return OperationResult.Failure(exception);
            }
        }


        public virtual OperationResult Update<TModel>(TModel model)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(model);

                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                var resultModel = _mapper.Map<TModel>(entity);
                return OperationResult<TModel>.Success(resultModel);
            }
            catch (Exception execption)
            {
                return OperationResult<TModel>.Failure(model, execption);
            }

        }
        private void UpdateNavigationProperties(EntityEntry<TEntity> entry, TEntity entityToUpdate)
        {
            var navigations = entry.Navigations.ToList();

            foreach (var navigation in navigations)
            {
                var navigationPropertyName = navigation.Metadata.Name;
                var relatedEntity = navigation.CurrentValue;
                var relatedEntityToUpdate = GetRelatedEntity(entityToUpdate, navigationPropertyName);

                if (relatedEntityToUpdate != null)
                {
                    if (!relatedEntity.Equals(relatedEntityToUpdate))
                    {
                        navigation.CurrentValue = relatedEntityToUpdate;
                    }
                }
                else
                {
                    navigation.CurrentValue = null;
                }
            }
        }
        private object GetRelatedEntity(TEntity entityToUpdate, string navigationPropertyName)
        {
            var relatedEntityProperty = typeof(TEntity).GetProperty(navigationPropertyName);
            var relatedEntity = relatedEntityProperty.GetValue(entityToUpdate);
            return relatedEntity;
        }

        private static object[] GetPrimaryKeys<T>(DbContext context, T value)
        {
            var keyNames = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                      .Select(x => x.Name).ToArray();
            var result = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                result[i] = typeof(T).GetProperty(keyNames[i])?.GetValue(value);
            }
            return result;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<OperationResult> GetAllAsync<TModel>(
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity,object>>? orderBy = null,
            int? pageSize = null , 
            int? pageIndex = null,
            bool orderByDescending = false
)
        {

            var query = _entitye.AsQueryable();
            if (condition != null)
            {
                query = query.Where(condition);
            }

            if (orderBy != null)
            {

                query = orderByDescending ? query.OrderByDescending(orderBy): query.OrderBy(orderBy);
            }

            IEnumerable<TModel> resultModel;
            if (pageSize.HasValue && pageSize.Value > 0 && pageIndex.HasValue && pageIndex.Value > 0)
            {
                var paginationResult = await query.Pagination(pageSize.Value, pageIndex.Value).ToListAsync();

                resultModel = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(paginationResult);

            }
            else
            {
                var resultList = await query.ToListAsync();
                resultModel = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(resultList);

            }


            return OperationResult<IEnumerable<TModel>>.Success(resultModel);
        }

    }
}
