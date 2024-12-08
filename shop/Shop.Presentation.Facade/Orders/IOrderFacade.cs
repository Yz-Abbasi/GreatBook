using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseOrderItemCount;
using Shop.Application.Orders.FinalizeOrder;
using Shop.Application.Orders.IncreaseOrderItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;

namespace Shop.Presentation.Facade.Orders
{
    public interface IOrderFacade
    {
        Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
        Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
        Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command);
        Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command);
        Task<OperationResult> OrderCheckout(CheckoutOrderCommand command);
        Task<OperationResult> FinalizeOrderCommand(FinalizeOrderCommand command);

        Task<OrderDto?> GetOrderById(long orderId);
        Task<OrderFilterResult?> GetOrderByFilter(OrderFilterParams filterParams);
    }
}