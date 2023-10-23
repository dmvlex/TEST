using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TEST.Models.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTestDbContext(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config["MySqlTestDbConnection"];
            services.AddDbContext<ITestDbContext,TestDbContext>(options =>
            {
                options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 11))
                );
                //options.UseNpgsql(connectionString, b => b.MigrationsAssembly(config["MigrationAssembly"]));
            });

            return services;
        }
    }
}
