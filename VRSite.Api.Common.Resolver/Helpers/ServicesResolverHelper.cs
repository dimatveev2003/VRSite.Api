using Microsoft.Extensions.DependencyInjection;
using VRSite.Api.MailService.Contracts;

namespace VRSite.Api.Common.Resolver.Helpers
{
    public static class ServicesResolverHelper
    {
        public static void Resolve(IServiceCollection services)
        {
            ResolveServices(services);
        }

        private static void ResolveServices(IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService.MailService>();
        }
    }
}