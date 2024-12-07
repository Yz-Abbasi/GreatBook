using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
    {
        private readonly ShopContext _context;

        public GetSellerByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(o => o.Id).AsQueryable();

            if(!string.IsNullOrWhiteSpace(@params.NationalCode))
                result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));

            if(!string.IsNullOrWhiteSpace(@params.ShopName))
                result = result.Where(r => r.ShopName.Contains(@params.ShopName));

            var skip = (@params.PageId - 1) * @params.Take;

            var sellerResult = new SellerFilterResult()
            {
                FilterParam = @params,
                Data = await result.Skip(skip).Take(@params.Take).Select(seller => seller.Map()).ToListAsync(cancellationToken)
            };

            sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
            return sellerResult;
            

        }
    }
}