using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
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
            services.AddScoped<IBaseUserRepository, BaseUserRepository>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }

        public static IServiceCollection ConfigureJWTOptions(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.Configure<JwtOptions>(options =>
            {
                configuration.GetSection("Jwt").Bind(options);
                options.Key = Environment.GetEnvironmentVariable("JWT_KEY")
                    ?? throw new NullReferenceException("JWT_KEY environment variable not set.");
                options.Issuer = configuration["Jwt:Issuer"]
                    ?? throw new NullReferenceException("JWT:Issuer environment variable not set.");
                options.Audience = configuration["Jwt:Audience"]
                    ?? throw new NullReferenceException("JWT:Audience environment variable not set.");
            });
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IOptions<JwtOptions> jwtOptions)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Value.Issuer,
                    ValidAudience = jwtOptions.Value.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key))
                };
            });

            return services;
        }
    }
}
