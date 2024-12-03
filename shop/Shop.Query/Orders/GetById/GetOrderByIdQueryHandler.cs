using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly ShopContext _context;
        private readonly DapperContext _dapperContext;

        public GetOrderByIdQueryHandler(ShopContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(f => f.Id == request.OrderId, cancellationToken);
        }
    }
}