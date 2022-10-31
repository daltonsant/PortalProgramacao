using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalProgramacao.Infrastructure.Data.Context;
using PortalProgramacao.Infrastructure.Identity;
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
                if (databaseType.ToLower().Equals("sqlite"))
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
                else
                {
                    options.UseSqlite("Data Source=database.db;Cache=Shared", b =>
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
            services.AddDefaultIdentity<ApplicationUser>(options =>
             {
                 options.SignIn.RequireConfirmedAccount = false;
             })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddErrorDescriber<IdentityMessagesPtBr>();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvxwyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                options.User.RequireUniqueEmail = false;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 0;
            });


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
