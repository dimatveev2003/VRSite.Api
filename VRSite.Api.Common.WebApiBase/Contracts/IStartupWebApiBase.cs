using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace VRSite.Api.Common.WebApiBase.Contracts
{
    public interface IStartupWebApiBase
    {
        /// <summary>
        /// Настройка сервисов приложения
        /// </summary>
        /// <param name="services"></param>
        void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Регистрация зависимостей приложения
        /// </summary>
        /// <param name="services"></param>
        void RegisterDependecy(IServiceCollection services);

        /// <summary>
        /// Регистрация логера 
        /// </summary>
        /// <param name="services"></param>
        void RegisterLogging(IServiceCollection services);

        /// <summary>
        /// регистрация базовых сервисов
        /// </summary>
        /// <param name="services"></param>
        void RegisterBaseServices(IServiceCollection services);

        /// <summary>
        /// НАстройка конвеера http-запросов
        /// </summary>
        /// <param name="app"></param>
        /// <param name="environment"></param>
        void Configure(IApplicationBuilder app, IHostingEnvironment environment);

        /// <summary>
        /// Добавить пользовательские Middlewares в конвеер
        /// </summary>
        /// <param name="app"></param>
        void ConfigureCustomMiddleware(IApplicationBuilder app);

        /// <summary>
        /// Конфигурация локализации приложения
        /// </summary>
        /// <param name="services"></param>
        void RegisterLocalizationApp(IServiceCollection services);
    }
}
