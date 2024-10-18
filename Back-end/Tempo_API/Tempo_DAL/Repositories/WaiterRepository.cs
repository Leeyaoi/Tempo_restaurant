using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class WaiterRepository : GenericRepository<WaiterEntity>, IWaiterRepository
{
    public WaiterRepository(TempoDbContext dbсontext) : base(dbсontext)
    {
    }
    public override Task<List<WaiterEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new WaiterEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Name = e.Name,
                       Surname = e.Surname,
                       EmployeeId = e.EmployeeId,
                       Employee = e.Employee,
                       Tables = e.Tables
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<WaiterEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new WaiterEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Name = e.Name,
                                Surname = e.Surname,
                                EmployeeId = e.EmployeeId,
                                Employee = e.Employee,
                                Tables = e.Tables
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
