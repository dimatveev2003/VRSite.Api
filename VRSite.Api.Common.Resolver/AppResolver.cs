using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VRSite.Api.Authorization.JwtAuthorization.Configurations;
using VRSite.Api.Business.ClientBusiness.Configurations;
using VRSite.Api.Business.LaboratoriesBusiness.Configurations;
using VRSite.Api.Common.Configurations.Contracts;
using VRSite.Api.Common.Resolver.Contracts;
using VRSite.Api.Common.Resolver.Helpers;

namespace VRSite.Api.Common.Resolver
{
    public class AppResolver : IAppResolver
    {
        private readonly IConfigurationRoot _configurationRoot;

        private readonly IConfigurationAppManager _configurationAppManager;

        public AppResolver(IConfigurationRoot configurationRoot, IConfigurationAppManager configurationAppManager)
        {
            _configurationRoot = configurationRoot;
            _configurationAppManager = configurationAppManager;
        }

        public void ResolveBusiness(IServiceCollection services)
        {
            BusinessResolverHelper.Resolve(services);
        }

        public void ResolveLogger(IServiceCollection services)
        {
           //todo
        }

        public void ResolveConfigs(IServiceCollection services)
        {
            ConfigurationResolverHelper.Resolve(services, _configurationRoot);
        }

        public void ResolveMapper(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(conf =>
            {
                ClientMapperConfig.SetMapperConfig(conf);
                LaboratoriesMapperConfig.SetMapperConfig(conf);
                AuthMapperConfig.SetMapperConfig(conf);
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(prop => mapper);
        }

        public void ResolveServices(IServiceCollection services)
        {
            ServicesResolverHelper.Resolve(services);
        }
    }
}
