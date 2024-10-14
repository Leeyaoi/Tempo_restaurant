using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class IngredientRepository : GenericRepository<IngredientEntity>, IIngredientRepository
{
    private readonly DbSet<IngredientEntity> dbSet;
    public IngredientRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
    public override Task<List<IngredientEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.IngredientDish);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<IngredientEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.IngredientDish)
            .FirstOrDefaultAsync(cancellationToken);
    }
}