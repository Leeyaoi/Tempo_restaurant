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

    public async Task<Entity> Create(Entity element, CancellationToken cancellationToken)
    {
        dbSet.Add(element);
        await dbContext.SaveChangesAsync(cancellationToken);
        return element;
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var element = await dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (element != null)   
        {
            dbSet.Remove(element);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Entity> Update(Entity element, CancellationToken cancellationToken)
    {
        dbSet.Update(element);
        await dbContext.SaveChangesAsync(cancellationToken);
        return element;
    }

    public Task<List<Entity>> GetAll(CancellationToken cancellationToken)
    {
        return dbSet.ToListAsync(cancellationToken);
    }

    public Task<Entity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public Task<List<Entity>> GetByPredicate(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
    {
        return dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }


}
