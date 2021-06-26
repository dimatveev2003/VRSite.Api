using System;
using AutoMapper;
using VRSite.Api.Authorization.JwtAuthorization.Models;
using VRSite.Api.Business.ClientBusiness.Models.Requests;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Business.ClientBusiness.Helpers
{
    public static class ClientHelper
    {
        public static DbClient GetDbClient(RegisterClientRequestModel model, IMapper mapper)
        {
            var result = mapper.Map<DbClient>(model);

            result.RegistrationTime = DateTime.Now;

            return result;
        }

        public static UserModel GetUserModel(DbClient model, IMapper mapper)
        {
            var result = mapper.Map<UserModel>(model);

            result.LoginTime = DateTime.Now;

            return result;
        }
    }
}
