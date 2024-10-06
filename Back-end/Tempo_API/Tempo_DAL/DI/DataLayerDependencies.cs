using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tempo_DAL.Interfaces;
using Tempo_DAL.Repositories;

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

            services.AddTransient<IIngredientDishRepository, IngredientDishRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<ITablewareDishRepository, TablewareDishRepository>();
            services.AddTransient<ITablewareRepository, TablewareRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWaiterRepository, WaiterRepository>();
        }
    }
}
