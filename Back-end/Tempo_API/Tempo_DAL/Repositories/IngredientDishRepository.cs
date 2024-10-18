using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class IngredientDishRepository : GenericRepository<IngredientDishEntity>, IIngredientDishRepository
{
    public IngredientDishRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<IngredientDishEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new IngredientDishEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Needed = e.Needed,
                       DishId = e.DishId,
                       IngredientId = e.IngredientId,
                       Dish = e.Dish,
                       Ingredient = e.Ingredient,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<IngredientDishEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new IngredientDishEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Needed = e.Needed,
                                DishId = e.DishId,
                                IngredientId = e.IngredientId,
                                Dish = e.Dish,
                                Ingredient = e.Ingredient,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}