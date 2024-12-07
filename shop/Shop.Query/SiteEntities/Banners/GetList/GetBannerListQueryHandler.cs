using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetList
{
    public class GetBannerListQueryHandler : IQueryHandler<GetBannerListQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;

        public GetBannerListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.OrderByDescending(o => o.Id).Select(banner => new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                Link = banner.Link,
                Position = banner.BannerPosition,
                ImageName = banner.ImageName
            }).ToListAsync();
        }
    }
}