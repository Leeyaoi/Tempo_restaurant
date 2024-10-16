using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DrinkRepository : GenericRepository<DrinkEntity>, IDrinkRepository
{
    private readonly DbSet<DrinkEntity> dbSet;
    public DrinkRepository(TempoDbContext dbcontext) :base(dbcontext)
    {
        dbSet = dbcontext.Set<DrinkEntity>();
    }
    public override Task<List<DrinkEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Category);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<DrinkEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Category)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
