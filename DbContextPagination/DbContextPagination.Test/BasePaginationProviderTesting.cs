using DbContextPagination.Test.Models;
using DbContextPagination.Test.Providers;
using NUnit.Framework;
using System.Linq;

namespace DbContextPagination.Test
{
    public class BasePaginationProviderTesting
    {
        public DataProvider DataProvider { get; }

        public BasePaginationProviderTesting()
        {
            DataProvider = new DataProvider();
        }

        protected void ShoulReturnValidResultsForFirstPage(PaginationProviderOutput<Product> page)
        {
            Assert.NotNull(page);

            Assert.True(page.CurrentPage == 1);

            Assert.True(page.ResultsPerPage == 3);

            Assert.True(page.Pages == 2);

            Assert.True(page.Total == 4);

            Assert.True(page.Items.Count() == 3);

            Assert.True(page.HasNext == true);

            Assert.True(page.HasPrevious == false);

            Assert.True(page.PreviousPage.HasValue == false);

            Assert.True(page.NextPage.HasValue == true && page.NextPage == 2);
        }

        
        protected void ShoulReturnValidResultsForMiddlePage(PaginationProviderOutput<Product> page)
        {
            Assert.NotNull(page);

            Assert.True(page.CurrentPage == 2);

            Assert.True(page.ResultsPerPage == 3);

            Assert.True(page.Pages == 4);

            Assert.True(page.Total == 10);

            Assert.True(page.Items.Count() == 3);

            Assert.True(page.HasNext == true);

            Assert.True(page.HasPrevious == true);

            Assert.True(page.PreviousPage.HasValue == true && page.PreviousPage.Value == 1);

            Assert.True(page.NextPage.HasValue == true && page.NextPage.Value == 3);
        }

        protected void ShoulReturnValidResultsForLastPage(PaginationProviderOutput<Product> page)
        {
            Assert.NotNull(page);

            Assert.True(page.CurrentPage == 2);

            Assert.True(page.ResultsPerPage == 3);

            Assert.True(page.Pages == 2);

            Assert.True(page.Total == 4);

            Assert.True(page.Items.Count() == 3);

            Assert.True(page.HasNext == false);

            Assert.True(page.HasPrevious == true);

            Assert.True(page.PreviousPage.HasValue == true && page.PreviousPage.Value == 1);

            Assert.True(page.NextPage.HasValue == false);
        }
    }
}
