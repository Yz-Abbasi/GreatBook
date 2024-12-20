using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        // public async Task<InventoryResult?> GetInventoryById(long inventoryId)
        // {
        //     return await Context.Inv
        // }

        public async Task<InventoryResult> GetInventoryById(long inventoryId)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

            return await connection.QueryFirstOrDefaultAsync<InventoryResult>
                (sql, new { InventoryId = inventoryId });
        }
    }
}