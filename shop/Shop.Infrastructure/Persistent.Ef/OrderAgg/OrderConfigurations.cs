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
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "orders");
            
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.UserId);

            builder.OwnsOne(vo => vo.Discount, option =>
            {
                option.Property(p => p.DiscountTitle)
                    .HasMaxLength(50);
            });

            builder.OwnsOne(vo => vo.ShippingMethod, option =>
            {
                option.Property(p => p.ShippimngType)
                    .IsRequired(false)
                    .HasMaxLength(50);
            });

            builder.OwnsMany(b => b.Items, option => 
            {
                option.ToTable("Items", "order");
            });

            builder.OwnsOne(b => b.OrderAddress, option => 
            {
                option.ToTable("Addresses", "order");
                option.HasKey(b => b.Id);

                option.Property(b => b.City)
                    .HasMaxLength(50)
                    .IsRequired();
                    
                option.Property(b => b.Province)
                    .HasMaxLength(50)
                    .IsRequired();
                    
                option.Property(b => b.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                    
                option.Property(b => b.Family)
                    .HasMaxLength(50)
                    .IsRequired();
                    
                option.Property(b => b.NationalCode)
                    .HasMaxLength(10)
                    .IsRequired();
                    
                option.Property(b => b.PhoneNumber)
                    .HasMaxLength(11)
                    .IsRequired();
            });
        }
    }
}