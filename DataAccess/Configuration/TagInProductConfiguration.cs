using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class TagInProductConfiguration : IEntityTypeConfiguration<TagInProduct>
    {
        public void Configure(EntityTypeBuilder<TagInProduct> builder)
        {
            builder.ToTable("TagInProducts").HasKey(x => new { x.ProductId, x.TagId });
            builder.HasOne(x => x.Tag).WithMany(x => x.TagInProducts).HasForeignKey(x => x.TagId);
            builder.HasOne(x => x.Product).WithMany(x => x.TagInProducts).HasForeignKey(x => x.ProductId);
        }
    }
}
