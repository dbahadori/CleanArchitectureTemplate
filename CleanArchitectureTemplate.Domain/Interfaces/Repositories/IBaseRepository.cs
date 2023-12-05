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
        Task<bool> AddAsync<TModel>(TModel model);
        Task<bool> DeleteAsync<TModel>(TKey key);
        Task<TModel> GetByIdAsync<TModel>(TKey key);
        TModel Update<TModel>(TModel model);
        Task<IEnumerable<TModel>> GetAllAsync<TModel>(Expression<Func<TEntity,
            bool>>? condition = null,
            Expression<Func<TEntity,Object>>? orderBy = null,
            int? pageSize = null,
            int? pageIndex = null,
            bool orderByDescending = false);


    }
}
