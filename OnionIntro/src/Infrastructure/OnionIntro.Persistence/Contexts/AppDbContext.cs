using Microsoft.EntityFrameworkCore;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x=>x.Price).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<Product>().Property(x=>x.Description).IsRequired(false).HasColumnType("text");
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.SKU).IsRequired().HasMaxLength(10);
            base.OnModelCreating(modelBuilder);
        }
    }
}
