using DbContextPagination.Test.Models;
using DbContextPagination.Test.Providers;
using NUnit.Framework;
using System;
using System.Linq;

namespace DbContextPagination.Test
{
    [TestFixture]
    public class DbContextPaginationProviderTesting : BasePaginationProviderTesting
    {

        private DbContextPaginationProvider<Product> _provider;

        public DbContextPaginationProviderTesting()
        {
            var dbContext = DataProvider.GetProductsMockDbContext();

            _provider = new DbContextPaginationProvider<Product>(dbContext);
        }


        [Test]
        public void ShoulReturnValidResultsForFirstPage()
        {
            var input = new PaginationProviderInput<Product>
            {
                RequestedPage = 1,
                ResultsPerPage = 3,
                Where = i => i.Price > 150,
                OrderBy = sorting => sorting.OrderBy(i => i.Description).ThenBy(i => i.Price)
            };

            var page = _provider.Get(input);

            ShoulReturnValidResultsForFirstPage(page);
        }

        [Test]
        public void ShoulReturnValidResultsForMiddlePage()
        {
            var input = new PaginationProviderInput<Product>
            {
                RequestedPage = 2,
                ResultsPerPage = 3,
                OrderBy = sorting => sorting.OrderBy(i => i.Description).ThenBy(i => i.Price)
            };

            var page = _provider.Get(input);

            ShoulReturnValidResultsForMiddlePage(page);
        }

        [Test]
        public void ShoulReturnValidResultsForLastPage()
        {
            var input = new PaginationProviderInput<Product>
            {
                RequestedPage = 2,
                ResultsPerPage = 3,
                Where = i => i.Price > 150,
                OrderBy = sorting => sorting.OrderBy(i => i.Description).ThenBy(i => i.Price)
            };

            var page = _provider.Get(input);

            ShoulReturnValidResultsForLastPage(page);
        }


        [Test]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.Throws(typeof(ArgumentNullException), () => _provider.Get(null));
        }

        [Test]
        public void ShouldThrowExceptionOnEmptyParameters()
        {
            var input = new PaginationProviderInput<Product>();

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _provider.Get(input));
        }
    }
}
