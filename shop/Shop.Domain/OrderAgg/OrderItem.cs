using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        private OrderItem()
        {
            
        }
        public OrderItem(long inventoryId, int count, int price)
        {
            CountGuard(count);
            PriceGuard(price);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Price * Count;


        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);
            Count = newCount;
        }

        public void IncreaseCount(int count)
        {
            Count += count;
        }
        
        public void DecreaseCount(int count)
        {
            if(Count == 1)
                return ;

            if(Count - count <= 0)
                return ;
                
            Count -= count;
        }

        public void SetPrice(int newPrice)
        {
            Price = newPrice;
        }

        public void PriceGuard(int newPrice)
        {
            if(newPrice < 1)
            {
                throw new InvalidDomainDataException("Item's price is invalid!");
            }
        }

        public void CountGuard(int count)
        {
            if(count < 1 )
                throw new InvalidDomainDataException();
        }
    }
}