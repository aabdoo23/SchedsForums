using Microsoft.Extensions.DependencyInjection;

namespace SchedsForums.Domain.ServiceConfiguration
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
