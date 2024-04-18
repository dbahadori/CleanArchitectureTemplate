using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories
{
    public interface IExistenceRepository<TEntity, in Tkey>
    {
        Task<bool> ExistAsync(Tkey entityId, CancellationToken cancellationToken);
        Task<bool> ExistsWithConditionsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
