using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories;
using SchedsForums.Infrastructure.Services;
using System.Text;

namespace SchedsForums.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            services.AddDbContext<SchedsForumsDbContext>(options =>
                options.UseNpgsql(connectionString, npgsqlOptions =>
                    npgsqlOptions.MigrationsAssembly("SchedsForums.Infrastructure"))
            );

            return services;
        }

        public static IServiceCollection RegisterInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IBaseUserRepository, BaseUserRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IModeratorRepository, ModeratorRepository>();

            return services;
        }
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }

        public static IServiceCollection RegisterJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new NullReferenceException("Can't find JWT Key in Env Variables.");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            return services;
        }
    }
}
