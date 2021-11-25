using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class GiftExchangeConfiguration : IEntityTypeConfiguration<GiftExchange>
    {
        public void Configure(EntityTypeBuilder<GiftExchange> builder)
        {
            builder.ToTable("GiftExchanges").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
