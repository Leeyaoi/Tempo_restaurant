using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseEntity
{
    private readonly TempoDbContext dbContext;
    private readonly DbSet<Entity> dbSet;

    public GenericRepository(TempoDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<Entity>();
    }

    public async Task<Entity> Create(Entity entity, CancellationToken cancellationToken)
    {
        var result = await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public Task Delete(Entity entity, CancellationToken cancellationToken)
    {
        dbContext.Remove(entity);
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Entity> Update(Entity entity, CancellationToken cancellationToken)
    {
        var result = dbSet.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public virtual Task<List<Entity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet.AsNoTracking();
        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public virtual Task<Entity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public Task<List<Entity>> GetByPredicate(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
    {
        return dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public Task<List<Entity>> Paginate(int limit, int page, CancellationToken cancellationToken, out int total, out int count, Expression<Func<Entity, bool>>? predicate)
    {
        var data = dbSet.AsNoTracking();
        if (predicate != null)
        {
            data = data.Where(predicate);
        }
        total = data.Count();
        count = total / limit;
        return data.Skip(limit * (page - 1)).Take(limit).ToListAsync(cancellationToken);
    }
}
