using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using VRSite.Api.Authorization.JwtAuthorization;
using VRSite.Api.Authorization.JwtAuthorization.Contracts;
using VRSite.Api.Business.ClientBusiness;
using VRSite.Api.Business.ClientBusiness.Contracts;
using VRSite.Api.Business.LaboratoriesBusiness;
using VRSite.Api.Business.LaboratoriesBusiness.Contracts;
using VRSite.Api.Business.OrderBusiness;
using VRSite.Api.Business.OrderBusiness.Contracts;
using VRSite.Api.Context.Repository;
using VRSite.Api.Context.Repository.Contracts;

namespace VRSite.Api.Common.Resolver.Helpers
{
    public static class BusinessResolverHelper
    {
        public static void Resolve(IServiceCollection services)
        {
            ResolveBusiness(services);
        }

        private static void ResolveBusiness(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRepository, RepositoryContext>();
            services.AddScoped<IClientBusiness, ClientBusiness>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILaboratoriesBusiness, LaboratoriesBusiness>();
            services.AddScoped<IOrderBusiness, OrderBusiness>();
        }
    }
}
