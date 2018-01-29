using System;
using System.Linq;
using System.Linq.Expressions;

namespace DbContextPagination
{
    public class PaginationProviderInput<TItem>
    {
        public int RequestedPage { get; set; }
        public int ResultsPerPage { get; set; }
        public Expression<Func<TItem, bool>> Where { get; set; }
        public Func<IQueryable<TItem>, IOrderedQueryable<TItem>> OrderBy { get; set; }
    }
}
