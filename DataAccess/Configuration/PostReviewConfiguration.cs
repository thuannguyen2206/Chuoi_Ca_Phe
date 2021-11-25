using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class PostReviewConfiguration : IEntityTypeConfiguration<PostReview>
    {
        public void Configure(EntityTypeBuilder<PostReview> builder)
        {
            builder.ToTable("PostReviews").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.SeoAlias).HasMaxLength(500);
        }
    }
}
