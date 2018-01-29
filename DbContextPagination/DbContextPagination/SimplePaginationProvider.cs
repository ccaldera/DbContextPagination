using System.Linq;

namespace DbContextPagination
{
    public class SimplePaginationProvider<TItem> :
        BasePaginationProvider<TItem, SimplePaginationProviderInput<TItem>, PaginationProviderOutput<TItem>>
    {
        protected override IQueryable<TItem> FilterItems(SimplePaginationProviderInput<TItem> input, IQueryable<TItem> items)
        {
            if (input.Where != null)
            {
                var wherePredicate = input
                    .Where;

                items = items.Where(wherePredicate);
            }
            return items;
        }

        protected override IQueryable<TItem> GetItems(SimplePaginationProviderInput<TItem> input)
        {
            return input.Items.AsQueryable();
        }
    }
}
