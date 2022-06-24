using Contract;
using Entities;
using LoggerService;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace CompanyEmployee.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
         services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureCors(this IServiceCollection services) =>
         services.AddCors(options =>
         {
             options.AddPolicy("CorsPolicy", builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
         });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
         services.Configure<IISOptions>(options => { });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
                    services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")
                        , b => b.MigrationsAssembly("CompanyEmployee")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
         services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureResponseCaching(this IServiceCollection services) =>
        services.AddResponseCaching();
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services) =>
services.AddHttpCacheHeaders(
    (expirationOpt) =>
    {
        expirationOpt.MaxAge = 65;
        expirationOpt.CacheLocation = CacheLocation.Private;
    },(validationOpt) =>
    {
        validationOpt.MustRevalidate = true;
    });
    }
}