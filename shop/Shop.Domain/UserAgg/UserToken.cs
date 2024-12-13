using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.UserAgg;
public class UserToken : BaseEntity
{
    public long UserId { get; internal set; }
    public string HashJwtToken { get; private set; }
    public string HashRefreshToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
    public DateTime RefreshTokenExpireDate { get; private set; }
    public string Device { get; private set; }

    public UserToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        TokenExpireDate = tokenExpireDate;
        RefreshTokenExpireDate = refreshTokenExpireDate;
        Device = device;
    }

    public void Guard()
    {
        NullOrEmptyDomainDataException.CheckString(HashJwtToken, nameof(HashJwtToken));
        NullOrEmptyDomainDataException.CheckString(HashRefreshToken, nameof(HashRefreshToken));

        if(TokenExpireDate < DateTime.Now)
            throw new InvalidDomainDataException("ExpireDate is invalid!");

        if(RefreshTokenExpireDate < TokenExpireDate)
            throw new InvalidDomainDataException("Refresh token Expire Date is invalid!");
    }
}