using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EmailConfirmed).HasDefaultValue(false);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.Property(x => x.IsAdmin).HasDefaultValue(false);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(200);
        }
    }
}
