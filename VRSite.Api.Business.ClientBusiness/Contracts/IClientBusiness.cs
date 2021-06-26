using System.Threading.Tasks;
using VRSite.Api.Authorization.JwtAuthorization.Models;
using VRSite.Api.Business.ClientBusiness.Models.Requests;
using VRSite.Api.Business.ClientBusiness.Models.Responses;

namespace VRSite.Api.Business.ClientBusiness.Contracts
{
    public interface IClientBusiness
    {
        Task<RegisterClientResponseModel> RegisterClient(RegisterClientRequestModel model);

        Task<LoginClientResponseModel> LoginClient(LoginClientRequestModel model);

        Task<UserModel> GetClientInfo();

        Task<SaveClientInfoResponseModel> SaveClientInfo(SaveClientInfoRequestModel model);

        Task<ChangePasswordResponseModel> ChangePassword(ChangePasswordRequestModel model);
    }
}
