using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishRepository : GenericRepository<DishEntity>, IDishRepository
{
    public DishRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}
