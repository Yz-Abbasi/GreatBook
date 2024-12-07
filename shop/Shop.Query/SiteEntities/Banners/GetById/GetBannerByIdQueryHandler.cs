using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById
{
    public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
    {
        private readonly ShopContext _context;

        public GetBannerByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.FirstOrDefaultAsync(f => f.Id == request.BannerId, cancellationToken);
            if(banner == null)
                return null;

            return new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                Link = banner.Link,
                Position = banner.BannerPosition,
                ImageName = banner.ImageName
            };
        }
    }
}