using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseOrderItemCount;
using Shop.Application.Orders.FinalizeOrder;
using Shop.Application.Orders.IncreaseOrderItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.GetByFilter;
using Shop.Query.Orders.GetById;

namespace Shop.Presentation.Facade.Orders
{
     public class OrderFacade : IOrderFacade
    {
        private readonly IMediator _mediator;

        public OrderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> FinalizeOrderCommand(FinalizeOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> OrderCheckout(CheckoutOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OrderFilterResult?> GetOrderByFilter(OrderFilterParams filterParams)
        {
            return await _mediator.Send(new GetOrderByFilterQuery(filterParams));
        }

        public async Task<OrderDto?> GetOrderById(long orderId)
        {
            return await _mediator.Send(new GetOrderByIdQuery(orderId));
        }
    }
}