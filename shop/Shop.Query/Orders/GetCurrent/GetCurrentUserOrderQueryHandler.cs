using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetCurrent;

public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto>
{
    private readonly ShopContext _context;
    private readonly DapperContext _dapperContext;

    public GetCurrentUserOrderQueryHandler(ShopContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<OrderDto> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
            var order = await _context.Orders.FirstOrDefaultAsync(f => f.UserId == request.UserId && (f.Status == Domain.OrderAgg.Enums.OrderStatus.Pending || 
                f.Status == Domain.OrderAgg.Enums.OrderStatus.Shipping), cancellationToken);
            if(order == null)
                return null;

            var orderDto = order.Map();
            orderDto.UserFullName = await _context.Users.Where(f => f.Id == order.UserId).Select(s => $"{s.Name} {s.LastName}").FirstAsync(cancellationToken);

            orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
            return orderDto;
    }
}