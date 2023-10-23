using Microsoft.EntityFrameworkCore;

namespace TEST.Models.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTestDbContext(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config["TestDbConnection"];
            services.AddDbContext<ITestDbContext,TestDbContext>(options =>
            {
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(config["MigrationAssembly"]));
            });

            return services;
        }
    }
}
