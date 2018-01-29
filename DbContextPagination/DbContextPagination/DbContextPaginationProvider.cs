using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DbContextPagination
{
    public class DbContextPaginationProvider<TItem> : 
        BasePaginationProvider<TItem, PaginationProviderInput<TItem>, PaginationProviderOutput<TItem>>
        where TItem : class, new()
    {
        protected DbContext DbContext { get; }

        public DbContextPaginationProvider(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            DbContext = dbContext;
        }
        
        protected override IQueryable<TItem> GetItems(PaginationProviderInput<TItem> input)
        {
            var items = DbContext
                .Set<TItem>()
                .AsQueryable();

            return items;
        }

        protected override IQueryable<TItem> FilterItems(PaginationProviderInput<TItem> input, IQueryable<TItem> items)
        {
            if (input.Where != null)
            {
                items = items.Where(input.Where);
            }
            return items;
        }
    }
}