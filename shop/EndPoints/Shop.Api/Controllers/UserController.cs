using AutoMapper.Configuration.Annotations;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Create;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using Shop.Api.Infrastructure.Security;
using Shop.Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.Edit;
using Shop.Api.ViewModels.Users;

namespace Shop.Api.Controllers;

[Authorize]
public class UserController : ApiController
{
    private readonly IUserFacade _userFacade;

    public UserController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [HttpGet]
    [PermissionChecker(Permission.User_Management)]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery]UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);

        return QueryResult(result);
    }

    [HttpGet("{userId}")]
    [PermissionChecker(Permission.User_Management)]
    public async Task<ApiResult<UserDto?>> GetById(long userId)
    {
        var result = await _userFacade.GetUserById(userId);

        return QueryResult(result);
    }

    [Authorize]
    [HttpGet("Current")]
    public async Task<ApiResult<UserDto>> GetCurrentUser()
    {
        var result = await _userFacade.GetUserById(User.GetUserId());

        return QueryResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);

        return CommandResult(result);
    }
    
    [PermissionChecker(Permission.User_Management)]
    [HttpPut]
    public async Task<ApiResult> Edit(EdituserViewModel command)
    {
        var result = await _userFacade.EditUser(new EditUserCommand(
            command.Id,
            command.Name,
            command.LastName,
            command.PhoneNumber,
            command.Password,
            command.Email,
            command.Avatar,
            command.Gender
        ));

        return CommandResult(result);
    }
}