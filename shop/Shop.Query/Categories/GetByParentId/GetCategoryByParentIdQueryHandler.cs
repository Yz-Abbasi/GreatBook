using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryByParentIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.Where(f => f.Id == request.ParentId).ToListAsync();

            return result.MapChildCategories();
        }
    }
}