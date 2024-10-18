using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Infrastructure.Contexts;

namespace SchedsForums.Persistence.Services
{
    public static class DbContextRegistrationService
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            Console.WriteLine(connectionString);
            services.AddDbContext<ForumsDbContext>(options =>
                options.UseNpgsql((connectionString)
                , b => b.MigrationsAssembly("SchedsForums.Api")
                ));

            return services;
        }
    }
}
