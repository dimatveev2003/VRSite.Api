using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VRSite.Api.Common.Configurations;
using VRSite.Api.Common.Configurations.Contracts;
using VRSite.Api.Common.Configurations.Models;

namespace VRSite.Api.Common.Resolver.Helpers
{
    public static class ConfigurationResolverHelper
    {
        /// <summary>
        /// Имя переменной окружения со строкой подключения к бд
        /// </summary>
        private const string DbConnectionString = "DB_CONNECTION_STRING";

        public static void Resolve(IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.AddScoped<IConfigurationAppManager, ConfigurationAppManager>(prop =>
            {
                var confRoot = configurationRoot;

                return AddEnvironmentVariables(confRoot);
            });
        }

        private static ConfigurationAppManager AddEnvironmentVariables(IConfigurationRoot configurationRoot)
        {
            var configurationAppManager = configurationRoot.Get<ConfigurationAppManager>();

            AddDbSettings(configurationAppManager);

            return configurationAppManager;
        }

        private static void AddDbSettings(IConfigurationAppManager configuration)
        {
            if (configuration.DbSettings != null)
            {
                configuration.DbSettings.ConnectionString =
                    string.IsNullOrEmpty(configuration.DbSettings.ConnectionString)
                        ? Environment.GetEnvironmentVariable(DbConnectionString)
                        : configuration.DbSettings.ConnectionString;
            }
            else
            {
                configuration.DbSettings = new DbSettings()
                { ConnectionString = Environment.GetEnvironmentVariable(DbConnectionString) };
            }
        }
    }
}
