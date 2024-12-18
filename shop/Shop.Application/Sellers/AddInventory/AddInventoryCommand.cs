using Common.Application;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddInventoryCommand : IBaseCommand
    {
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }


        public AddInventoryCommand(long sellerId, long productId, int count, int price, int? discountPercentage)
        {
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
    }
}