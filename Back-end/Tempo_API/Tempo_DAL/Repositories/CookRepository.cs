using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class CookRepository : GenericRepository<CookEntity>, ICookRepository
{
    private readonly DbSet<CookEntity> dbSet;
    public CookRepository(TempoDbContext dbcontext) : base(dbcontext) 
    {
        dbSet = dbcontext.Set<CookEntity>();
    }

    public override Task<List<CookEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Employee)
            .Include(e => e.Category);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<CookEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Employee)
            .Include(e => e.Category)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
