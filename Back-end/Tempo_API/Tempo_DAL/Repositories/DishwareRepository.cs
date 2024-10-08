using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishwareRepository : GenericRepository<DishwareEntity>, IDishwareRepository
{
    public DishwareRepository(TempoDbContext dbContext) :base(dbContext)
    {
    }
}
