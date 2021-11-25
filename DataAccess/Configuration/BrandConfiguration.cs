using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.BrandName).HasMaxLength(100);
            builder.Property(x => x.SeoAlias).HasMaxLength(500);
        }
    }
}
