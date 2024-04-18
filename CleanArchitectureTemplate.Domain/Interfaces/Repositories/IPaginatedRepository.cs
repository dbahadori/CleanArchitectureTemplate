using CleanArchitectureTemplate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories
{
    public interface IPaginatedRepository<TEntity>
    {

        Task<PagedResult<TEntity>> GetAllPagedAsync(
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            int? pageSize = null,
            int? pageNumber = null,
            bool orderByDescending = false,
            CancellationToken cancellationToken = default(CancellationToken)
         );

    }

}
