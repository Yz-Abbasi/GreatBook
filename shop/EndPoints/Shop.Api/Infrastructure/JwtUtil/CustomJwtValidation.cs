using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Tokens;

namespace Shop.Api.Infrastructure.JwtUtil;
public class CustomJwtValidation
{
    private readonly IUserTokenFacade _tokenFacade;
    private readonly IUserFacade _userFacade;

    public CustomJwtValidation(IUserTokenFacade tokenFacade, IUserFacade userFacade)
    {
        _tokenFacade = tokenFacade;
        _userFacade = userFacade;
    }

    public async Task Validate(TokenValidatedContext context)
    {
        var userid = context.Principal.GetUserId();
        
        var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var token = await _tokenFacade.GetUserTokenByJwtToken(jwtToken);
        if(token == null)
        {
            context.Fail("Token not found!");
            return ;
        }

        var user = await _userFacade.GetUserById(userid);
        if(user.IsActive == false || user == null)
        {
            context.Fail("User is inactive!");
            return ;
        }
    }
};