using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VRSite.Api.Authorization.JwtAuthorization.Configurations;
using VRSite.Api.Common.Configurations;
using VRSite.Api.Common.Configurations.Contracts;
using VRSite.Api.Common.Resolver;
using VRSite.Api.Common.Resolver.Contracts;
using VRSite.Api.Common.WebApiBase;
using VRSite.Api.Common.WebApiBase.Filters;
using VRSite.Api.Configuration;
using VRSite.Api.Context.Repository;

namespace VRSite.Api
{
    public class Startup : StartupWebApiBase
    {
        private const string AllowAllOrigins = "AllowAllOrigins";

        private readonly IAppResolver _resolver;

        private IConfigurationAppManager ConfigurationAppManager => Configuration.Get<ConfigurationAppManager>();

        public Startup(IHostingEnvironment configuration)
        {
            Configuration = BuildConfiguration(configuration);
            _resolver = new AppResolver(Configuration, ConfigurationAppManager);
        }

        public override void RegisterBaseServices(IServiceCollection services)
        {
            services.AddCors(opt => opt.AddPolicy(AllowAllOrigins, builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            }));

            services.AddDbContext<RepositoryContext>(opts =>
            {
                var connectionString = !string.IsNullOrEmpty(ConfigurationAppManager.DbSettings.ConnectionString)
                    ? ConfigurationAppManager.DbSettings.ConnectionString
                    : Configuration["DB_CONNECTION_STRING"];

                opts.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging());
            });

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddWebEncoders(opts => opts.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));
            services.AddMemoryCache();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = AuthOptionConfig.Issuer,
                        ValidAudience = AuthOptionConfig.Audience,
                        IssuerSigningKey = AuthOptionConfig.GetSymmetricSecurityKey(),
                    };
                });

            services
                .AddMvc(opts =>
                {
                    opts.Filters.Add<ServiceExceptionFilter>();
                })
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                });

        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            app.UseAuthentication();
            app.UseCors(AllowAllOrigins);

            base.Configure(app, environment);
        }

        public override void RegisterDependecy(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            _resolver.ResolveConfigs(services);
            _resolver.ResolveBusiness(services);
            _resolver.ResolveMapper(services);
            _resolver.ResolveServices(services);
        }

        public override void RegisterLogging(IServiceCollection services)
        {
            _resolver.ResolveLogger(services);
        }

        private static IConfigurationRoot BuildConfiguration(IHostingEnvironment environment)
        {
            const bool isOptional = false;
            const bool isReloadOnChange = true;

            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath);

            builder.AddEnvironmentVariables();
            builder.AddJsonFile(AppConfigFilesProvider.GetAppSettingsFileName(environment), isOptional,
                isReloadOnChange);

            return builder.Build();
        }
    }
}
