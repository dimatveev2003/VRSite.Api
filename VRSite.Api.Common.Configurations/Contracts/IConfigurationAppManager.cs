using VRSite.Api.Common.Configurations.Models;

namespace VRSite.Api.Common.Configurations.Contracts
{
    public interface IConfigurationAppManager
    {
        DbSettings DbSettings { get; set; }

        AppSettings AppSettings { get; set; }
    }
}
