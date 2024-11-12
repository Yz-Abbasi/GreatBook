using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;

namespace Shop.Domain.RoleAgg
{
    public class Role
    {
        public string Title { get; private set; }
        public List<RolePermission> Permissions { get; private set; }
        

        public Role()
        {
            
        }
        public Role(string title, List<RolePermission> permissions)
        {
            Guard(title);
            Title = title;
            Permissions = permissions;
        }
        
        public Role(string title)
        {
            Guard(title);
            Title = title;
        }

    
        public void SetPermission(List<RolePermission> permissions)
        {
            Permissions = permissions;
        }

        public void EditRole(string title)
        {
            Guard(title);
            Title = title;
        }

        public void Guard(string title)
        {
            if(title == null)
                throw new InvalidDomainDataException("Title is null!");
        }
    }
}