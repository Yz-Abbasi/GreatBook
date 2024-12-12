using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.AspNetCore.Enums;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers;
public class AuthController : ApiController
{
    private readonly IUserFacade _userFacade;
    private IConfiguration _configuration;

    public AuthController(IUserFacade userFacade, IConfiguration configuration)
    {
        _userFacade = userFacade;
        _configuration = configuration;
    }

    [HttpPost("Login")]
    public async Task<ApiResult<string?>> Login(LoginViewModel loginViewModel)
    {
        var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
        if(user == null)
            return CommandResult(OperationResult<string>.Error("User with the entered credentials doesn't exist!"));

        if(Sha256Hasher.Compare(user.Password, loginViewModel.Password) == false)
            return CommandResult(OperationResult<string>.Error("User with the entered credentials doesn't exist!"));

        if(user.IsActive == false)
            return CommandResult(OperationResult<string>.Error("Your user account is inactive!"));

        var token = JwtTokenBuilder.BuildToken(user, _configuration);

        return new ApiResult<string?>()
        {
            Data = token,
            IsSuccessful = true,
            MetaData = new()
        };
    }

    [HttpPost("Register")]
    public async Task<ApiResult> Register(RegisterViewModel register)
    {
        var command = new RegisterUserCommand(new PhoneNumber(register.PhoneNumber), register.Password);
        var result = await _userFacade.RegisterUser(command);

        return CommandResult(result);
    }
}