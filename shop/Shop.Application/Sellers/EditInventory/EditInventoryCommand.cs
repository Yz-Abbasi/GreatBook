using Common.Application;

namespace Shop.Application.Sellers.EditInventory;

public class EditInventoryCommand : IBaseCommand
{
    public long SellerId { get; private set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }

// NOTE : editing inventory requires productId instead of inventoryId, find the mistake if time is available 
    public EditInventoryCommand(long sellerId, long inventoryId, int count, int price, int? discountPercentage)
    {
        SellerId = sellerId;
        InventoryId = inventoryId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }
    
}