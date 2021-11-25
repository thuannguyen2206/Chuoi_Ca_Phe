using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.ToTable("ProductOptions").HasKey(x => new { x.OptionId, x.ProductId });
            builder.HasOne(x => x.Option).WithMany(x => x.ProductOptions).HasForeignKey(x => x.OptionId);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductOptions).HasForeignKey(x => x.ProductId);
        }
    }
}
