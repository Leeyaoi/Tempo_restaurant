using System.Linq.Expressions;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class IngredientDishRepository : GenericRepository<IngredientDishEntity>, IIngredientDishRepository
{
    public IngredientDishRepository(TempoDbContext dbContext) : base(dbContext)
    {}
}