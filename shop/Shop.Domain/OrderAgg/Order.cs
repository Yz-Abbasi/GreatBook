using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public OrderAddress? OrderAddress { get; private set; }
        public OrderDiscount? Discount { get; private set; }


        private Order()
        {

        }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }


        public int TotalPrice 
        { get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);
                if(ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;
                if(Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }
        public int ItemCount => Items.Count;

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            
            if(currentItem != null)
                Items.Remove(currentItem);
        }

        public void EditItem()
        {

        }

        public void ChangeItemCount(long itemId, int newCount)
        {
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if(currentItem == null)
                throw new InvalidDomainDataException("Item doesn't exist!");

            currentItem.ChangeCount(newCount);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Checkout(OrderAddress orderAddress)
        {
            OrderAddress = orderAddress;
        }
    }
}