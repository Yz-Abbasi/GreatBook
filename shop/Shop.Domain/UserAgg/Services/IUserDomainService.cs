using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        public bool DoesEmailExist(string email);
        public bool DoesPhoneNumberExist(string phoneNumber);
    }
}