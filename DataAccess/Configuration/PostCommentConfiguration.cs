using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("PostComments").HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.SeoAlias).HasMaxLength(500);

            builder.HasOne(x => x.PostReview).WithMany(x => x.PostComments).HasForeignKey(x => x.PostId);
        }
    }
}
