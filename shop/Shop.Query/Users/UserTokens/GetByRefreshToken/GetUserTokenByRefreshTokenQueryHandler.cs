using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Query.Users.UserTokens.GetBtRefreshToken;
public class GetUserTokenByRefreshTokenQueryHandler : IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection();
        var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} WHERE HashRefreshToken=@hashRefreshToken";

        return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new {hashRefreshToken = request.HashedRefreshToken});
    }
}