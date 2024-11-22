using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InventoryResult> GetInventoryById(long inventoryId)
        {
        // using var connection = _dapperContext.CreateConnection();
        // var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

        // return await connection.QueryFirstOrDefaultAsync<InventoryResult>
        //     (sql, new { InventoryId = inventoryId });

        return new InventoryResult(); // Placeholder
        }
    }
}