using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class TablewareDishRepository : GenericRepository<TablewareDishEntity>, ITablewareDishRepository
{
    public TablewareDishRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<TablewareDishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new TablewareDishEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       TablewareId = e.TablewareId,
                       DishId = e.DishId,
                       Tableware = e.Tableware,
                       Dish = e.Dish,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<TablewareDishEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new TablewareDishEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                TablewareId = e.TablewareId,
                                DishId = e.DishId,
                                Tableware = e.Tableware,
                                Dish = e.Dish,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
