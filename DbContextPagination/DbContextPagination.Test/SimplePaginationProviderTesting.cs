using DbContextPagination.Test.Models;
using DbContextPagination.Test.Providers;
using NUnit.Framework;
using System.Linq;

namespace DbContextPagination.Test
{
    [TestFixture]
    public class SimplePaginationProviderTesting
    {
        private DataProvider _dataProvider;

        public SimplePaginationProviderTesting()
        {
            _dataProvider = new DataProvider();
        }

        [Test]
        public void ShouldReturnSimplePagination()
        {
            var products = _dataProvider.GetProducts();

            var provider = new SimplePaginationProvider<Product>();

            var input = new SimplePaginationProviderInput<Product>
            {
                RequestedPage = 1,
                ResultsPerPage = 3,
                Items = products,
                Where = i => i.Price > 150,
                OrderBy = sorting => sorting.OrderBy(i => i.Description).ThenBy(i => i.Price)
            };

            var page = provider.Get(input);

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

        [Test]
        public void ShouldReturnDbContextPagination()
        {
            var dbContext = _dataProvider.GetProductsMockDbContext();
            
            var provider = new DbContextPaginationProvider<Product>(dbContext);

            var input = new PaginationProviderInput<Product>
            {
                RequestedPage = 1,
                ResultsPerPage = 3,
                Where = i => i.Price > 150,
                OrderBy = sorting => sorting.OrderBy(i => i.Description).ThenBy(i => i.Price)
            };

            var page = provider.Get(input);

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
    }
}
