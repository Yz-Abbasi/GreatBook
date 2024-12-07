using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private readonly ShopContext _context;

        public GetSliderByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(f => f.Id == request.SliderId);
            if(slider == null)
                return null;

            return new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                Link = slider.Link,
                Title = slider.Title,
                ImageName = slider.ImageName
            };
        }
    }
}