using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories;
using SchedsForums.Infrastructure.Services;

namespace SchedsForums.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            services.AddDbContext<SchedsForumsDbContext>(options =>
                options.UseNpgsql((connectionString)
                , b => b.MigrationsAssembly("SchedsForums.Api")
                ));

            return services;
        }
        public static IServiceCollection RegisterInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingService, HashingService>();
            return services;
        }
    }
}
