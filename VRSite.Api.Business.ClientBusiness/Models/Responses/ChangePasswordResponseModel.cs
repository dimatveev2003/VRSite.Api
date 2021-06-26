using VRSite.Api.Authorization.JwtAuthorization.Models;

namespace VRSite.Api.Business.ClientBusiness.Models.Responses
{
    public class ChangePasswordResponseModel
    {
        public bool IsSuccess { get; set; }
        
        public UserTokenModel TokenModel { get; set; }
    }
}