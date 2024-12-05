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
        private RolePermission()
        {
        }
        public RolePermission(Permission permission)
        {
            Permission = permission;
        }

        public long Roleid { get; internal set; }
        public Permission Permission { get; private set; }

    }
}