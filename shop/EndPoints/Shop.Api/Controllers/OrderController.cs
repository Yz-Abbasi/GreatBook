using Shop.Api.Infrastructure.Security;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseOrderItemCount;
using Shop.Application.Orders.IncreaseOrderItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Orders.DTOs;
using Shop.Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers;

[Authorize]
public class OrderController : ApiController
{
    private readonly IOrderFacade _orderFacade;

    public OrderController(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }

    [PermissionChecker(Permission.Order_Management)]
    [HttpGet]
    public async Task<ApiResult<OrderFilterResult?>> GetOrderByFilter([FromQuery]OrderFilterParams filterParams)
    {
        var result = await _orderFacade.GetOrderByFilter(filterParams);

        return QueryResult(result);
    }
    
    [HttpGet("Current")]
    public async Task<ApiResult<OrderDto?>> GetCurrentOrder()
    {
        var result = await _orderFacade.GetCurrentOrder(User.GetUserId());

        return QueryResult(result);
    }

    [HttpGet("{orderId}")]
    public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
    {
        var result = await _orderFacade.GetOrderById(orderId);

        return QueryResult(result);
    }
    
    [HttpPost]
    public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
    {
        // command.UserId = ;

        var result = await _orderFacade.AddOrderItem(command);

        return CommandResult(result);
    }
    
    [HttpPost("checkout")]
    public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
    {
        var result = await _orderFacade.OrderCheckout(command);

        return CommandResult(result);
    }
    
    [HttpPut("orderItem/decreaseCount")]
    public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.IncreaseOrderItemCount(command);

        return CommandResult(result);
    }
    
    [HttpPut("orderItem/increaseCount")]
    public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand commnd)
    {
        var result = await _orderFacade.DecreaseOrderItemCount(commnd);

        return CommandResult(result);
    }
    
    [HttpDelete("orderItem/{itemId}")]
    public async Task<ApiResult> RemoveOrderItem(long itemId)
    {
        var result = await _orderFacade.RemoveOrderItem(new RemoveOrderItemCommand(User.GetUserId(), itemId));

        return CommandResult(result);
    }
}