using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(b => b.ProfileDocumentId);

            builder.HasIndex(b => b.ProvinceId);

            builder.HasIndex(b => b.UserIntroducedId);

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(b => b.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.LastName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.Email)
                .HasMaxLength(128);

            builder.Property(b => b.LatinFirstName)
                .HasMaxLength(128);

            builder.Property(b => b.LatinLastName)
                .HasMaxLength(128);

            builder.Property(b => b.Identifier)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.IsActive)
                .HasDefaultValueSql("((1))");

            builder.Property(b => b.IsAdmin)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.IsDelete)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.NickName)
                .HasMaxLength(128);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.PhoneNumberConfirmed)
                .HasDefaultValueSql("((0))");

            builder.Property(b => b.ActivitiesStartYear)
                .HasMaxLength(128);

            builder.Property(b => b.Telephone)
                .HasMaxLength(128);

            builder.Property(b => b.UserGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            builder.HasOne(u => u.ProfileDocument)
                .WithMany(id => id.User)
                .HasForeignKey(u => u.ProfileDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_ImageDocument");

            builder.HasOne(u => u.Province)
                .WithMany(p => p.User)
                .HasForeignKey(u => u.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Province");

            builder.HasOne(u => u.UserIntroduced)
                .WithMany(ui => ui.InverseUserIntroduced)
                .HasForeignKey(u => u.UserIntroducedId)
                .HasConstraintName("FK_User_UserIntroduced");

            builder.HasQueryFilter(b => !b.IsDelete);
        }
    }
}
