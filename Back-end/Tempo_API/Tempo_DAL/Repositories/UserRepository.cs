using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    private readonly DbSet<UserEntity> dbSet;
    public UserRepository(TempoDbContext dbсontext) : base(dbсontext)
    {
        dbSet = dbсontext.Set<UserEntity>();
    }

    public override Task<List<UserEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Orders);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<UserEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Orders)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
