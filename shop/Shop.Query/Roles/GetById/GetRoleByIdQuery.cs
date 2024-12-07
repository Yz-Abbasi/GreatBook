using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById
{
    public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto>;
}