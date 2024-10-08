using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DrinkRepository : GenericRepository<DrinkEntity>, IDrinkRepository
{
    public DrinkRepository(TempoDbContext dbContext) :base(dbContext)
    {
    }
}
