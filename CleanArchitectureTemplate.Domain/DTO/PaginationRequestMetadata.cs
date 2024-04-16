using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.DTO
{
    public class PaginationRequestMetadata
    {

        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public bool OrderByDescending { get; set; } = true;
    }
}
