﻿using DbContextPagination.Test.Models;
using DbContextPagination.Test.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbContextPagination.Test
{
    [TestFixture]
    public class SimplePaginationProviderTesting : BasePaginationProviderTesting
    {
        private SimplePaginationProvider<Product> _provider;
        private IEnumerable<Product> _items;

        public SimplePaginationProviderTesting()
        {
            _provider = new SimplePaginationProvider<Product>();

            _items = DataProvider.GetProducts();
        }

        [Test]
        public void ShoulReturnValidResultsForFirstPage()
        {
            var input = new SimplePaginationProviderInput<Product>
            {
                Items = _items,
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
            var input = new SimplePaginationProviderInput<Product>
            {
                Items = _items,
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
            var input = new SimplePaginationProviderInput<Product>
            {
                Items = _items,
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
            var input = new SimplePaginationProviderInput<Product>();

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _provider.Get(input));
        }
    }
}
