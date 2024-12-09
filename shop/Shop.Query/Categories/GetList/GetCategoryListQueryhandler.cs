using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList
{
    internal class GetCategoryListQueryhandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryhandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.Where(r => r.ParentId == null).Include(c => c.Childs).ThenInclude(c => c.Childs).OrderByDescending(o => o.Id).ToListAsync(cancellationToken);

            return result.MapCategory();
        }
    }
}