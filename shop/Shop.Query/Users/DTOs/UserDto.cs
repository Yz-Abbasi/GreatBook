using Common.Query;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Query.Users.DTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public string AvatarName { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }

    public class UserRoleDto
    {
        public string RoleTitle { get; set; }
        public long RoleId { get; set; }
    }

    public class UserFilterData : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public string AvatarName { get; set; }
    }

    public class UserFilterResult : BaseFilter<UserFilterData, UserFilterParams>
    {
    }

    public class UserFilterParams : BaseFilterParam
    {
        public long? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}