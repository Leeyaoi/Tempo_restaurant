using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class BillRepository :GenericRepository<BillEntity>, IBillRepository
{
    private readonly DbSet<BillEntity> dbSet;

    public BillRepository(TempoDbContext dbcontext) : base(dbcontext) 
    {
    }

    public override Task<List<BillEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Order);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<BillEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Order)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
