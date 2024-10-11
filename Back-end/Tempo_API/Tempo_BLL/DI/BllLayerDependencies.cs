using Microsoft.Extensions.DependencyInjection;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Services;

namespace Tempo_BLL.DI;

public static class BllLayerDependencies
{
    public static void RegisterBllDependencies(this IServiceCollection services)
    {
        services.AddTransient<IBillService, BillService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<ICookService, CookService>();
        services.AddTransient<IDishService, DishService>();
        services.AddTransient<IDishwareDishService, DishwareDishService>();
        services.AddTransient<IDishwareService, DishwareService>();
        services.AddTransient<IDrinkService, DrinkService>();
        services.AddTransient<IEmployeeService, EmployeesService>();
        services.AddTransient<IIngredientDishService, IngredientDishService>();
        services.AddTransient<IIngredientService, IngredientService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<ITableService, TableService>();
        services.AddTransient<ITablewareDishService, TablewareDishService>();
        services.AddTransient<ITablewareService, TablewareService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IWaiterService, WaiterService>();
    }
}
