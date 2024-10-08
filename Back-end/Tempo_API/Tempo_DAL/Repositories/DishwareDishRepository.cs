using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishwareDishRepository : GenericRepository<DishwareDishEntity>, IDishwareDishRepository
{
    public DishwareDishRepository(TempoDbContext dbContext) : base(dbContext) 
    {
    }
}
     
