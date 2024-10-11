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

            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICookRepository, CookRepository>();
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IDishwareDishRepository, DishwareDishRepository>();
            services.AddTransient<IDishwareRepository, DishwareRepository>();
            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
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
