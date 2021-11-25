using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class TagInPostConfiguration : IEntityTypeConfiguration<TagInPost>
    {
        public void Configure(EntityTypeBuilder<TagInPost> builder)
        {
            builder.ToTable("TagInPosts").HasKey(x => new { x.PostId, x.TagId });
            builder.HasOne(x => x.Tag).WithMany(x => x.TagInPosts).HasForeignKey(x => x.TagId);
            builder.HasOne(x => x.PostReview).WithMany(x => x.TagInPosts).HasForeignKey(x => x.PostId);
        }
    }
}
