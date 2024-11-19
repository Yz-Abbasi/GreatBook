using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }


        public AddUserAddressCommand(long userId, string province, string city, string postalCode, string postalAddress, string name, string family, PhoneNumber phoneNumber, string nationalCode)
        {
            UserId = userId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
        
    }
}