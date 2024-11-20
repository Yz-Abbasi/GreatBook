using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "orders");

            builder.OwnsOne(vo => vo.Discount, option =>
            {
                option.Property(p => p.DiscountTitle)
                    .HasMaxLength(50);
            });

            builder.OwnsOne(vo => vo.ShippingMethod, option =>
            {
                option.Property(p => p.ShippimngType)
                    .HasMaxLength(50);
            });
        }
    }
}