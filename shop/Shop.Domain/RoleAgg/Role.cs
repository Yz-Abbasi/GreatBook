using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.RoleAgg;

public class Role : AggregateRoot
{
    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }
    

    private Role()
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
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
    }
}