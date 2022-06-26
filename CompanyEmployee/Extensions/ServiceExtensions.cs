using Contract;
using Entities;
using LoggerService;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
=======
using Marvin.Cache.Headers;
>>>>>>> 099fac8d0059a2fe90b51b9b0917db21569d500c
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Text;

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
<<<<<<< HEAD
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();

        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

=======
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
>>>>>>> 099fac8d0059a2fe90b51b9b0917db21569d500c
    }
}