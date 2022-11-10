using Microsoft.Extensions.DependencyInjection;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Infrastructure.Services;

namespace PortalProgramacao.Infrastructure.Extensions
{
    internal static class ServicesConfigurationExtensions
    {
        internal static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService) );
            services.AddScoped(typeof(IActivityService), typeof(ActivityService) );
            return services;
        }
    }
}
