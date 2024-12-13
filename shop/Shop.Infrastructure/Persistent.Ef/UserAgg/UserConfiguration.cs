using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "user");
            builder.HasIndex(p => p.PhoneNumber).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(p => p.Email)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(p => p.Name)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired(false)
                .HasMaxLength(60);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsMany(t => t.Addresses, option =>
            {
                option.ToTable("Addresses", "user");
                builder.HasIndex(p => p.Id).IsUnique();

                option.Property(b => b.Province)
                     .IsRequired().HasMaxLength(100);

                option.Property(b => b.City)
                    .IsRequired().HasMaxLength(100);

                option.Property(b => b.Name)
                   .IsRequired().HasMaxLength(50);

                option.Property(b => b.Family)
                    .IsRequired().HasMaxLength(50);

                option.Property(b => b.NationalCode)
                    .IsRequired().HasMaxLength(10);

                option.Property(b => b.PostalCode)
                    .IsRequired().HasMaxLength(20);

                option.OwnsOne(t => t.PhoneNumber, config =>
                {
                    config.Property(p => p.Phone)
                        .HasColumnName("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);
                });
            });

            builder.OwnsMany(t => t.Wallets, option =>
            {
                option.ToTable("Wallets", "user");
                builder.HasIndex(p => p.Id).IsUnique();

                option.Property(p => p.Description)
                    .IsRequired(false)
                    .HasMaxLength(500);
            });

            builder.OwnsMany(t => t.Roles, option => 
            {
                option.ToTable("Role", "user");
                builder.HasIndex(p => p.Id).IsUnique();
            });
        }
    }
}