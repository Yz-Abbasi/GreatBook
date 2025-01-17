using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.AspNetCore.Enums;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Tokens;
using Shop.Query.Users.DTOs;
using UAParser;

namespace Shop.Api.Controllers;

// [EnableCors("ShopApi")]
public class AuthController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IUserTokenFacade _tokenFacade;
    private IConfiguration _configuration;

    public AuthController(IUserFacade userFacade, IConfiguration configuration, IUserTokenFacade tokenFacade)
    {
        _userFacade = userFacade;
        _configuration = configuration;
        _tokenFacade = tokenFacade;
    }

    [HttpPost("Login")]
    public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel loginViewModel)
    {
        var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
        if(user == null)
            return CommandResult(OperationResult<LoginResultDto>.Error("User with the entered credentials doesn't exist!"));

        if(Sha256Hasher.Compare(user.Password, loginViewModel.Password) != false)
            return CommandResult(OperationResult<LoginResultDto>.Error("User with the password doesn't exist!"));// Change the message later for security purposes

        if(user.IsActive == false)
            return CommandResult(OperationResult<LoginResultDto>.Error("Your user account is inactive!"));

        var loginResult = await AddTokenAndGenerateJwt(user);

        return CommandResult(loginResult);
    }

    [HttpPost("Register")]
    public async Task<ApiResult> Register(RegisterViewModel register)
    {
        var command = new RegisterUserCommand(new PhoneNumber(register.PhoneNumber), register.Password);
        var result = await _userFacade.RegisterUser(command);

        return CommandResult(result);
    }
    
    [HttpPost("RefreshToken")]
    public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
    {
        var result = await _tokenFacade.GetUserTokenByRefreshToken(refreshToken);
        if(result == null)
            return CommandResult(OperationResult<LoginResultDto?>.NotFound());

        if(result.TokenExpireDate > DateTime.Now)
            return CommandResult(OperationResult<LoginResultDto?>.Error("Token is still valid!"));
        
        if(result.RefreshTokenExpireDate < DateTime.Now)
            return CommandResult(OperationResult<LoginResultDto?>.Error("Refresh token has expired!"));

        await _tokenFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId, result.Id));

        var user = await _userFacade.GetUserById(result.UserId);
        var loginResult = await AddTokenAndGenerateJwt(user);

        return CommandResult(loginResult);
    }

    private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
    {
        var uaPrser = Parser.GetDefault();
        var header = HttpContext.Request.Headers["user-agent"].ToString();
        var device = "default device";
        if(header != null)
        {
            var info = uaPrser.Parse(header);
            device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
        }

        var token = JwtTokenBuilder.BuildToken(user, _configuration);
        var refreshToken = Guid.NewGuid().ToString();

        var hashJwt = Sha256Hasher.Hash(token);
        var hashRefreshJwt = Sha256Hasher.Hash(refreshToken);
        var tokenResult = await _tokenFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwt, hashRefreshJwt, DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));
        if(tokenResult.Status != OperationResultStatus.Success)
            return OperationResult<LoginResultDto?>.Error();

        return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
        {
            Token = token,
            RefreshToken = refreshToken
        });
    }

    [Authorize]
    [HttpDelete("Logout")]
    public async Task<ApiResult> Logout()
    {
        var token = await HttpContext.GetTokenAsync("access_token");

        var result = await _tokenFacade.GetUserTokenByJwtToken(token);
        if(result == null)
            return CommandResult(OperationResult.NotFound());

        await _tokenFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId, result.Id));

        return CommandResult(OperationResult.Success());
    }
}