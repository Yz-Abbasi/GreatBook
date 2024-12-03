using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders;

    internal static class OrderMapper
    {
        public static OrderDto? Map(this Order? order)
        {
            if(order == null)
                return null;

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
