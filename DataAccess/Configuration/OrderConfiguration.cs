using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CustomerAddress).HasMaxLength(200);
            builder.Property(x => x.CustomerAddressOption).HasMaxLength(200);
            builder.Property(x => x.CustomerName).HasMaxLength(100);
            builder.Property(x => x.CustomerPhoneNumber).HasMaxLength(20);
            builder.Property(x => x.CustomerEmail).HasMaxLength(200);
        }
    }
}
