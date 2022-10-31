using Microsoft.Extensions.DependencyInjection;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Infrastructure.Data.Repositories;

namespace PortalProgramacao.Application.Extensions
{
    internal static class RepositoryConfigurationExtensions
    {
        internal static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped(typeof(IActivityRepository), typeof(ActivityRepository) );
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository) );

            return services;
        }
    }
}
