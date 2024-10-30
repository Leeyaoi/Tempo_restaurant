
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DrinkOrderRepository : GenericRepository<DrinkOrderEntity>, IDrinkOrderRepository
{
    public DrinkOrderRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }
}
