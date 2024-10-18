using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Repositories;

namespace SchedsForums.Infrastructure
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IModeratorRepository, ModeratorRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            return services;
        }
    }
}
