using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        public long Roleid { get; private set; }
        public Permission Permission { get; private set; }

    }
}