using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price).HasColumnType("decimal(6,2)");
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("text");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SKU).IsRequired().HasMaxLength(10);
        }
    }

}
