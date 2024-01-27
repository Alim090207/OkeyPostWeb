using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Okey.Application.Absreactions;
using Okey.Infrastructure.DataAccess;
using System.Text.Json.Serialization;

namespace Okey.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IOkeyDbContext, OkeyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddControllersWithViews()
            .AddJsonOptions(x => x.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

            return services;
        }
    }
}
