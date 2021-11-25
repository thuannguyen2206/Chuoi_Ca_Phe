using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.Product).WithMany(x => x.CartItems).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId);
        }
    }
}
