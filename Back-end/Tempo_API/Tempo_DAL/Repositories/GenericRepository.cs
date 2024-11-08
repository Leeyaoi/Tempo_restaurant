using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseEntity
{
    protected readonly TempoDbContext dbContext;
    protected readonly DbSet<Entity> dbSet;

    public GenericRepository(TempoDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<Entity>();
    }

    public async Task<Entity> Create(Entity entity, CancellationToken cancellationToken)
    {
        entity.Id = Guid.NewGuid();
        var result = await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public Task Delete(Entity entity, CancellationToken cancellationToken)
    {
        var result = dbContext.Remove(entity);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Entity> Update(Entity entity, CancellationToken cancellationToken)
    {
        var result = dbSet.Update(entity);
        if (result == null)
        {
            throw new NotFoundException();
        }
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

    public virtual async Task<Entity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }

    public async Task<List<Entity>> GetByPredicate(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
    {
        var result = await dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        return result;
    }

    public Task<List<Entity>> Paginate(int limit, int page, CancellationToken cancellationToken, out int total, out int count, Expression<Func<Entity, bool>>? predicate)
    {
        var data = dbSet.AsNoTracking();
        if (predicate != null)
        {
            data = data.Where(predicate);
        }
        total = data.Count();

        if (total % limit == 0) { count = total / limit; }
        else { count = (total / limit) + 1; }

        return data.Skip(limit * (page - 1)).Take(limit).ToListAsync(cancellationToken);
    }

    //public Task<List<Entity>> Paginate(int limit, int page, CancellationToken cancellationToken, out int total, out int count, Expression<Func<Entity, bool>>? predicate)
    //{
    //    var data = dbSet.AsNoTracking();
    //    if (predicate != null)
    //    {
    //        data = data.Where(predicate);
    //    }
    //    total = data.Count();
    //    count = total / limit;
    //    return data.Skip(limit * (page - 1)).Take(limit).ToListAsync(cancellationToken);
    //}
}
