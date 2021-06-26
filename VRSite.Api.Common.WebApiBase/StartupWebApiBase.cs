using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using VRSite.Api.Common.WebApiBase.Contracts;

namespace VRSite.Api.Common.WebApiBase
{
    public abstract class StartupWebApiBase : IStartupWebApiBase
    {
        /// <summary>
        /// конфигурация приложения
        /// </summary>
        protected IConfigurationRoot Configuration;

        protected ILogger Logger;

        public virtual void ConfigureServices(IServiceCollection services)
        {
            RegisterBaseServices(services);
            RegisterLocalizationApp(services);
            RegisterLogging(services);
            RegisterDependecy(services);
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            //Logger.LogInformation("Конфигурация приложения: (Configure)");

            if (environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            ConfigureCustomMiddleware(app);
            ConfigureBaseMiddleware(app, environment);
        }

        public virtual void ConfigureCustomMiddleware(IApplicationBuilder app)
        {
            //Logger.LogInformation("Добавление обработчиков");
        }

        public virtual void RegisterLocalizationApp(IServiceCollection services)
        {
            //Logger.LogInformation("Инициализация локализации приложения");
            services.AddLocalization(opt => { opt.ResourcesPath = ""; });
        }

        /// <summary>
        /// Зарегистрировать зависимости
        /// </summary>
        /// <param name="services"></param>
        public abstract void RegisterDependecy(IServiceCollection services);

        /// <summary>
        /// Зарегистрировать логгер
        /// </summary>
        /// <param name="services"></param>
        public abstract void RegisterLogging(IServiceCollection services);

        public abstract void RegisterBaseServices(IServiceCollection services);

        /// <summary>
        /// Добавить базовые для всех вебсервисов Middlewares в конвеер
        /// </summary>
        /// <param name="app"></param>
        /// <param name="environment">Окружение</param>
        private void ConfigureBaseMiddleware(IApplicationBuilder app, IHostingEnvironment environment)
        {
            //Logger.LogInformation("Добавление стандартных обработчиков");
            app.UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();
            // app.UseCors();
            app.UseMvc();
        }
    }
}
