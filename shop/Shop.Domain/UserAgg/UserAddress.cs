using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Common.Domain.ValueObjects;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(string province, string city, string postalCode, string postalAddress, string name, string family, PhoneNumber phoneNumber, string nationalCode)
        {
            Guard(province, city, postalCode, postalAddress, name, family, phoneNumber, nationalCode);
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            IsActive = false;
        }

        public long UserId { get; internal set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public bool IsActive { get; private set; }

        public void Edit(string province, string city, string postalCode, string postalAddress, string name, string family, PhoneNumber phoneNumber, string nationalCode)
        {
            Guard(province, city, postalCode, postalAddress, name, family, phoneNumber, nationalCode);
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }

        public void SetActive() // Placeholder function
        {
            IsActive = !IsActive;
        }

        public void Guard(string province, string city, string postalCode, string postalAddress, string name, string family, PhoneNumber phoneNumber, string nationalCode)
        {
            if(phoneNumber == null)
                throw new NullOrEmptyDomainDataException();

            NullOrEmptyDomainDataException.CheckString(province, nameof(province));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if(IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("National code is not valid!");

        }
    }
}