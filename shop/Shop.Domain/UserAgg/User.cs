using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string lastName, string phoneNumber, string password, string email, Gender gender, IDomainUserService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }

        public void Edit(string name, string lastName, string phoneNumber, string email, Gender gender, IDomainUserService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string phoneNumber, string email, string password, IDomainUserService domainService)
        {
            return new User("", "", phoneNumber, password, email, Gender.None, domainService);
        }

        public void AddAddress(UserAddress userAddress)
        {
            userAddress.UserId = Id;
            Addresses.Add(userAddress);
        }

        public void EditAddress(UserAddress userAddress, long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == userAddress.UserId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Given address doesn't exist.");
                
            Addresses.Remove(oldAddress);
            Addresses.Add(userAddress);
        }
        
        public void DeleteAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (address == null)
                throw new NullOrEmptyDomainDataException("Given address doesn't exist.");

            Addresses.Remove(address);
        }

        public void ChargeWallet(Wallet wallet) // Placeholder function, the logic will definitely change later on
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRole(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string email, string phoneNumber, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if(phoneNumber.Length != 11)
                throw new InvalidDomainDataException("Phone number is not valid!");
            if(email.IsValidEmail())
                throw new InvalidDomainDataException("Email is not valid!");

            if(email != Email)
                if(domainService.DoesEmailExist(email))
                    throw new InvalidDomainDataException("Email already exists!");                 

            if(phoneNumber != PhoneNumber)
                if(domainService.DoesEmailExist(phoneNumber))
                    throw new InvalidDomainDataException("Email already exists!");
        }
    }
}