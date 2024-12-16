using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class DishOrderRepository : GenericRepository<DishOrderEntity>, IDishOrderRepository
{
    public DishOrderRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }
}
