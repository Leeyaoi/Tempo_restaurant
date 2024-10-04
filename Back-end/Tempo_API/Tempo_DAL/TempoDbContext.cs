using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;

namespace Tempo_DAL;

public class TempoDbContext : DbContext
{
    public TempoDbContext(DbContextOptions<TempoDbContext> options)
        :base (options)
    {

    }
    public DbSet<BillEntity> Bill { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<CookEntity> Cook { get; set; }
    public DbSet<DishEntity> Dish { get; set; }
    public DbSet<DishwareDishEntity> DishwareDish { get; set; }
    public DbSet<DishwareEntity> Dishware { get; set; }
    public DbSet<DrinkEntity> Drink { get; set; }
    public DbSet<EmployeeEntity> Employee { get; set; }
    public DbSet<IngredientDishEntity> IngredientDish { get;set; }
    public DbSet<IngredientEntity> Ingredient { get; set; }
    public DbSet<OrderEntity> Order { get; set; }
    public DbSet<TableEntity> Table { get; set; }
    public DbSet<TablewareDishEntity> TablewareDish { get; set; }
    public DbSet<TablewareEntity> Tableware { get; set; }
    public DbSet<UserEntity> User { get; set; }
    public DbSet<WaiterEntity> Waiter { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
