using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommand : IBaseCommand
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Description { get; set; }
        public long Categoryid { get; set; }
        public long SubCategoryid { get; set; }
        public long SecondarySubCategoryid { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public Dictionary<string, string> Specifications { get; set; }

        public EditProductCommand(long productId, string title, IFormFile imageFile, string description, long categoryid, long subCategoryid, long secondarySubCategoryid, 
        string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            ProductId = productId;
            Title = title;
            ImageFile = imageFile;
            Description = description;
            Categoryid = categoryid;
            SubCategoryid = subCategoryid;
            SecondarySubCategoryid = secondarySubCategoryid;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }
    }
}