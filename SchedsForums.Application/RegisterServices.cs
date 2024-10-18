using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Application.Commands.Students.Create;

namespace SchedsForums.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateStudentCommandHandler).Assembly));

            return services;

        }

    }
}
