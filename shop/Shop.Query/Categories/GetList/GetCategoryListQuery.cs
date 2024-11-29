using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;

    internal class GetCategoryListQueryhandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryhandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.OrderByDescending(o => o.Id).ToListAsync(cancellationToken);

            return result.MapCategory();
        }
    }
}