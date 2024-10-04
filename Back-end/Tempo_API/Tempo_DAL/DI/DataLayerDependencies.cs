using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tempo_DAL.DI
{
    public static class DataLayerDependencies
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TempoDbContext>(option =>
            {
                var connectionString = configuration.GetValue<string>("DB_CONNECTION");
                option.UseNpgsql(connectionString);
            }, ServiceLifetime.Transient);

            
        }
    }
}
