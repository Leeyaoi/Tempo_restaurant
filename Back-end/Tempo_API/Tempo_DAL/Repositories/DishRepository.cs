using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishRepository : GenericRepository<DishEntity>, IDishRepository
{
    private readonly DbSet<DishEntity> dbSet;
    public DishRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
        dbSet = dbcontext.Set<DishEntity>();
    }

    public override Task<List<DishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Category)
            .Include(e => e.TablewareList)
            .Include(e => e.DishwareList);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<DishEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Category)
            .Include(e => e.TablewareList)
            .Include(e => e.DishwareList)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
