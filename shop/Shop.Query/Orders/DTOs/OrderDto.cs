using Common.Query;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs;

public class OrderDto : BaseDto
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime LastUpdate { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public ShippingMethod? ShippingMethod { get; set; }
    public OrderAddress? OrderAddress { get; set; }
    public OrderDiscount? Discount { get; set; }
    
}

public class OrderItemDto : BaseDto
{
    public string ProductTtle { get; set; }
    public string ProductSlug { get; set; }
    public string ProductImageName { get; set; }
    public string ShopName { get; set; }
    public long OrderId { get; internal set; }
    public long InventoryId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int TotalPrice => Price * Count;
}

public class OrderFilterData : BaseDto
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? ShippimngType { get; set; }
    public string? Province { get; set; }
    public string? City { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
}

public class OrderFilterParams : BaseFilterParam
{
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }
}

public class OrderFilterResult : BaseFilter<OrderFilterData, OrderFilterParams>
{

}