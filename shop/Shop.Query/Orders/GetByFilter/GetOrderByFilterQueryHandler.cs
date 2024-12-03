using Common.Query;
using Microsoft.EntityFrameworkCore;
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

        public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Orders.OrderByDescending(d => d.Id);

            var @params = request.FilterParams;
            
            if(@params.Status != null)
                result.Where(r => r.Status == @params.Status);
                
            if(@params.UserId != null)
                result.Where(r => r.UserId == @params.UserId);

            if(@params.StartDate != null)
                result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);
                
            if(@params.EndDate != null)
                result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new OrderFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(order => order.MapFilterData(_context)).ToListAsync(cancellationToken),
                FilterParam = @params
            };
            
            return model;
        }
    }
}