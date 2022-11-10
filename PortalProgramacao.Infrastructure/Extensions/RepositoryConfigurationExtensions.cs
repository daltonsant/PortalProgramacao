using Microsoft.Extensions.DependencyInjection;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Infrastructure.Data.Repositories;
using PortalProgramacao.Infrastructure.Data.UoW;

namespace PortalProgramacao.Infrastructure.Extensions
{
    internal static class RepositoryConfigurationExtensions
    {
        internal static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped(typeof(IActivityRepository), typeof(ActivityRepository) );
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository) );
            services.AddScoped(typeof(IProcessRepository), typeof(ProcessRepository) );
            services.AddScoped(typeof(INplRepository), typeof(NplRepository) );
            services.AddScoped(typeof(IActivityTypeRepository), typeof(ActivityTypeRepository) );


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork) );

            return services;
        }
    }
}
