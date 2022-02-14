using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasIndex(b => b.CategoryId);

            builder.HasIndex(b => b.PostId);

            builder.Property(b => b.PostCategoryGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.PostCategory)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostCategory_Category");

            builder.HasOne(pc => pc.Post)
                .WithMany(p => p.PostCategory)
                .HasForeignKey(pc => pc.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostCategory_Post");
        }
    }
}
