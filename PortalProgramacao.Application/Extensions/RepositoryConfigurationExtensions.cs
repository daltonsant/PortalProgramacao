using Microsoft.Extensions.DependencyInjection;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Application.Extensions
{
    internal static class RepositoryConfigurationExtensions
    {
        internal static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            

            return services;
        }
    }
}
