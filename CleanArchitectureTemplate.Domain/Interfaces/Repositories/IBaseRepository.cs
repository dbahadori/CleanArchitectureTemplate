using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        Task<OperationResult> AddAsync<TModel>(TModel model);
        Task<OperationResult> DeleteAsync<TModel>(TKey key);
        OperationResult DeleteAll(IQueryable<TEntity> deleteEntities);
        Task<OperationResult> GetByIdAsync<TModel>(TKey key);
        OperationResult Update<TModel>(TModel entity);
        Task<OperationResult> SaveAsync();
        Task<OperationResult> GetAllAsync<TModel>(Expression<Func<TEntity, bool>>? condition = null,Expression<Func<TEntity, Object>>? orderBy = null, int? pageSize = null, int? pageIndex = null, bool orderByDescending = false);


    }
}
