using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetails").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x => x.SeoTitle).HasMaxLength(200);
            builder.Property(x => x.SeoAlias).HasMaxLength(500);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductDetails).HasForeignKey(x => x.ProductId);
        }
    }
}
