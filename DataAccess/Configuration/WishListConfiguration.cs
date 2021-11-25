using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.ToTable("WishLists").HasKey(x => new { x.ProductId, x.UserId });
            builder.Property(x => x.Quantity).HasDefaultValue(1);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
        }
    }
}
