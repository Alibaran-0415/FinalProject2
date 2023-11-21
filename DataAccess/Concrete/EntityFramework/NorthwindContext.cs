using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tablolarıyla proje class'larını bağlamak.
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
        public DbSet<Product>Products { get; set; }

        public DbSet<Category>Categories { get; set; }

        public DbSet<Customer>Customers { get; set; }

        public DbSet<Order>Orders { get; set; }
    }
}
