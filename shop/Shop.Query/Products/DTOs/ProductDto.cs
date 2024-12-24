using Common.Domain.ValueObjects;
using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Products.DTOs;

public class ProductDto : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public ProductCategoryDto Category { get; set; }
    public ProductCategoryDto SubCategory { get; set; }
    public ProductCategoryDto? SecondSubCategory { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImageDto> Images { get; set; }
    public List<ProductSpecificationDto> Specifications { get; set; }
    
}

public class ProductCategoryDto // This is the category in the product and it doesn't have a child
{
    public long Id { get; set; }
    public long? ParentId { get;  set; }
    public string Title { get;  set; }
    public string Slug { get;  set; }
    public SeoData SeoData { get;  set; }

}