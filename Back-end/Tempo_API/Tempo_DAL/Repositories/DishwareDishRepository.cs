using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class DishwareDishRepository : GenericRepository<DishwareDishEntity>, IDishwareDishRepository
{
    public DishwareDishRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<DishwareDishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new DishwareDishEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       DishId = e.DishId,
                       DishwareId = e.DishwareId,
                       Dish = e.Dish,
                       Dishware = e.Dishware,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<DishwareDishEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new DishwareDishEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                DishId = e.DishId,
                                DishwareId = e.DishwareId,
                                Dish = e.Dish,
                                Dishware = e.Dishware,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}

