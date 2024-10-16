using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishwareRepository : GenericRepository<DishwareEntity>, IDishwareRepository
{
    private readonly DbSet<DishwareEntity> dbSet;
    public DishwareRepository(TempoDbContext dbcontext) :base(dbcontext)
    {
        dbSet = dbcontext.Set<DishwareEntity>();
    }
    public override Task<List<DishwareEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Dishes);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<DishwareEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Dishes)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
