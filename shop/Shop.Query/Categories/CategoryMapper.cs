using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories
{
    public static class CategoryMapper
    {
        public static CategoryDto MapCategory(this Category? category)
        {
            if(category == null)
                return null;

            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                Id = category.Id,
                SeoData = category.SeoData,
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapChildCategories()
            };
        }
        
        public static List<CategoryDto> MapCategory(this List<Category> categories)
        {
            var model = new List<CategoryDto>(); 

            categories.ForEach(category => 
            {
                model.Add(new CategoryDto()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    Id = category.Id,
                    SeoData = category.SeoData,
                    CreationDate = category.CreationDate,
                    Childs = category.Childs.MapChildCategories()
                });
            });

            return model;
        }

        public static List<ChildCategoryDto> MapChildCategories(this List<Category> childCategories)
        {
            var model = new List<ChildCategoryDto>();

            childCategories.ForEach(category =>
            {
                model.Add(new ChildCategoryDto()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    Id = category.Id,
                    SeoData = category.SeoData,
                    CreationDate = category.CreationDate,
                    ParentId = (long)category.ParentId,
                    Childs = category.Childs.MapSecondChildCategories()
                });
            });
            return model;
        }

        private static List<SecondChildCategoryDto> MapSecondChildCategories(this List<Category> secondChildCategories)
        {
            var model = new List<SecondChildCategoryDto>();

            secondChildCategories.ForEach(category =>
            {
                model.Add(new SecondChildCategoryDto()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    Id = category.Id,
                    SeoData = category.SeoData,
                    CreationDate = category.CreationDate,
                    ParentId = (long)category.ParentId,
                });
            });
            return model;
        }
    }
}