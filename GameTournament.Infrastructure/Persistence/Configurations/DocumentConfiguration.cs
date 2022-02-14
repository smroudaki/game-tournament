using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.DocumentGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.Property(b => b.FileName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.IsDelete)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.Path)
                .IsRequired();

            builder.HasQueryFilter(b => !b.IsDelete);
        }
    }
}
