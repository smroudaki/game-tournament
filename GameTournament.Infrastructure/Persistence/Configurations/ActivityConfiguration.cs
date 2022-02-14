using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(b => b.ActivityGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.Property(b => b.CreationDate)
               .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.IsDelete)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.IsActive)
                .HasDefaultValueSql("((1))");

            builder.HasQueryFilter(b => !b.IsDelete);
        }
    }
}
