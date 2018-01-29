using DbContextPagination.Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DbContextPagination.Test.Providers
{
    public class DataProvider
    {
        public IEnumerable<Product> GetProducts()
        {
            return new Product[]
            {
                new Product{ Id = 1, Description = "Laptop", Price = 600 },
                new Product{ Id = 2, Description = "27 inches monitor", Price = 199 },
                new Product{ Id = 3, Description = "Haadset", Price = 60 },
                new Product{ Id = 4, Description = "Pen", Price = 2 },
                new Product{ Id = 5, Description = "Notebook", Price = 4 },
                new Product{ Id = 6, Description = "Watch", Price = 25 },
                new Product{ Id = 7, Description = "Frame", Price = 10 },
                new Product{ Id = 8, Description = "Videogame", Price = 321 },
                new Product{ Id = 9, Description = "Phone", Price = 210 },
                new Product{ Id = 10, Description = "Desk", Price = 13 }
            };
        }

        public ProductsDbContext GetProductsMockDbContext()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            var context = new ProductsDbContext(options);

            var data = GetProducts();

            context.Products.AddRange(data);
            context.SaveChanges();

            return context;
        }
    }
}
