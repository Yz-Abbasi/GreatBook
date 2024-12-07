using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter
{
    public class GetProductByFilterQueryHandler : IQueryHandler<GetProductByFilterQuery, productFilterResult>
    {
        private readonly ShopContext _context;

        public GetProductByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<productFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Products.OrderByDescending(d => d.Id).AsQueryable();

            if(!string.IsNullOrWhiteSpace(@params.Slug))
                result = result.Where(r => r.Slug == @params.Slug);

            if(!string.IsNullOrWhiteSpace(@params.Title))
                result = result.Where(r => r.Title == @params.Title);

            if(@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            var skip = (@params.PageId - 1) * @params.Take;

            var model = new productFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(s => s.MapListData()).ToListAsync(cancellationToken),
                FilterParam = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);

            return model;
        }
    }
}