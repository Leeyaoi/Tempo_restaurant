using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
{
    private readonly DbSet<EmployeeEntity> dbSet;
    public EmployeeRepository(TempoDbContext dbContext) : base(dbContext) 
    {
    }
    public override Task<List<EmployeeEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = dbSet
            .AsNoTracking()
            .Include(e => e.Cook)
            .Include(e => e.Waiter);

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override Task<EmployeeEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(e => e.Waiter)
            .Include(e => e.Cook)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
