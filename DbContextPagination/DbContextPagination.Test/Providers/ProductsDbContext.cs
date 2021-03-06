﻿using DbContextPagination.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextPagination.Test.Providers
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set;}
    }
}
