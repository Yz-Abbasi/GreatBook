using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities
{
    // public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
    // {
    //     public void Configure(EntityTypeBuilder<ShippingMethod> builder)
    //     {
    //         builder.Property(b => b.ShippimngType)
    //             .HasMaxLength(120).IsRequired();
    //     }
    // }
}