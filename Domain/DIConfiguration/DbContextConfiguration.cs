using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Data.Entities;
using Data.Repositories;

namespace Domain.DIConfiguration
{
    public static class DbContextConfiguration
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            switch (configuration["DBProvider"])
            {
                case "PGSql":
                    {
                        services.AddDbContext<ApplicationDbContext>(
                        options => options.UseNpgsql(
                            configuration.GetConnectionString("PGSql"),
                            x => x.MigrationsAssembly("Data.PostgreSQLMigration")
                        ));

                        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

                        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
                        services.AddScoped<IUnitOfWork, Data.UnitOfWork>();
                        
                        break;
                    }
                /*case "MSSql":
                    {
                        services.AddDbContext<ApplicationMsSqlDbContext>(
                        options => options.UseSqlServer(
                            configuration.GetConnectionString("MSSql"),
                            x => x.MigrationsAssembly("Data.MsSQLMigration")
                        ).EnableSensitiveDataLogging()
                        .EnableDetailedErrors());

                        services.AddScoped<IApplicationDbContext, ApplicationMsSqlDbContext>();
                        services.AddScoped<IUnitOfWork, Data.Repositories.Mssql.UnitOfWork>();
                        break;
                    }*/
                default:
                    {
                        throw new Exception($"Unsupported provider: {configuration["DBProvider"]}");
                    }
            }
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Map>, Repository<Map>>();
            services.AddScoped<IRepository<City>, Repository<City>>();
            services.AddScoped<IRepository<Route>, Repository<Route>>();
            services.AddScoped<IRepository<Transport>, Repository<Transport>>();
            services.AddScoped<IRepository<Vehicle>, Repository<Vehicle>>();
            services.AddScoped<IRepository<Balance>, Repository<Balance>>();
        }
    }
}
