using VRSite.Api.Common.Configurations.Contracts;
using VRSite.Api.Common.Configurations.Models;

namespace VRSite.Api.Common.Configurations
{
    public class ConfigurationAppManager : IConfigurationAppManager
    {
        public DbSettings DbSettings { get; set; }
        public AppSettings AppSettings { get; set; }
    }
}
