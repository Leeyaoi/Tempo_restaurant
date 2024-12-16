using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class WaiterRepository : GenericRepository<WaiterEntity>, IWaiterRepository
{
    public WaiterRepository(TempoDbContext dbсontext) : base(dbсontext)
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

    public override async Task<WaiterEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Employee)
            .Include(e => e.Tables)
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }

    public Task<List<WaiterEntity>> Paginate(int limit, int page, CancellationToken cancellationToken, out int total, out int count, Expression<Func<WaiterEntity, bool>>? predicate)
    {
        var data = dbSet.AsNoTracking();
        if (predicate != null)
        {
            data = data.Where(predicate);
        }
        total = data.Count();

        if (total % limit == 0) { count = total / limit; }
        else { count = (total / limit) + 1; }

        return data.Skip(limit * (page - 1)).Take(limit).Include(e => e.Employee).Include(e => e.Tables).ToListAsync(cancellationToken);
    }
}
