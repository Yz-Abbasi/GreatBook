using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders;

    internal static class OrderMapper
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                CreationDate = order.CreationDate,
                Id = order.Id,
                Status = order.Status,
                OrderAddress = order.OrderAddress,
                Discount = order.Discount,
                Items = new List<OrderItemDto>(),
                LastUpdate = order.LastUpdate,
                ShippingMethod = order.ShippingMethod,
                UserFullName = "",
                UserId = order.UserId
            };
        }

        public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = @$"SELECT s.ShopName , o.OrderId , o.InventoryId , o.Count , o.Price
                        p.Title as ProductTitle , p.Slug as ProductSlug , p.ImageName as ProductImagename
                        FROM {dapperContext.OrderItems} o 
                        INNER JOIN {dapperContext.Inventories} i ON o.InventoryId=i.Id
                        INNER JOIN {dapperContext.Products} p i.ProductId=p.Id
                        INNER JOIN {dapperContext.Sellers} s i.SellerId=s.Id
                        WHERE o.OrderId=@orderId";

            var result = await connection.QueryAsync<OrderItemDto>(sql, new {OrderId = orderDto.Id});

            return result.ToList();
        }

        public static OrderFilterData MapFilterData(this Order order, ShopContext context)
        {
            var userFullName = context.Users.Where(r => r.Id == order.UserId).Select(u => $"{u.Name} {u.LastName}").First();

            return new OrderFilterData()
            {
                Status = order.Status,
                Id = order.Id,
                CreationDate = order.CreationDate,
                City = order.OrderAddress?.City,
                Province = order.OrderAddress?.Province,
                ShippimngType = order.ShippingMethod?.ShippimngType,
                TotalItemCount = order.ItemCount,
                TotalPrice = order.TotalPrice,
                UserFullName = userFullName,
                UserId = order.UserId
            };
        }
    }
