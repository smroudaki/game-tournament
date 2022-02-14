using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasIndex(b => b.UserId);

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.IsSuccessful)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.PaymentGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.Property(b => b.TrackingToken)
                .HasMaxLength(128);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Payment)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_User");
        }
    }
}
