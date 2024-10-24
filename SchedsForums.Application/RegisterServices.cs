using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Application.Behaviors;
using SchedsForums.Application.Commands.Courses.Create;
using SchedsForums.Application.Commands.Faculties.Create;
using SchedsForums.Application.Commands.Majors.Create;
using SchedsForums.Application.Commands.Users.Admins.Create;
using SchedsForums.Application.Commands.Users.BaseUser.Login;
using SchedsForums.Application.Commands.Users.Moderators.Create;
using SchedsForums.Application.Commands.Users.Students.Create;

namespace SchedsForums.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateStudentCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(LoginCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateMajorCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateFacultyCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateAdminCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateModeratorCommandHandler).Assembly));
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateCourseCommandHandler).Assembly));

            return services;
        }

        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateStudentValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateMajorValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateAdminValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateModeratorValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCourseValidator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
