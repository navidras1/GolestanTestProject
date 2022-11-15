using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class Configs
    {
        public static void ConfigGolestanDB(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<GolestanTestDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(IGolestanTestRepos<>), typeof(GolestanTestRepos<>));
            services.AddScoped<Activity>();

        }
    }
}