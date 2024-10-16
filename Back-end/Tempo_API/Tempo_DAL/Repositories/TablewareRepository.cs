using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class TablewareRepository : GenericRepository<TablewareEntity>, ITablewareRepository
{
    private readonly DbSet<TablewareEntity> dbSet;
    public TablewareRepository(TempoDbContext dbсontext) : base(dbсontext)
    {
        dbSet = dbсontext.Set<TablewareEntity>();
    }

    public override Task<List<TablewareEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Dishes);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<TablewareEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Dishes)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
