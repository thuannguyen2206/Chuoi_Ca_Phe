using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options").HasKey(x => x.Id);
            builder.Property(x => x.NameOption).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SeoAlias).HasMaxLength(500);
        }
    }
}
