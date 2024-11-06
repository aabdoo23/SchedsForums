using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.ConfigurationOptions;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories;
using SchedsForums.Infrastructure.Repositories.Common;
using SchedsForums.Infrastructure.Services;
using System.Text;

namespace SchedsForums.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSchedsForumsDbContext(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            services.AddDbContext<SchedsForumsDbContext>(options =>
                options.UseNpgsql(connectionString, npgsqlOptions =>
                    npgsqlOptions.MigrationsAssembly("SchedsForums.Infrastructure"))
            );

            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Student>, BaseRepository<Student>>();
            services.AddScoped<IBaseRepository<Admin>, BaseRepository<Admin>>();
            services.AddScoped<IBaseRepository<Moderator>, BaseRepository<Moderator>>();
            services.AddScoped<IPendingModeratorRepository, PendingModeratorRepository>();
            services.AddScoped<IBaseUserRepository, BaseUserRepository>();
            services.AddScoped<IBaseRepository<Course>, BaseRepository<Course>>();

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection ConfigureJWTOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtOptions>(options =>
            {
                options.Key = Environment.GetEnvironmentVariable(JWTConstants.JWT_KEY)
                    ?? throw new NullReferenceException(nameof(JWTConstants.JWT_KEY));
                options.Issuer = configuration[JWTConstants.JWT_ISSUER]
                    ?? throw new NullReferenceException(nameof(JWTConstants.JWT_ISSUER));
                options.Audience = configuration[JWTConstants.JWT_AUDIENCE]
                    ?? throw new NullReferenceException(nameof(JWTConstants.JWT_AUDIENCE));
                configuration.GetSection(JWTConstants.JWT_Options).Bind(options);
            });

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JWTConstants.JWT_Options));
            var serviceProvider = services.BuildServiceProvider();
            var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                };
            });

            return services;
        }
    }
}
