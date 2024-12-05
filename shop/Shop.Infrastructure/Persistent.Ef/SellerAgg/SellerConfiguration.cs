using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "seller");

            builder.HasIndex(i => i.NationalCode).IsUnique();

            builder.Property(p => p.ShopName)
                .IsRequired();

            builder.Property(p => p.NationalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.OwnsMany(t => t.Inventories, option =>
            {
                option.ToTable("Inventories", "seller");

                option.HasKey(k => k.Id);

                option.HasKey(k => k.Id);
                option.HasIndex(i => i.ProductId);
                option.HasIndex(i => i.SellerId);
            });
        }
    }
}