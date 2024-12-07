using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetList
{
    public class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
    {
        private readonly ShopContext _context;

        public GetSliderListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.OrderByDescending(o => o.Id).Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                Link = slider.Link,
                Title = slider.Title,
                ImageName = slider.ImageName
            }).ToListAsync();
        }
    }
}