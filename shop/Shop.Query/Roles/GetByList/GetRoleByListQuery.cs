

using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetByList
{
    public record GetRoleByListQuery : IQuery<List<RoleDto>>;
}