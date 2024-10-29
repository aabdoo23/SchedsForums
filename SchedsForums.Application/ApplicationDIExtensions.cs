using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Application.Behaviors;
using SchedsForums.Application.Commands.BaseUser.Login;
using SchedsForums.Application.Commands.BaseUser.SignUp;


namespace SchedsForums.Application
{
    public static class ApplicationDIExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(UserSignUpCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(LoginCommandHandler).Assembly));
            return services;
        }

        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UserSignUpValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
