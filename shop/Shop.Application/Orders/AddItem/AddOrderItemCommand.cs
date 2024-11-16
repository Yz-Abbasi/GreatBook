using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommand : IBaseCommand
    {
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public long UserId { get; private set; }

        
        public AddOrderItemCommand(long inventoryId, int count, long userId)
        {
            InventoryId = inventoryId;
            Count = count;
            UserId = userId;
        }

    }
}