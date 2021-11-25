using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class CodeResetConfiguration : IEntityTypeConfiguration<CodeReset>
    {
        public void Configure(EntityTypeBuilder<CodeReset> builder)
        {
            builder.ToTable("CodeResets").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.IsValid).HasDefaultValue(true);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.ExpireTime).HasDefaultValue(DateTime.Now.AddDays(2));
        }
    }
}
