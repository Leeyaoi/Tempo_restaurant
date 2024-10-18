using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
{
    public EmployeeRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<EmployeeEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new EmployeeEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Login = e.Login,
                       Password = e.Password,
                       Waiter = e.Waiter,
                       Cook = e.Cook,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<EmployeeEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new EmployeeEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Login = e.Login,
                                Password = e.Password,
                                Waiter = e.Waiter,
                                Cook = e.Cook,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
