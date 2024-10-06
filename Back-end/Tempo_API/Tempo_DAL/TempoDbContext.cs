using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_Shared.Providers;

namespace Tempo_DAL;

public class TempoDbContext : DbContext
{
    private readonly IDateTimeProvider _dateTime;

    public TempoDbContext(DbContextOptions<TempoDbContext> options, IDateTimeProvider dateTime)
        :base (options)
    {
        _dateTime = dateTime;


        //Auto migrations
        if (Database.IsRelational())
        {
            Database.Migrate();
        }
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

    //Overrided just so you wouldn't be able to change fiellds CreatedAt and UpdatedAt as you wish
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();

        var now = _dateTime.GetDate();
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            var entity = entry.Entity as BaseEntity;

            if (entity == null) { continue; }

            switch (entry.State)
            {
                case EntityState.Modified:
                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    entity.UpdatedAt = now;
                    break;

                case EntityState.Added:
                    entity.CreatedAt = now;
                    entity.UpdatedAt = now;
                    break;
            }
        }

        return base.SaveChanges();
    }
}
