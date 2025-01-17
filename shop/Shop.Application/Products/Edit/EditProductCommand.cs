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
        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Description { get; private set; }
        public long Categoryid { get; private set; }
        public long SubCategoryid { get; private set; }
        public long SecondarySubCategoryid { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specifications { get; private set; }

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