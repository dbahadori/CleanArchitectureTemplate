using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Extentions
{
    public static class PaginateCollection
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> list, int pageSize, int pageIndex = 1) => list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        public static List<T> Pagination<T>(this List<T> list, int pageSize, int pageIndex = 1) => list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        public static IEnumerable<T> Pagination<T>(this IEnumerable<T> list, int pageSize, int pageIndex = 1) => list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }
}
