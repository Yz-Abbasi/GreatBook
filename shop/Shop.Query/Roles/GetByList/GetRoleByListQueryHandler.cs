using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetByList
{
    public class GetRoleByListQueryHandler : IQueryHandler<GetRoleByListQuery, List<RoleDto>>
    {
        private readonly ShopContext _context;

        public GetRoleByListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDto>> Handle(GetRoleByListQuery request, CancellationToken cancellationToken)
        {return await _context.Roles.Select(role => new RoleDto()
        {
                Id = role.Id,
                CreationDate = role.CreationDate,
                Permissions = role.Permissions.Select(s => s.Permission).ToList(),
                Title = role.Title
        }).ToListAsync(cancellationToken);
        }
    }
}