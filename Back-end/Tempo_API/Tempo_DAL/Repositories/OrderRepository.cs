using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class OrderRepository : GenericRepository<OrderEntity>, IOrderRepository
{
    public OrderRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<OrderEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new OrderEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       People_num = e.People_num,
                       Status = e.Status,
                       TableId = e.TableId,
                       UserId = e.UserId,
                       Table = e.Table,
                       User = e.User,
                       Dishes = e.Dishes,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<OrderEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new OrderEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                People_num = e.People_num,
                                Status = e.Status,
                                TableId = e.TableId,
                                UserId = e.UserId,
                                Table = e.Table,
                                User = e.User,
                                Dishes = e.Dishes,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
