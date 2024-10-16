using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class IngredientDishRepository : GenericRepository<IngredientDishEntity>, IIngredientDishRepository
{
    private readonly DbSet<IngredientDishEntity> dbSet;
    public IngredientDishRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
        dbSet = dbcontext.Set<IngredientDishEntity>();
    }
    public override Task<List<IngredientDishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Dish)
            .Include(e => e.Ingredient);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<IngredientDishEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Dish)
            .Include(e => e.Ingredient)
            .FirstOrDefaultAsync(cancellationToken);
    }
}