using AutoMapper;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers;

[Authorize]
public class UserAddressController : ApiController
{
    private readonly IUserAddressFacade _userAddressFacade;
    private readonly IMapper _mapper;

    public UserAddressController(IUserAddressFacade userAddressFacade, IMapper mapper)
    {
        _userAddressFacade = userAddressFacade;
        _mapper = mapper;
    }

    [HttpGet("{userAddressId}")]
    public async Task<ApiResult<AddressDto?>> GetById(long userAddressId)
    {
        var result = await _userAddressFacade.GetById(userAddressId);

        return QueryResult(result);
    }

    [HttpGet]
    public async Task<ApiResult<List<AddressDto>>> GetList()
    {
        var result = await _userAddressFacade.GetList(User.GetUserId());

        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> AddUserAddress(AddUserAddressViewModel viewModel)
    {
        var command = new AddUserAddressCommand(User.GetUserId(), viewModel.Province, viewModel.City, viewModel.PostalCode, viewModel.PostalAddress, viewModel.Name, 
            viewModel.Family, new PhoneNumber(viewModel.PhoneNumber), viewModel.NationalCode);

        command.UserId = User.GetUserId();

        var result = await _userAddressFacade.AddAddress(command);

        return CommandResult(result);
    }
    
    [HttpDelete("{addressId}")]
    public async Task<ApiResult> DeleteUserAddress(long addressId)
    {
        var userId = User.GetUserId(); // Temp data
        var result = await _userAddressFacade.DeleteAddress(new DeleteUserAddressCommand(userId, addressId));

        return CommandResult(result);
    }
    
    [HttpPut]
    public async Task<ApiResult> Edit(EditUserAddressViewModel viewModel)
    {
        var command = new EditUserAddressCommand(User.GetUserId(), viewModel.Province, viewModel.City, viewModel.PostalCode, viewModel.PostalAddress, viewModel.Name, 
            viewModel.Family, new PhoneNumber(viewModel.PhoneNumber), viewModel.NationalCode, viewModel.Id);

        var result = await _userAddressFacade.EditAddress(command);

        return CommandResult(result);
    }
}