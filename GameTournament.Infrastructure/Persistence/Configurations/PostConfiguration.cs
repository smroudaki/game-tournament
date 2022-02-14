using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(b => b.CoverDocumentId);

            builder.HasIndex(b => b.UserId);

            builder.Property(b => b.Abstract)
                .IsRequired();

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.IsDelete)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.IsShow)
                .HasDefaultValueSql("((1))");

            builder.Property(b => b.PostGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.Property(b => b.Title)
                .IsRequired();

            builder.HasOne(p => p.CoverDocument)
                .WithMany(cd => cd.Post)
                .HasForeignKey(p => p.CoverDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_CoverDocument");

            builder.HasOne(p => p.User)
                .WithMany(u => u.Post)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");

            builder.HasQueryFilter(b => !b.IsDelete);
        }
    }
}
