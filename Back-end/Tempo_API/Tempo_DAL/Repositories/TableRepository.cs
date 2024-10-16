using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class TableRepository : GenericRepository<TableEntity>, ITableRepository
{
    private readonly DbSet<TableEntity> dbSet;
    public TableRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
        dbSet = dbcontext.Set<TableEntity>();
    }
    public override Task<List<TableEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Waiter)
            .Include(e => e.OrderList);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<TableEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Waiter)
            .Include(e => e.OrderList)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
