using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit;

public class EditUserCommand : IBaseCommand
{
    public EditUserCommand(long id, string name, string lastName, string phoneNumber, string password, string email, IFormFile? avatar, Gender gender)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Password = password;
        Email = email;
        Avatar = avatar;
        Gender = gender;
    }

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public IFormFile? Avatar { get; private set; }
    public Gender Gender { get; private set; }
}