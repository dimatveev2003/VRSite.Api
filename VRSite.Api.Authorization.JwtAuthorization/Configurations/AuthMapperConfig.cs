using AutoMapper;
using VRSite.Api.Authorization.JwtAuthorization.Models;

namespace VRSite.Api.Authorization.JwtAuthorization.Configurations
{
    public static class AuthMapperConfig
    {
        public static void SetMapperConfig(IMapperConfigurationExpression expression)
        {
            SetUserModels(expression);
        }

        private static void SetUserModels(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<string, UserTokenModel>().ForMember(dst => dst.Token, opt => opt.MapFrom(src => src));
        }
    }
}
