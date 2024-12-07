using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Title = product.Title,
                ImageName = product.ImageName,
                Description = product.Description,
                Slug = product.Slug,
                SeoData = product.SeoData,
                Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
                {
                    Value = s.Value,
                    Key = s.Key
                }).ToList(),
                Images = product.Images.Select(s => new ProductImageDto()
                {
                    ProductId = s.ProductId,
                    ImageName = s.ImageName,
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    Sequence = s.Sequence
                }).ToList(),
                Category = new ProductCategoryDto()
                {
                    Id = product.Categoryid
                },
                SubCategory = new ProductCategoryDto()
                {
                    Id = product.SubCategoryid
                },
                SecondSubCategory = product.SecondarySubCategoryId != null ? new ProductCategoryDto()
                {
                    Id = (long) product.SecondarySubCategoryId
                } : null

            };
        }
        
        public static ProductFilterData MapListData(this Product product)
        {
            return new ProductFilterData()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Title = product.Title,
                ImageName = product.ImageName,
                Slug = product.Slug,
            };
        }
        
        public static async Task SetCategories(this ProductDto product, ShopContext shopContext)
        {
            var category = await shopContext.Categories.Where(f => f.Id == product.Category.Id).Select(s => new ProductCategoryDto()
            {
                Id = s.Id,
                ParentId = s.ParentId,
                Slug = s.Slug,
                SeoData = s.SeoData,
                Title = s.Title
            }).FirstOrDefaultAsync();

            var subCategory = await shopContext.Categories.Where(f => f.Id == product.SubCategory.Id).Select(s => new ProductCategoryDto()
            {
                Id = s.Id,
                ParentId = s.ParentId,
                Slug = s.Slug,
                SeoData = s.SeoData,
                Title = s.Title
            }).FirstOrDefaultAsync();

            if(product.SecondSubCategory != null)
            {
                var secondSubCategory = await shopContext.Categories.Where(f => f.Id == product.SecondSubCategory.Id).Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    ParentId = s.ParentId,
                    Slug = s.Slug,
                    SeoData = s.SeoData,
                    Title = s.Title
                }).FirstOrDefaultAsync();

                if(secondSubCategory != null)
                {
                    product.SecondSubCategory = secondSubCategory;
                }
            }

            if(category != null)
                product.Category = category;

            if(subCategory != null)
                product.SubCategory = subCategory;

        }
    }
}