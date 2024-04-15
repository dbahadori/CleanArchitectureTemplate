using CleanArchitectureTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        Task<bool> AddAsync(TEntity model);
        Task<bool> DeleteAsync(TKey key);
        Task<TEntity> GetByIdAsync(TKey key);
        TEntity Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,
            bool>>? condition = null,
            Expression<Func<TEntity,Object>>? orderBy = null,
            int? pageSize = null,
            int? pageIndex = null,
            bool orderByDescending = false);


    }
}
