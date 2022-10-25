using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalProgramacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Application.Extensions
{
    public static class ApplicationConfigurationExtensions
    {
        private static IServiceCollection ConfigureOrm(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseType = configuration.GetSection("DatabaseType")?.Value ?? string.Empty;

            services.AddDbContext<ApplicationContext>(options =>
            {
                if (string.IsNullOrEmpty(databaseType))
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        b =>
                            b.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationContext))?.ToString()));
                }
                else if (databaseType.ToLower().Equals("mysql"))
                {
                    var version = configuration.GetSection("MysqlVersion")?.Value ?? "8.0.30";
                    var serverVersion = new MySqlServerVersion(new Version(version));
                    options.UseMySql(configuration.GetConnectionString("MysqlConnection"), serverVersion,
                        b =>
                        {
                            b.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationContext))?.ToString());
                        });
                }
            }
            );



            return services;
        }

        private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .ConfigureOrm(configuration)
                .ConfigureIdentity()
                .ConfigureRepositories()
                .ConfigureServices();
        }
    }
}
