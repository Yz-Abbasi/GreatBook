using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CategoryAgg;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Childs)
                .WithOne()
                .HasForeignKey(c => c.ParentId);

            builder.OwnsOne(p => p.SeoData, config => 
            {
                config.Property(p => p.MetaDescription)
                    .HasMaxLength(500)
                    .HasColumnName("MetaDescription");

                config.Property(p => p.MetaTitle)
                    .HasMaxLength(300)
                    .HasColumnName("MetaTitle");

                config.Property(p => p.MetaKeyWords)
                    .HasMaxLength(300)
                    .HasColumnName("MetaKeyWords");

                config.Property(p => p.IndexPage)
                    .HasColumnName("IndexPage");

                config.Property(p => p.Canonical)
                    .HasMaxLength(300)
                    .HasColumnName("MetaKeyWords");

                config.Property(p => p.Schema)
                    .HasColumnName("Schema");
            });

        }
    }
}