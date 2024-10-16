using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Validators;

namespace SchedsForums.Domain.Common
{
    public static class ConfigureValidators
    {
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<BaseUser>, BaseUserValidator<>>();
            return services;
        }

    }
}
