using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class DishRepository : GenericRepository<DishEntity>, IDishRepository
{
    public DishRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<DishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new DishEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Name = e.Name,
                       Approx_time = e.Approx_time,
                       Price = e.Price,
                       CategoryId = e.CategoryId,
                       Category = e.Category,
                       DishwareList = e.DishwareList,
                       TablewareList = e.TablewareList,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<DishEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new DishEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Name = e.Name,
                                Approx_time = e.Approx_time,
                                Price = e.Price,
                                CategoryId = e.CategoryId,
                                Category = e.Category,
                                DishwareList = e.DishwareList,
                                TablewareList = e.TablewareList,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
