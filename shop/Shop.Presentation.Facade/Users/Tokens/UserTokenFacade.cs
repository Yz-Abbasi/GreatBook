using Common.Application;
using Common.Application.SecurityUtil;
using MediatR;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.RemoveToken;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.UserTokens.GetByJwtToken;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Presentation.Facade.Users.Tokens;
public class UserTokenFacade : IUserTokenFacade
{
        private readonly IMediator _mediator;
        public UserTokenFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<OperationResult> AddToken(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }
        public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
        {
            var hashJwtToken = Sha256Hasher.Hash(jwtToken);

            return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        }
    
}