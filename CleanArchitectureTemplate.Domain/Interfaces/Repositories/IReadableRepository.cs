using CleanArchitectureTemplate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories
{
    public interface IReadableRepository<TEntity, in TKey>
    {

        Task<TEntity?> GetByIdAsync(TKey id);
        
        Task<IEnumerable<TEntity>> GetAllAsync(
           Expression<Func<TEntity, bool>>? condition = null,
           Expression<Func<TEntity, object>>? orderBy = null,
           bool orderByDescending = false,
           CancellationToken cancellationToken = default(CancellationToken)
        );


    }
}
