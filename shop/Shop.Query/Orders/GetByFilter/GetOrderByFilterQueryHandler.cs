using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    internal class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
    {
        private readonly ShopContext _context;

        public GetOrderByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}