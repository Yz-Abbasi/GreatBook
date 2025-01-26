using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.Create;

public class CreateProductCommand : IBaseCommand
{
    public string Title { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Description { get; set; }
    public long Categoryid { get; set; }
    public long SubCategoryid { get; set; }
    public long SecondarySubCategoryid { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Dictionary<string, string> Specifications { get; set; }

    // private CreateProductCommand()
    // {
    // }

    // public CreateProductCommand(string title, IFormFile imageFile, string description, long categoryid, long subCategoryid, long secondarySubCategoryid,
    // string slug, SeoData seoData, Dictionary<string, string> specifications)
    // {
    //     Title = title;
    //     ImageFile = imageFile;
    //     Description = description;
    //     Categoryid = categoryid;
    //     SubCategoryid = subCategoryid;
    //     SecondarySubCategoryid = secondarySubCategoryid;
    //     Slug = slug;
    //     SeoData = seoData;
    //     Specifications = specifications;
    // }
}