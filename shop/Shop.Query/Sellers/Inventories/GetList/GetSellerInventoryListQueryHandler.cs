using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetList;

public class GetSellerInventoryListQueryHandler : IQueryHandler<GetSellerInventoryListQuery, List<InventoryDto>>
{
    private readonly DapperContext _dapperContext;

    public GetSellerInventoryListQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<InventoryDto>> Handle(GetSellerInventoryListQuery request, CancellationToken cancellationToken)
    {
        var connection = _dapperContext.CreateConnection();
        var inventorySql = @$"SELECT  i.Id, ProductId, Count, Price, DiscountPercentage, i.CreationDate, s.ShopName, p.Title as ProductTitle, p.Imagename as ProductImage
                     FROM {_dapperContext.Inventories} i INNER JOIN {_dapperContext.Sellers} s ON i.SellerId=s.Id INNER JOIN {_dapperContext.Products} p ON i.ProductId=p.id
                     WHERE i.SellerId=@sellerId";

        var inventories = await connection.QueryAsync<InventoryDto>(inventorySql, new {sellerId = request.SellerId});
        
        return inventories.ToList();
    }
}