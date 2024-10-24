using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Application.Behaviors;
using SchedsForums.Application.Commands.BaseUser.Login;
using SchedsForums.Application.Commands.Faculties.Create;
using SchedsForums.Application.Commands.Majors.Create;
using SchedsForums.Application.Commands.Students.Create;

namespace SchedsForums.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateStudentCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(LoginCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateMajorCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateFacultyCommandHandler).Assembly));
            
            return services;
        }

        public static IServiceCollection RegisterValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateStudentValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateMajorValidator>();
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
