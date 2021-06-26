using VRSite.Api.Authorization.JwtAuthorization.Models;

namespace VRSite.Api.Authorization.JwtAuthorization.Contracts
{
    public interface ITokenService
    {
        UserTokenModel GetToken(UserModel model);

        UserModel GetUserModel();
    }
}
