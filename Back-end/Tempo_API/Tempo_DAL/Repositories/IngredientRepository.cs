using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class IngredientRepository : GenericRepository<IngredientEntity>, IIngredientRepository
{
    public IngredientRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}