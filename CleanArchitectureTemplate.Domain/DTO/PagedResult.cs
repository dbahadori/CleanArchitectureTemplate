using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.DTO
{
    public class PagedResult<TModel>
    {
        public IEnumerable<TModel> Items { get; set; }
        public PaginationResponseMetadata Paging { get; set; }
    }
}
