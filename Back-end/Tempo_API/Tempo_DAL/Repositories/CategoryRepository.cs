using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
{
    private readonly DbSet<CategoryEntity> dbSet;
    public CategoryRepository(TempoDbContext dbContext) : base (dbContext) 
    {
    }
    public override Task<List<CategoryEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Cooks)
            .Include(e => e.Drinks)
            .Include(e => e.Dishes);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<CategoryEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Cooks)
            .Include(e => e.Drinks)
            .Include(e => e.Dishes)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
