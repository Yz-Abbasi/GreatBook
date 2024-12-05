using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        public bool DoesEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public bool DoesPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}