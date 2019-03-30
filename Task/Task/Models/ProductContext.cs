using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class ProductContext: DbContext
    {
        public ProductContext() : base("ProductEntites")
        {
        }

        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}