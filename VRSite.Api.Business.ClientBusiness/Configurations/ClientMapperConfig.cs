using AutoMapper;
using VRSite.Api.Authorization.JwtAuthorization.Models;
using VRSite.Api.Business.ClientBusiness.Models.Requests;
using VRSite.Api.Business.ClientBusiness.Models.Responses;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Business.ClientBusiness.Configurations
{
    public static class ClientMapperConfig
    {
        public static void SetMapperConfig(IMapperConfigurationExpression expression)
        {
            MapEntityModels(expression);
            MapAuthModels(expression);
        }

        private static void MapEntityModels(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<RegisterClientRequestModel, DbClient>();
            expression.CreateMap<UserTokenModel, LoginClientResponseModel>();
        }

        private static void MapAuthModels(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DbClient, UserModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Trim()))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Trim()))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login.Trim()))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.OrganizationName.Trim()));
        }
    }
}
