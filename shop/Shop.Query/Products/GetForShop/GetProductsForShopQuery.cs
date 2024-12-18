using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetForShop;

public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterparam>
{
    public GetProductsForShopQuery(ProductShopFilterparam filterParams) : base(filterParams)
    {
    }
}