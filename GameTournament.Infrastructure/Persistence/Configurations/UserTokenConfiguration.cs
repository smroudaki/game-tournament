using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasIndex(b => b.UserId);

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.Value)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.UserTokenGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.UserToken)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToken_User");
        }
    }
}
