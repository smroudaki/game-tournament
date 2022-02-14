using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(b => b.ParentCategoryId);

            builder.Property(b => b.CategoryGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.Property(b => b.CreationDate)
               .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.IsDelete)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.IsActive)
                .HasDefaultValueSql("((1))");

            builder.HasOne(c => c.ParentCategory)
                .WithMany(pc => pc.InverseParentCategory)
                .HasForeignKey(c => c.ParentCategoryId)
                .HasConstraintName("FK_Category_ParentCategory");

            builder.HasQueryFilter(b => !b.IsDelete);
        }
    }
}
