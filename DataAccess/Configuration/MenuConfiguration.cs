using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DisplayOrder).HasDefaultValue(1);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Link).HasMaxLength(100);
            builder.Property(x => x.SeoAlias).HasMaxLength(500);
        }
    }
}
