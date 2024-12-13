using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string ? Email { get; private set; }
        public bool IsActive { get; private set; }
        public Gender Gender { get; private set; }
        public string AvatarName { get; private set; }
        public List<UserRole> Roles { get; }
        public List<UserAddress> Addresses { get; }
        public List<Wallet> Wallets { get; }
        public List<UserToken> Tokens { get; }
        
        private User()
        {
            
        }
        public User(string name, string lastName, string phoneNumber, string password, string email, Gender gender, IUserDomainService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;
            IsActive = true;
            AvatarName = "avatar.png";
            Roles = new();
            Wallets= new();
            Addresses = new();
            Tokens = new();
        }

        public void Edit(string name, string lastName, string phoneNumber, string email, Gender gender, IUserDomainService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string phoneNumber, string password, IUserDomainService domainService)
        {
            return new User("", "", phoneNumber, password, null, Gender.None, domainService);
        }

        public void AddAddress(UserAddress userAddress)
        {
            userAddress.UserId = Id;
            Addresses.Add(userAddress);
        }

        public void EditAddress(UserAddress userAddress, long addressId)
        {
            // Possible bug in the method
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Given address doesn't exist.");
                
            oldAddress.Edit(userAddress.Province, userAddress.City, userAddress.PostalCode, userAddress.PostalAddress, userAddress.Name, userAddress.Family, userAddress.PhoneNumber,
            userAddress.NationalCode);
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

        public void setAvatar(string avatarName)
        {
            NullOrEmptyDomainDataException.CheckString(avatarName, nameof(avatarName));
            AvatarName = avatarName;
        }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if(activeTokenCount == 3)
                throw new InvalidDomainDataException("Not allowed to use more than 4 devices");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;

            Tokens.Add(token);
        }

        public void Guard(string email, string phoneNumber, IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if(!string.IsNullOrWhiteSpace(email))
                if(email != Email)
                    if(domainService.DoesEmailExist(email))
                        throw new InvalidDomainDataException("Email already exists!");              

            if(phoneNumber.Length != 11)
                throw new InvalidDomainDataException("Phone number is not valid!");
            if(email.IsValidEmail())
                throw new InvalidDomainDataException("Email is not valid!");


            if(phoneNumber != PhoneNumber)
                if(domainService.DoesEmailExist(phoneNumber))
                    throw new InvalidDomainDataException("Email already exists!");
        }
    }
}