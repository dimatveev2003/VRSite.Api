using Microsoft.Extensions.DependencyInjection;

namespace VRSite.Api.Common.Resolver.Contracts
{
    public interface IAppResolver
    {
        void ResolveBusiness(IServiceCollection services);

        void ResolveLogger(IServiceCollection services);

        void ResolveConfigs(IServiceCollection services);

        void ResolveMapper(IServiceCollection services);

        void ResolveServices(IServiceCollection services);
    }
}
