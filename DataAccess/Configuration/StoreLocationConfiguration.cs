using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class StoreLocationConfiguration : IEntityTypeConfiguration<StoreLocation>
    {
        public void Configure(EntityTypeBuilder<StoreLocation> builder)
        {
            builder.ToTable("StoreLocations").HasKey(x => x.Id);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Address).HasMaxLength(200);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.PhoneNumer).HasMaxLength(50);
            builder.Property(x => x.PhoneNumerOption).HasMaxLength(50);
        }
    }
}
