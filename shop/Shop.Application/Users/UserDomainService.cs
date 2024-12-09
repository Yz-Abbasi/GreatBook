using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool DoesEmailExist(string email)
        {
            return _repository.Exists(r => r.Email == email);
        }

        public bool DoesPhoneNumberExist(string phoneNumber)
        {
            return _repository.Exists(r => r.PhoneNumber == phoneNumber);
        }
    }
}