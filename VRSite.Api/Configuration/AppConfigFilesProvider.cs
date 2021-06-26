using Microsoft.AspNetCore.Hosting;

namespace VRSite.Api.Configuration
{
    public static class AppConfigFilesProvider
    {
        public static string GetAppSettingsFileName(IHostingEnvironment env)
        {
            return env.IsDevelopment() ? "appsettings.json" : $"appsettings.{env.EnvironmentName.ToLower()}.json";
        }
    }
}
