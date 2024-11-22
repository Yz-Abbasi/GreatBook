using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsMany(b => b.Permissions, option =>
            {
                option.ToTable("Permissions", "permission");
            });
        }
    }
}