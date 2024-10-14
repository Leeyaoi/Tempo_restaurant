using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class WaiterRepository : GenericRepository<WaiterEntity>, IWaiterRepository
{
    private readonly DbSet<WaiterEntity> dbSet;
    public WaiterRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
    public override Task<List<WaiterEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Employee)
            .Include(e => e.Tables);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<WaiterEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Employee)
            .Include(e => e.Tables)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
