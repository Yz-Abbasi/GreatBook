using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(p => p.ImageName)
            .IsRequired()
            .HasMaxLength(200);
            
            builder.Property(p => p.Link)
            .IsRequired()
            .HasMaxLength(500);
            
            builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(500);
        }
    }
}