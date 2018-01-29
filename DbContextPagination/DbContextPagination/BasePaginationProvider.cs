using DbContextPagination.Contracts;
using System;
using System.Linq;

namespace DbContextPagination
{
    public abstract class BasePaginationProvider<TItem, TInput, TOutput> :    
        IProvider<TInput, TOutput>
        where TInput : PaginationProviderInput<TItem>
        where TOutput : PaginationProviderOutput<TItem>, new()
        
    {
        public TOutput Get(TInput input)
        {
            ValidateInput(input);

            var currentPage = GetCurrentPage(input);

            var resultsPerPage = GetResultsPerPage(input);
            
            var items = GetItems(input);

            var filteredItems = FilterItems(input, items);

            var total = GetTotalItems(filteredItems);

            var orderedItems = SortItems(input, filteredItems);
            
            var paginatedItems = items
                .Skip((currentPage - 1) * resultsPerPage)
                .Take(resultsPerPage);
            
            var output = new TOutput()
            {
                CurrentPage = currentPage,
                Items = paginatedItems,
                ResultsPerPage = resultsPerPage,
                Total = total
            };

            return output;
        }

        protected virtual void ValidateInput(TInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.RequestedPage <= 0)
                throw new ArgumentOutOfRangeException("RequestedPage must be grater than 0");

            if (input.ResultsPerPage <= 0)
                throw new ArgumentOutOfRangeException("ResultsPerPage must be grater than 0");            
        }

        protected virtual int GetCurrentPage(TInput input)
        {
            return input.RequestedPage;
        }

        protected virtual int GetResultsPerPage(TInput input)
        {
            return input.ResultsPerPage;
        }

        protected virtual int GetTotalItems(IQueryable<TItem> items)
        {
            return items.Count();
        }

        protected virtual IQueryable<TItem> SortItems(TInput input, IQueryable<TItem> items)
        {
            if (input.OrderBy != null)
            {
                items = input
                    .OrderBy
                    .Invoke(items)
                    .AsQueryable();
            }
            return items;
        }
        
        protected abstract IQueryable<TItem> GetItems(TInput input);

        protected abstract IQueryable<TItem> FilterItems(TInput input, IQueryable<TItem> items);
    }
}
