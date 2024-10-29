using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Persistence.Contexts;

namespace SchedsForums.Persistence.Services
{
    public static class DbContextRegistrationService
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            services.AddDbContext<ForumsDbContext>(options =>
                options.UseNpgsql((connectionString)));

            return services;
        }
    }
}
