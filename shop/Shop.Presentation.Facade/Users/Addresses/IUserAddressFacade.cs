using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;

namespace Shop.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);

        Task<OperationResult> EditAddress(EditUserAddressCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);   
    }
}