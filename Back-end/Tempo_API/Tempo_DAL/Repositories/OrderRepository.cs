using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class OrderRepository : GenericRepository<OrderEntity>, IOrderRepository
{
    private readonly DbSet<OrderEntity> dbSet;
    public OrderRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
    public override Task<List<OrderEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Table)
            .Include(e=> e.Dishes)
            .Include(e => e.User);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<OrderEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Table)
            .Include(e => e.Dishes)
            .Include(e => e.User)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
