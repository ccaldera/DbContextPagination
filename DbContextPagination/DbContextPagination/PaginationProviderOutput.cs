using System;
using System.Collections.Generic;

namespace DbContextPagination
{
    public class PaginationProviderOutput<TItem>
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int ResultsPerPage { get; set; }
        public IEnumerable<TItem> Items { get; set; }

        public int Pages
        {
            get
            {
                return (int)Math.Ceiling(Total / (decimal)ResultsPerPage);
            }
        }

        public int? PreviousPage
        {
            get
            {
                if (CurrentPage <= 1)
                    return null;
                return CurrentPage - 1;
            }
        }

        public int? NextPage
        {
            get
            {
                if (CurrentPage >= Pages)
                    return null;

                return CurrentPage + 1;
            }
        }

        public bool HasPrevious
        {
            get
            {
                return PreviousPage.HasValue;
            }
        }

        public bool HasNext
        {
            get
            {
                return NextPage.HasValue;
            }
        }
    }
}
