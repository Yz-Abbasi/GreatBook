using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens
{
    public record GetUserTokenByRefreshTokenQuery(string HashedRefreshToken) : IQuery<UserTokenDto>;
}