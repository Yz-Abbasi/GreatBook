using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Products.DTOs;

public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterparam>
{
    public CategoryDto? CategoryDto { get; set; }
}

public class ProductShopDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public long InventoryId { get; set; }
    public int BookCount { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string ImageName { get; set; }
    public int TotalPrice 
    { 
        get
        {
            var discount = Price * DiscountPercentage / 100;
            return discount;
        } 
    }
}

public class ProductShopFilterparam : BaseFilterParam
{
    public string? Slug { get; set; }
    public string? Search { get; set; }
    public bool OnlyAvailableProducts { get; set; } = false;
    public bool OnlyDiscountedProducts { get; set; } = false;
    public ProductSearchOrderBy ProductSearchOrderBy { get; set; }
} 

public enum ProductSearchOrderBy
{
    Latest,
    Cheapest,
    MostExpensive
}