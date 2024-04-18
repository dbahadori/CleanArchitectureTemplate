using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Domain.Interfaces.Repositories
{
    public interface IWritableRepository<TEntity, Tkey>
    {
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Add(TEntity entity);

        Task DeleteAsync(Tkey key);
        TEntity Update(TEntity entity);
    }
}
