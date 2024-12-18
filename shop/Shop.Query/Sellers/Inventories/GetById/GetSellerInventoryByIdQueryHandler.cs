using Common.Query;
using Dapper;
using MediatR;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetById;

internal class GetSellerInventoryByIdQueryHandler : IQueryHandler<GetSellerInventoryByIdQuery, InventoryDto?>
{
    private readonly DapperContext _dapperContext;

    public GetSellerInventoryByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    async Task<InventoryDto?> IRequestHandler<GetSellerInventoryByIdQuery, InventoryDto?>.Handle(GetSellerInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var connection = _dapperContext.CreateConnection();
        var inventorySql = @$"SELECT i.Id, Sellerid, ProductId, Count, Price, i.CreationDate, DiscountPercentage, s.ShopName, p.Title as ProductTitle, p.Imagename as ProductImage
                     FROM {_dapperContext.Inventories} i INNER JOIN {_dapperContext.Sellers} s ON i.SellerId=s.Id INNER JOIN {_dapperContext.Products} p ON i.ProductId=p.id
                     WHERE i.Id=@Id";

        var inventory = await connection.QueryFirstOrDefaultAsync<InventoryDto>(inventorySql, new {id = request.InventoryId});
        if (inventory == null)
            return null;

        return inventory;
    }
}