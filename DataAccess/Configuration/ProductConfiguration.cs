using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.OrderCount).HasDefaultValue(0);
            builder.Property(x => x.CodeProduct).HasMaxLength(100);

            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
