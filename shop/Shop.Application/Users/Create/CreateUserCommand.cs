using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommand : IBaseCommand
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }

        
        public CreateUserCommand(string name, string lastName, string phoneNumber, string password, string email, Gender gender)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;
        }
        
    }
}