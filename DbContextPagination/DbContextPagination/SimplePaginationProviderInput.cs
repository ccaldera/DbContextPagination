using System.Collections.Generic;

namespace DbContextPagination
{
    public class SimplePaginationProviderInput<TItem> : PaginationProviderInput<TItem>
    {
        public IEnumerable<TItem> Items { get; set; }
    }
}
