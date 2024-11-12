using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {

        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        
        public SellerInventory(long productId, int count, int price)
        {
            if(price < 1 || count < 1)
                throw new InvalidDomainDataException("Price or the count is lower than 1 !");
                
            ProductId = productId;
            Count = count;
            Price = price;
        }
    }
}