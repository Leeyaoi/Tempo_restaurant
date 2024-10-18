using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class TableRepository : GenericRepository<TableEntity>, ITableRepository
{
    public TableRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<TableEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new TableEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Max_people = e.Max_people,
                       WaiterId = e.WaiterId,
                       OrderList = e.OrderList,
                       Waiter = e.Waiter,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<TableEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new TableEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Max_people = e.Max_people,
                                WaiterId = e.WaiterId,
                                OrderList = e.OrderList,
                                Waiter = e.Waiter,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
