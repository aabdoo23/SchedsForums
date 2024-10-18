using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Repositories;
using SchedsForums.Infrastructure.Services;
using SchedsForums.Infrastructure.Services.Interfaces;

namespace SchedsForums.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IModeratorRepository, ModeratorRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            return services;
        }
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            return services;
        }
    }
}
