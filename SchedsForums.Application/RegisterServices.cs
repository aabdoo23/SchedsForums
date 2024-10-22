using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Application.Commands.Students.Create;


namespace SchedsForums.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateStudentCommandHandler).Assembly));
            return services;
        }

        public static IServiceCollection RegisterValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateStudentValidator>();
            return services;
        }

    }
}
