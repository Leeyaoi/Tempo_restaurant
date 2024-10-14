using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishwareDishRepository : GenericRepository<DishwareDishEntity>, IDishwareDishRepository
{
    private readonly DbSet<DishwareDishEntity> dbSet;
    public DishwareDishRepository(TempoDbContext dbContext) : base(dbContext) 
    {
    }

    public override Task<List<DishwareDishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Dish)
            .Include(e => e.Dishware);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<DishwareDishEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Dish)
            .Include(e => e.Dishware)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
     
